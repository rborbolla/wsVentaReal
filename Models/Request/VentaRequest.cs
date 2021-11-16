using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wsVentaReal.Models.Request
{
    public class VentaRequest
    {
        public int IdCliente { get; set; }
        public decimal Total { get; set; }

        public List<Concepto> Concepto { get; set; }

        public VentaRequest()
        {
            this.Concepto = new List<Concepto>();
        }
    }

    public class Concepto
    {
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Importe { get; set; }
        public int IdProducto { get; set; }
    }
}
