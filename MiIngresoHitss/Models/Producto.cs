﻿namespace MiIngresoHitss.Models
{
    public class Producto
    {
        public int ProductoID { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        public ICollection<ProductoListaPrecio> ProductoListaPrecios { get; set; }
    }
}
