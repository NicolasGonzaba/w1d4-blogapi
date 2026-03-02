using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    public bool AddUser(CreateAccountDTO UserToAdd)
    {
        throw new NotImplementedException();

    }
}
