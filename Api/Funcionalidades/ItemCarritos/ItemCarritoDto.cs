using Biblioteca;

namespace Api.Funcionalidades.ItemCarritos;

// Lectura
public class ItemCarritoQueryDto
{
    public int idItemCarrito { get; set; }
    public int Cantidad { get; set; }
    public int idProducto { get; set; }
    public int NroCarrito { get; set; }
    public decimal Subtotal { get; set; }
}

// Escritura
public class ItemCarritoCommandDto
{
    public int Cantidad { get; set; }
    public int idProducto { get; set; }
    public int NroCarrito { get; set; }
}

