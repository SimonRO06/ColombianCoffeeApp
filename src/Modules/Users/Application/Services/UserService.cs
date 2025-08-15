using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ColombianCoffeeApp.src.Modules.Users.Application.Interfaces;
using ColombianCoffeeApp.src.Modules.Users.Domain;
using ColombianCoffeeApp.src.Modules.Users.Domain.Entities;

namespace ColombianCoffeeApp.src.Modules.Users.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repo;

        public UserService(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<Usuario?> LoginAsync(string nombreUsuario, string contrasena)
        {
            return await _repo.ObtenerPorCredencialesAsync(nombreUsuario, contrasena);
        }

        public async Task RegistrarAdminAsync(string nombreUsuario, string contrasena)
        {
            var existente = await _repo.ObtenerPorNombreAsync(nombreUsuario);
            if (existente != null)
            {
                Console.WriteLine("⚠️ Ya existe un usuario con ese nombre.");
                return;
            }

            var admin = new Usuario
            {
                NombreUsuario = nombreUsuario,
                Contrasena = contrasena,
                Rol = RolUsuario.Administrador
            };

            await _repo.CrearAsync(admin);
        }

        public async Task CrearUsuarioAsync(string nombreUsuario, string contrasena, string rolTexto)
        {
            var existente = await _repo.ObtenerPorNombreAsync(nombreUsuario);
            if (existente != null)
            {
                Console.WriteLine("⚠️ Ya existe un usuario con ese nombre.");
                return;
            }

            RolUsuario rol;
            bool esValido = Enum.TryParse(rolTexto, true, out rol) 
                            && Enum.IsDefined(typeof(RolUsuario), rol);

            if (!esValido)
            {
                Console.WriteLine("⚠️ Rol inválido. Se asignará 'Usuario' por defecto.");
                rol = RolUsuario.Usuario;
            }

            var usuario = new Usuario
            {
                NombreUsuario = nombreUsuario,
                Contrasena = contrasena,
                Rol = rol
            };

            await _repo.CrearAsync(usuario);
            Console.WriteLine("✅ Usuario creado correctamente.");
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return await _repo.ListarTodosAsync();
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _repo.EliminarAsync(id);
        }

        public async Task<Usuario?> ObtenerPorNombreAsync(string nombreUsuario)
        {
            return await _repo.ObtenerPorNombreAsync(nombreUsuario);
        }

    }
}