using Microsoft.AspNetCore.Mvc;

namespace UserPhoneTest.Api.Controllers;

public class UsersController : ControllerBase
{
    public IActionResult GetUsers()
    {
        return Ok();
    }
}
