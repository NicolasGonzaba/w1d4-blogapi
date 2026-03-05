using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using w1d4_blogapi.Models;
using w1d4_blogapi.Models.DTO;
using w1d4_blogapi.Services;

namespace w1d4_blogapi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly UserService _data;

    public UserController(UserService dataFromService)
    {
        _data = dataFromService;
    }

    // Function to add our user type of CreateAccountDTO call UserTodadd this will return bool once out user is added
    // add user
    [HttpPost("AddUser")]
    public bool AddUser(CreateAccountDTO UserToAdd)
    {
        return _data.AddUser(UserToAdd);
    }

    // GetAllUsers
    [HttpGet("GetAllUsers")]
    public IEnumerable<UserModel> GetAllUSers()
    {
        return _data.GetAllUsers();
    }

    // GetUserByUsername

    [HttpGet("GetUserByUsername")]
    public UserIdDTO GetUserDTOUsername(string username)
    {
        return _data.GetUserIdDTOByUsername(username);
    }

    // Login endpoint

    [HttpPost("Login")]
    public IActionResult Login([FromBody] LoginDTO User)
    {
        return _data.Login(User);
    }
}
