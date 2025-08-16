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
            _context = context;
        }

        public async Task<User?> ObtenerPorCredencialesAsync(string nombreUsuario, string contrasena)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario && u.Contrasena == contrasena);
        }

        public async Task CrearAsync(User usuario)
        {
            // _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> ObtenerPorNombreAsync(string nombreUsuario)
        {
            return await _context.Users
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario);
        }

        public async Task<List<User>> ListarTodosAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var usuario = await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (usuario != null)
            {
                _context.Users.Remove(usuario);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }

}
