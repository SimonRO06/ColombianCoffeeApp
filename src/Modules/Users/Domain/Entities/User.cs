using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ColombianCoffeeApp.src.Modules.Users.Domain.Entities
{
    [Table("usuario")] // Atributo que indica el nombre de la tabla en la base de datos
    public class User
    {
        public int Id { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Contrasena { get; set; }
        public RolUsuario Rol { get; set; }
    }
}