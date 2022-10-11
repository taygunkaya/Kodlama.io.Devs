using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Hashing;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Rules
{
    public class AuthBusinessRules
    {
        private readonly IMemberRepository _memberRepository;
        public AuthBusinessRules(IMemberRepository memberRepository)

        {
            this._memberRepository = memberRepository;
        }
        public void MemberMustExistWhenRequested(Member member)
        {
            if (member == null) throw new BusinessException("Member must exist.");
        }
        public async Task EmailCanNotBeDuplicatedWhenRegistered(string email)
        {
            Member? member = await _memberRepository.GetAsync(u => u.Email == email);
            if (member != null) throw new BusinessException("Mail already exists");

        }
        public async Task CheckIsMemberExistByIdAsync(int id)
        {
            Member? member = await _memberRepository.GetAsync(m => m.Id == id);
            MemberMustExistWhenRequested(member);
        }

        public void VerifyMemberPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool verified = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!verified) throw new AuthorizationException("Entered password is wrong");

        }

    }
}
