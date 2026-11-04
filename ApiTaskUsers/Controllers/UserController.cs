using ApiTaskUsers.Data.Dtos.Users;
using ApiTaskUsers.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTaskUsers.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class UserController(UserServices userServices) : ControllerBase
{
    private readonly UserServices _userServices = userServices;
    [HttpPost]
    public async Task<ActionResult<ReadUserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
    {
        var user = await _userServices.CreateUser(createUserDto);
        return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ReadUserDto>> GetUser(int id)
    {
        var user = await _userServices.GetUser(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReadUserDto>>> GetAllUsers()
    {
        var users = await _userServices.GetAllUsers();
        return Ok(users);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<ReadUserDto>> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
    {
        var user = await _userServices.UpdateUser(id, updateUserDto);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult<bool>> DeleteUser(int id)
    {
        var result = await _userServices.DeleteUser(id);
        if (!result)
        {
            return NotFound();
        }
        return Ok(result);
    }
}
