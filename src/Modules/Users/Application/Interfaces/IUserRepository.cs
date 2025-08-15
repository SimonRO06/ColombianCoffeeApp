using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Users.Domain.Entities;

namespace ColombianCoffeeApp.src.Modules.Users.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<Usuario?> ObtenerPorCredencialesAsync(string nombreUsuario, string contrasena);
        Task CrearAsync(Usuario usuario);
        Task<Usuario?> ObtenerPorNombreAsync(string nombreUsuario);
        Task<List<Usuario>> ListarTodosAsync();
        Task<bool> EliminarAsync(int id);
    }
}