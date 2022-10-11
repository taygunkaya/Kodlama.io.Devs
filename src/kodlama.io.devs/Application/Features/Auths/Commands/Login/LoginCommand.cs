using Application.Features.Auths.Dtos;
using Application.Features.Auths.Rules;
using Application.Services.AuthService;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auths.Commands.Login
{
    public class LoginCommand : IRequest<LoggedMemberDto>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }
        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedMemberDto>
        {
            private readonly IMemberRepository _memberRepository;
            private readonly IAuthService _authService;
            private readonly AuthBusinessRules _authBusinessRules;

            public LoginCommandHandler(IMemberRepository memberRepository, IAuthService authService, AuthBusinessRules authBusinessRules)
            {
                _memberRepository = memberRepository;
                _authService = authService;
                _authBusinessRules = authBusinessRules;
            }

            public async Task<LoggedMemberDto> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                Member? memberToLogin = await _memberRepository.GetAsync(m => m.Email == request.UserForLoginDto.Email);

                _authBusinessRules.MemberMustExistWhenRequested(memberToLogin);
                _authBusinessRules.VerifyMemberPassword(request.UserForLoginDto.Password, memberToLogin.PasswordHash, memberToLogin.PasswordSalt);

                AccessToken createdAccessToken = await _authService.CreateAccessToken(memberToLogin);
                RefreshToken createdRefreshToken = await _authService.CreateRefreshToken(memberToLogin, request.IpAddress);
                RefreshToken addedRefreshToken = await _authService.AddRefreshToken(createdRefreshToken);

                LoggedMemberDto loggedMemberDto = new()
                {
                    RefreshToken = addedRefreshToken,
                    AccessToken = createdAccessToken
                };
                return loggedMemberDto;


            }
        }
    }
}
