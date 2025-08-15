using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Users.Domain.Entities;

namespace ColombianCoffeeApp.src.Modules.Users.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> ObtenerPorCredencialesAsync(string nombreUsuario, string contrasena);
        Task CrearAsync(User usuario);
        Task<User?> ObtenerPorNombreAsync(string nombreUsuario);
        Task<List<User>> ListarTodosAsync();
        Task<bool> EliminarAsync(int id);
    }
}