using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.GithubAccounts.Dtos
{
    public class GetByMemberIdGithubAccountDto
    {
        public int Id { get; set; }
        public string MemberEmail { get; set; }
        public string GithubLink { get; set; }
    }
}

