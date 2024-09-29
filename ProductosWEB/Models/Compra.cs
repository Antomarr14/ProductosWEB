using System;

namespace ProductosWEB.Models;

public class Compra
{
    public int Id { get; set; }
    public string numerodeFactura { get; set; }
    public DateTime fecha { get; set; }
    public decimal precioUnitario { get; set; }
    public int cantidad { get; set; }

    
    public decimal subTotal { get; private set; } 
    public decimal iva { get; private set; } 
    public decimal total { get; private set; }
    
    public int idProveedor {get; set;} 

    
    public void CalcularTotales()
    {
        subTotal = precioUnitario * cantidad;
        const decimal IVA_RATE = 0.13m; 
        iva = subTotal * IVA_RATE;
        total = subTotal + iva;
    }
}
