using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserPhoneTest.Application.Contracts.Phones;
using UserPhoneTest.Application.Features.Phones.AddUserPhone;
using UserPhoneTest.Application.Features.Phones.DeleteUserPhone;
using UserPhoneTest.Application.Features.Phones.GetAllUserPhones;
using UserPhoneTest.Application.Features.Phones.UpdateUserPhone;

namespace UserPhoneTest.Api.Controllers;

[ApiController]
[Route("api/phones")]
public class PhonesController(ISender sender) : ControllerBase
{
    private const string phoneIdParameter = "{id:int}";
    private readonly ISender _sender = sender;

    [HttpGet]
    public async Task<IActionResult> GetUserPhones(int userId, CancellationToken cancellationToken)
    {
        var query = new GetUserPhonesQuery(userId);

        var response = await _sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpPost]
    public async Task<IActionResult> AddUserPhone(AddUserPhoneRequest request, CancellationToken cancellationToken)
    {
        var command = new AddUserPhoneCommand(request);

        var response = await _sender.Send(command, cancellationToken);

        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }

    [HttpDelete(phoneIdParameter)]
    public async Task<IActionResult> DeleteUserPhone(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteUserPhoneCommand(id);

        var response = await _sender.Send(command, cancellationToken);

        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }

    [HttpPut]
    public async Task<IActionResult> UpdatePhone(UpdatePhoneRequest request, CancellationToken cancellationToken)
    {
        var command = new UpdateUserPhoneCommand(request);

        var response = await _sender.Send(command, cancellationToken);

        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }
}
