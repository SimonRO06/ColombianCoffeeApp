using ColombianCoffeeApp;
using ColombianCoffeeApp.src.Modules.Users.Application.Services;
using ColombianCoffeeApp.src.Modules.Users.Infrastructure.Repositories;
using ColombianCoffeeApp.src.Shared.Helpers;
using ColombianCoffeeApp.src.UI;

internal class Program
{
    private static async Task Main(string[] args)
    {
        using var db = DbContextFactory.Create();
        DataSeeder.Seed(db);

        var usuarioRepo = new UserRepository(db);
        var usuarioService = new UserService(usuarioRepo);

        var menuPrincipal = new MainMenu(usuarioService);
        await menuPrincipal.MostrarAsync();
    }
}