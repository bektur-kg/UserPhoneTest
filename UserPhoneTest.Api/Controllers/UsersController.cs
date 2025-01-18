using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserPhoneTest.Application.Features.Users.GetAll;

namespace UserPhoneTest.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet]
    public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
    {
        var query = new GetAllUsersQuery();

        var response = await _sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }
}
