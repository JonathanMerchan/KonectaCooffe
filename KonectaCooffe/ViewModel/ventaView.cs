using System.ComponentModel.DataAnnotations;

namespace KonectaCooffe.ViewModel
{
    public class ventaView
    {

        public int id_venta { get; set; }
        public int id_producto { get; set; }
        public string Producto_nombre { get; set; }
        public string Precio_Producto { get; set; }
        public int Cantidad { get; set; }
        public int Valor { get; set; }

    }
}
