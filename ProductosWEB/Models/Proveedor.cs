using System;

namespace ProductosWEB.Models;

public class Proveedor
{
    public int Id { get; set; }
    public string nombre { get; set; }
    public string apellido { get; set; }
    public string tipoDePersona { get; set; }
    public string dui { get; set; }
    public string nombreEmpresa { get; set; }
    public int Nrc { get; set; }
    public string contacto { get; set; }
    public string telefono { get; set; }
    public string direccion { get; set; }
}
