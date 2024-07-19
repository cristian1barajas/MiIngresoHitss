namespace MiIngresoHitss.Models
{
    public class ListaPrecio
    {
        public int ListaPrecioID { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public ICollection<ProductoListaPrecio> ProductoListaPrecios { get; set; }
    }
}
