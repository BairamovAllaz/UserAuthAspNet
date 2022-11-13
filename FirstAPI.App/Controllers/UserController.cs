using FirstAPI.App.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.App.Controllers;

[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private IUserDao _database;

    public UserController(IUserDao database)
    {
        _database = database;
    }
    
    [HttpGet("GetUser")]
    public ActionResult<List<User>> Get()
    {
        var users = _database.GetUsers();
        return Ok(users);
    }

    [HttpGet("GetUserById/{firstName}")]
    public ActionResult<User> GetUserById(string firstName)
    {
        var user = _database.GetUserById(firstName);
        if (user is null)
        {
            return NotFound("User dont exsist");
        }
        return user;
    }


    [HttpPost("AddUser")]
    public ActionResult<User> AddUser([FromBody] User? user)
    {
        if (user is null)
        {
            return NotFound("User dont exsist");
        }
        var resultUser = _database.AddUser(user);
        return Ok(resultUser); 
    }

    [HttpDelete("{firstName}")]
    public ActionResult DeleteUser(string firstName)
    {
        var userToRemove = _database.FindUserByFirstName(firstName);
        if (userToRemove is null)
            return Content("User dont exist");
        var deleteResult = _database.DeleteUser(userToRemove);
        return Ok();
    }
    
    [HttpPatch("{firstName}")]
    public ActionResult UpdateUser(string firstName,[FromBody] JsonPatchDocument<User> patch)
    {
        var userToUpdate = _database.FindUserByFirstName(firstName);
        if (userToUpdate is null)
        {
            return NotFound("User cant be null");
        }
        var original = userToUpdate?.Clone();
        patch.ApplyTo(userToUpdate,ModelState);
        _database.UpdateUser(userToUpdate);
        var info = new
        {
            original,
            UpdatedUser = userToUpdate
        };
        return Ok(info);
    }
}