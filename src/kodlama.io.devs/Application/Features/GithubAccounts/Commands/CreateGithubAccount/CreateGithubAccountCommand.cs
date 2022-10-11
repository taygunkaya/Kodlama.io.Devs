using Application.Features.Core.Commands;
using Application.Features.GithubAccounts.Dtos;
using Application.Features.GithubAccounts.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Repositories;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAccounts.Commands.CreateGithubAccount
{
    public class CreateGithubAccountCommand : IRequest<CreatedGithubAccountDto>
    {
        public int MemberId { get; set; }
        public string GithubLink { get; set; }
        public class CreateGithubAccountCommandHandler : BaseCommandHandler<IGithubAccountRepository, GithubAccountBusinessRules>,
            IRequestHandler<CreateGithubAccountCommand, CreatedGithubAccountDto>
        {
            public CreateGithubAccountCommandHandler(IGithubAccountRepository repository, IMapper mapper, GithubAccountBusinessRules businessRules) : base(repository, mapper, businessRules)
            {
            }

            public async Task<CreatedGithubAccountDto> Handle(CreateGithubAccountCommand request, CancellationToken cancellationToken)
            {
                GithubAccount githubAccount = _mapper.Map<GithubAccount>(request);

                await _businessRules.GithubAccountCanNotBeInsertedWhenMemberAlreadyHaveOne(githubAccount);

                GithubAccount addedGithubAccount = await _repository.AddAsync(githubAccount);

                CreatedGithubAccountDto createdGithubAccountDto = _mapper.Map<CreatedGithubAccountDto>(addedGithubAccount);
                return createdGithubAccountDto;

            }
        }
    }
}

