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

namespace Application.Features.GithubAccounts.Commands.DeleteGithubAccount
{
    public class DeleteGithubAccountCommand : IRequest<DeletedGithubAccountDto>
    {
        public int Id { get; set; }
        public class DeleteGithubAccountCommandHandler : BaseCommandHandler<IGithubAccountRepository, GithubAccountBusinessRules>,
            IRequestHandler<DeleteGithubAccountCommand, DeletedGithubAccountDto>
        {
            public DeleteGithubAccountCommandHandler(IGithubAccountRepository repository, IMapper mapper, GithubAccountBusinessRules businessRules) : base(repository, mapper, businessRules)
            {
            }

            public async Task<DeletedGithubAccountDto> Handle(DeleteGithubAccountCommand request, CancellationToken cancellationToken)
            {
                GithubAccount githubAccount = await _repository.GetAsync(m => m.Id == request.Id);

                _businessRules.GithubAccountMustExistWhenRequested(githubAccount);

                GithubAccount githubAccountToBeDeleted = await _repository.DeleteAsync(githubAccount);

                DeletedGithubAccountDto deletedGithubAccountDto = _mapper.Map<DeletedGithubAccountDto>(githubAccountToBeDeleted);
                return deletedGithubAccountDto;
            }
        }
    }
}
