using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAccounts.Queries.GetGithubAccountByMemberId
 
{
    public class GetGithubAccountByMemberIdValidator : AbstractValidator<GetGithubAccountByMemberIdQuery>
    {
        public GetGithubAccountByMemberIdValidator()
        {
            RuleFor(g => g.MemberId).NotNull();
        }
    }
}