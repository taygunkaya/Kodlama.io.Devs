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

namespace Application.Features.GithubAccounts.Commands.UpdateGithubAccount
{
    public class UpdateGithubAccountCommand : IRequest<UpdatedGithubAccountDto>
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public string GithubLink { get; set; }
        public class UpdateGithubAccountCommandHandler : BaseCommandHandler<IGithubAccountRepository, GithubAccountBusinessRules>,
            IRequestHandler<UpdateGithubAccountCommand, UpdatedGithubAccountDto>
        {

            public UpdateGithubAccountCommandHandler(IGithubAccountRepository repository, IMapper mapper, GithubAccountBusinessRules businessRules) : base(repository, mapper, businessRules)
            {

            }

            public async Task<UpdatedGithubAccountDto> Handle(UpdateGithubAccountCommand request, CancellationToken cancellationToken)
            {
                GithubAccount? githubAccount = await _repository.GetAsync(g => g.Id == request.Id);

                _businessRules.GithubAccountMustExistWhenRequested(githubAccount);
                //await _memberBusinessRules.CheckIsMemberExistByIdAsync(request.MemberId);


                githubAccount.MemberId = request.MemberId;
                githubAccount.GithubLink = request.GithubLink;

                GithubAccount updatedGithubAccount = await _repository.UpdateAsync(githubAccount);

                UpdatedGithubAccountDto updatedGithubAccountDto = _mapper.Map<UpdatedGithubAccountDto>(updatedGithubAccount);
                return updatedGithubAccountDto;
            }
        }
    }
}