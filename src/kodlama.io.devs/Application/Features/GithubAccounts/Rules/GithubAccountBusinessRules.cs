using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAccounts.Rules
{
    public class GithubAccountBusinessRules
    {
        private readonly IGithubAccountRepository _githubAccountRepository;

        public GithubAccountBusinessRules(IGithubAccountRepository githubAccountRepository)
        {
            _githubAccountRepository = githubAccountRepository;
        }
        public void GithubAccountMustExistWhenRequested(GithubAccount githubAccount)
        {
            if (githubAccount == null) throw new BusinessException("Github Account must exist.");
        }
        public async Task GithubAccountCanNotBeInsertedWhenMemberAlreadyHaveOne(GithubAccount githubAccount)
        {
            GithubAccount? git = await _githubAccountRepository.GetAsync(g => g.MemberId == githubAccount.MemberId);

            if (git != null) throw new BusinessException("One member can't have two github profiles!");
        }

    }
}
