namespace MiIngresoHitss.Models
{
    public class CarritoItem
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get { return Cantidad * Precio; } }
    }

}
