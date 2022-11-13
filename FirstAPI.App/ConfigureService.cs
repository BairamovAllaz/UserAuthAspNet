using FirstAPI.App.Models;

namespace FirstAPI.App;

public static class ConfigureService
{
    public static void AddUser(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddSingleton<IUserDao, UserDao>();
    }
}