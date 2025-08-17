using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Users.Domain.Entities;

namespace ColombianCoffeeApp.src.Modules.Users.Application.Interfaces
{
    public interface IUserService
    {
        Task<User?> LoginAsync(string nombreUsuario, string contrasena);
        Task RegistrarAdminAsync(string nombreUsuario, string contrasena);
        Task CrearUsuarioAsync(string nombreUsuario, string contrasena, string rolTexto);
        Task<IEnumerable<User>> ObtenerTodosAsync();
        Task<bool> EliminarAsync(int id);
        Task<User?> ObtenerPorNombreAsync(string nombreUsuario);
    }
}