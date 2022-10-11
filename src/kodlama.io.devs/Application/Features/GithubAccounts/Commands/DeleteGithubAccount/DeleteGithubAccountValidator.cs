using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAccounts.Commands.DeleteGithubAccount
{
    public class DeleteGithubAccountValidator : AbstractValidator<DeleteGithubAccountCommand>
    {
        public DeleteGithubAccountValidator()
        {
            RuleFor(g => g.Id).NotNull();
        }
    }
}

