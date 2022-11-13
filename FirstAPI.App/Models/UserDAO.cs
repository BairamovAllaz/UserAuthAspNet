using System.Web.Http.ModelBinding;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.App.Models;

public class UserDao : IUserDao
{
    private List<User> _users;

    public UserDao()
    {
        _users = new List<User>();
    }

    public List<User> GetUsers()
    {
        return _users;
    }

    public User AddUser(User user)
    {
        _users.Add(user);
        return user;
    }
    
    public bool DeleteUser(User user)
    {
        return _users.Remove(user);
    }

    public User UpdateUser(User updatedUser)
    {
        var indexToUpdate = _users.FindIndex((i) => i.FirstName == updatedUser.FirstName);
        _users[indexToUpdate] = updatedUser;
        return updatedUser;
    }

    public User? FindUserByFirstName(string firstName)
    {
        return _users.FirstOrDefault((a) => a.FirstName == firstName);
    }

    public User? GetUserById(string firstName)
    {
        return FindUserByFirstName(firstName);
    }
    
}