using Application.Features.GithubAccounts.Commands.CreateGithubAccount;
using Application.Features.GithubAccounts.Commands.DeleteGithubAccount;
using Application.Features.GithubAccounts.Commands.UpdateGithubAccount;
using Application.Features.GithubAccounts.Dtos;
using Application.Features.GithubAccounts.Queries.GetGithubAccountByMemberId;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubAccountsController : BaseController
    {

        [HttpPost("create")]
        public async Task<IActionResult> CreateGithubAccount([FromBody] CreateGithubAccountCommand command)
        {
            CreatedGithubAccountDto createdGithubAccountDto = await Mediator.Send(command);
            return Ok(createdGithubAccountDto);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteGithubAccountCommand command)
        {
            DeletedGithubAccountDto deletedGithubAccountDto = await Mediator.Send(command);
            return Ok(deletedGithubAccountDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateGithubAccountCommand command)
        {
            UpdatedGithubAccountDto updatedGithubAccountDto = await Mediator.Send(command);
            return Ok(updatedGithubAccountDto);
        }

        [HttpGet("{MemberId}")]
        public async Task<IActionResult> GetByMemberId([FromRoute] GetGithubAccountByMemberIdQuery query)
        {
            GetByMemberIdGithubAccountDto getByMemberIdGithubAccountDto = await Mediator.Send(query);
            return Ok(getByMemberIdGithubAccountDto);
        }
    }
}