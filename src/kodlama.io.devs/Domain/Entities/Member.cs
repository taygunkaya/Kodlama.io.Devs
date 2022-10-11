using Core.Security.Entities;
using Core.Security.Enums;
 

namespace Domain.Entities
{
    public class Member : User
    {
        public virtual ICollection<GithubAccount> GithubAccounts { get; set; }

        public Member()
        {
        }

        public Member(int id, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash, bool status, AuthenticatorType authenticatorType) : base(id, firstName, lastName, email, passwordSalt, passwordHash, status, authenticatorType)
        {
        }
    }
}

