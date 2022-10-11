using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAccounts.Commands.UpdateGithubAccount
{
    public class UpdateGithubAccountValidator : AbstractValidator<UpdateGithubAccountCommand>
    {
        public UpdateGithubAccountValidator()
        {
            RuleFor(g => g.Id).NotNull();
            RuleFor(g => g.MemberId).NotNull();


        }
    }
}
