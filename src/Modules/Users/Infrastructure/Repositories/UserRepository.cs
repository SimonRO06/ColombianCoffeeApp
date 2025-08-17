using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Users.Application.Interfaces;
using ColombianCoffeeApp.src.Modules.Users.Domain.Entities;
using ColombianCoffeeApp.src.Shared.Context;
using Microsoft.EntityFrameworkCore;

namespace ColombianCoffeeApp.src.Modules.Users.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context; // Inyecta el contexto de la base de datos
        }

        public async Task<User?> ObtenerPorCredencialesAsync(string nombreUsuario, string contrasena)
        {
            return await _context.Users // Consulta la base de datos para obtener un usuario por sus credenciales
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);
        }

        public async Task CrearAsync(User usuario)
        {
            _context.Users.Add(usuario); // Agrega un nuevo usuario al contexto
            await _context.SaveChangesAsync();
        }

        public async Task<User?> ObtenerPorNombreAsync(string nombreUsuario)
        {
            return await _context.Users // Consulta la base de datos para obtener un usuario por su nombre de usuario
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        }

        public async Task<List<User>> ListarTodosAsync() // Lista todos los usuarios
        {
            return await _context.Users.ToListAsync(); // Obtiene todos los usuarios de la base de datos
        }

        public async Task<bool> EliminarAsync(int id) // Elimina un usuario por su ID
        {
            var usuario = await _context.Users.FirstOrDefaultAsync(u => u.Id == id); // Busca el usuario por ID
            if (usuario != null) // Verifica si el usuario existe
            {
                _context.Users.Remove(usuario);
                await _context.SaveChangesAsync(); // Elimina el usuario del contexto y guarda los cambios
                return true;
            }
            return false;
        }
    }

}
