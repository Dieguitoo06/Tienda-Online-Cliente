
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca;

[Table("Producto")]
public class Producto
{   
    [Key]
    [Required]
    public int idProducto { get; set; }

    [Required]
    public string Nombre { get; set;}

    [Required]
    [StringLength(50)]
    public string Descripcion { get; set;}

    [Required]
    public decimal PrecioUnitario { get; set;}


    public required Categoria Categoria { get; set; }

    [Required]
    public int Stock { get; set; }
}
