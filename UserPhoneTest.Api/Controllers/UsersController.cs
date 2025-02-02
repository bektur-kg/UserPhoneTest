﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserPhoneTest.Application.Contracts.Users;
using UserPhoneTest.Application.Features.Users.Create;
using UserPhoneTest.Application.Features.Users.Delete;
using UserPhoneTest.Application.Features.Users.GetAll;
using UserPhoneTest.Application.Features.Users.GetById;

namespace UserPhoneTest.Api.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController(ISender sender) : ControllerBase
{
    private const string userIdParameter = "{id:int}";
    private readonly ISender _sender = sender;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetUsersQuery();

        var response = await _sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateUserRequest request, CancellationToken cancellationToken)
    {
        var command = new CreateUserCommand(request);

        var response = await _sender.Send(command, cancellationToken);

        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }

    [HttpDelete(userIdParameter)]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommand(id);

        var response = await _sender.Send(command, cancellationToken);

        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }

    [HttpPut(userIdParameter)]
    public async Task<IActionResult> Update(int id, CancellationToken cancellationToken)
    {
        var command = new DeleteUserCommand(id);

        var response = await _sender.Send(command, cancellationToken);

        return response.IsSuccess ? Ok() : BadRequest(response.Error);
    }

    [HttpGet(userIdParameter)]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetUserQuery(id);

        var response = await _sender.Send(query, cancellationToken);

        return response.IsSuccess ? Ok(response.Value) : BadRequest(response.Error);
    }
}
