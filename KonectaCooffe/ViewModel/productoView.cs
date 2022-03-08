using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KonectaCooffe.ViewModel
{
    public class productoView
    {
      
        public int id { get; set; }
         public string Nombre { get; set; }
        public string Referencia { get; set; }
        public int Precio { get; set; }
        public int Peso { get; set; }
         public string Categoria { get; set; }
        public int Stock { get; set; }
        public DateTime Fecha { get; set; }

     }
}
