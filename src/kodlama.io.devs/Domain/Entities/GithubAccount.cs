using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class GithubAccount : Entity
    {
        public int MemberId { get; set; }
        public string GithubLink { get; set; }

        public GithubAccount()
        {

        }

        public GithubAccount(int id, int memberId, string githubLink) : base(id)
        {
            Id = id;
            MemberId = memberId;
            GithubLink = githubLink;
        }

        public virtual Member Member { get; set; }
    }
}
