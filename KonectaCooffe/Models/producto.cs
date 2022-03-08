using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KonectaCooffe.Models
{
    public class producto
    {
        [Key]
        public int productoid { get; set; }

        [Required(ErrorMessage = "El Nombre del producto es obligatorio")]
        [Display(Name = "Nombre Producto")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "La referencia del producto es obligatorio")]
        [Display(Name = "Referencia")]
        public string Referencia { get; set; }

        [Required(ErrorMessage = "El Precio del producto es obligatorio (COP)")]
        [Display(Name = "Precio   ")]
        public int Precio { get; set; }

        [Required(ErrorMessage = "El Peso del producto es obligatorio")]
        [Display(Name = "Peso (Kg)")]
        public int Peso { get; set; }

        [Required(ErrorMessage = "La categoria del producto es obligatorio")]
        [Display(Name = "Categoria")]
        public string Categoria { get; set; }

        [Required(ErrorMessage = "La cantidad de productos es obligatorio")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }

        [Required(ErrorMessage = "La fecha de registro es obligatorio")]
        [Display(Name = "Fecha de Registro")]
        public DateTime Fecha { get; set; }

        public ICollection<venta> Lventa { get; set; }
    }
}
