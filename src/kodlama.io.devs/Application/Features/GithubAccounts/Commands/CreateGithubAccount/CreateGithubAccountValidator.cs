using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAccounts.Commands.CreateGithubAccount
{
    public class CreateGithubAccountValidator : AbstractValidator<CreateGithubAccountCommand>
    {
        public CreateGithubAccountValidator()
        {

            RuleFor(g => g.GithubLink).NotNull().NotEmpty();
        }
    }
}
