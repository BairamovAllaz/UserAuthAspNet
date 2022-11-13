using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.App.Models;

public interface IUserDao
{
    public List<User> GetUsers();
    public User? GetUserById(string firstName);
    public User AddUser(User user);
    public bool DeleteUser(User user);
    public User UpdateUser(User userToUpdate);
    public User? FindUserByFirstName(string firstName);
}
