using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ProductosWEB.Models;

public class Prestamo
{
    public int Id { get; set; }
    public int usuario_Id { get; set; }
    public int articulo_Id { get; set; }
    public DateTime fecha_Prestamo { get; set; }
    public DateTime fecha_devolucion { get; set; }
    [BindNever]
    public string estado { get; set; } = "En Prestamo";
}