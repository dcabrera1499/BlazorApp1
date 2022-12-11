using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Shared
{
    public  class Usuario
    {
        [Key]
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Telefono { get; set; } = null!;

        public DateTime FechaAlta { get; set; }

        public DateTime? FechaBaja { get; set; }
    }
}


