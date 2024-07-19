namespace MiIngresoHitss.Models
{
    public class ProductoListaPrecio
    {
        public int ProductoID { get; set; }
        public int ListaPrecioID { get; set; }
        public decimal Precio { get; set; }

        public Producto Producto { get; set; }
        public ListaPrecio ListaPrecio { get; set; }
    }
}
