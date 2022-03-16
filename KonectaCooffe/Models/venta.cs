using System.ComponentModel.DataAnnotations;

namespace KonectaCooffe.Models
{
    public class venta
    {
        [Key]
        public int id_venta { get; set; }
        [Required(ErrorMessage = "Debe indicar un producto")]
        [Display(Name = "Elija el producto a Vender")]

        public int id_producto { get; set; }
        [Required(ErrorMessage = "Debe indicar la cantidad de producto Vendidos")]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
        [Required]
        [Display(Name = "Valor Total")]
        public int Valor { get; set; }

        public producto producto { get; set; }
        public int productoid { get;set;}
     }
}
