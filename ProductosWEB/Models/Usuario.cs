using System;

namespace ProductosWEB.Models;

public class Usuario
{
    
            public int Id { get; set; } // Clave primaria
            public string nombre { get; set; } // Nombre del usuario
            public string apellido { get; set; } // Apellido del usuario
            public string email { get; set; } // Correo electrónico del usuario
            public string telefono { get; set; } // Teléfono del usuario (opcional)
            public string direccion { get; set; } // Dirección del usuario (opcional)
        
}
