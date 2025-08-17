using ColombianCoffeeApp;
using ColombianCoffeeApp.src.Modules.Users.Application.Services;
using ColombianCoffeeApp.src.Modules.Users.Infrastructure.Repositories;
using ColombianCoffeeApp.src.Shared.Helpers;
using ColombianCoffeeApp.src.UI;

internal class Program
{
    private static async Task Main(string[] args)
    {
        using var db = DbContextFactory.Create(); // Crea el contexto de la base de datos
        DataSeeder.Seed(db); // Llama al método Seed para insertar datos iniciales

        var usuarioRepo = new UserRepository(db); // Crea una instancia del repositorio de usuarios
        var usuarioService = new UserService(usuarioRepo); // Crea una instancia del servicio de usuarios

        var menuPrincipal = new MainMenu(usuarioService); // Crea una instancia del menú principal con el servicio de usuarios
        await menuPrincipal.MostrarAsync(); // Muestra el menú principal y espera la interacción del usuario
    }
}