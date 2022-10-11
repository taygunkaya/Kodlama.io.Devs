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

namespace Application.Features.GithubAccounts.Queries.GetGithubAccountByMemberId
{
    public class GetGithubAccountByMemberIdQuery : IRequest<GetByMemberIdGithubAccountDto>
    {
        public int MemberId { get; set; }
        public class GetGithubAccountByMemberIdQueryHandler : BaseCommandHandler<IGithubAccountRepository, GithubAccountBusinessRules>, IRequestHandler<GetGithubAccountByMemberIdQuery, GetByMemberIdGithubAccountDto>
        {
            public GetGithubAccountByMemberIdQueryHandler(IGithubAccountRepository repository, IMapper mapper, GithubAccountBusinessRules businessRules) : base(repository, mapper, businessRules)
            {
            }

            public async Task<GetByMemberIdGithubAccountDto> Handle(GetGithubAccountByMemberIdQuery request, CancellationToken cancellationToken)
            {

                //await _memberBusinessRules.CheckIsMemberExistByIdAsync(request.MemberId);

                GithubAccount githubAccount = await _repository.GetAsync(m => m.MemberId == request.MemberId);

                _businessRules.GithubAccountMustExistWhenRequested(githubAccount);

                GetByMemberIdGithubAccountDto getByMemberIdGithubAccountDto = _mapper.Map<GetByMemberIdGithubAccountDto>(githubAccount);

                return getByMemberIdGithubAccountDto;
            }
        }
    }
}
