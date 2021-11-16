using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using wsVentaReal.Models;
using wsVentaReal.Models.Request;

namespace wsVentaReal.Services
{
    public class VentaService: IVentaService
    {
        public void Add(VentaRequest model)
        {
            using (VentaRealContext db = new VentaRealContext())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var venta = new Venta();
                        venta.Total = model.Concepto.Sum(d => d.Cantidad * d.PrecioUnitario);
                        venta.Fecha = DateTime.Now;
                        venta.IdCliente = model.IdCliente;
                        db.Venta.Add(venta);
                        db.SaveChanges();

                        foreach (var modelConcepto in model.Concepto)
                        {
                            Models.Concepto concepto = new Models.Concepto();
                            concepto.Cantidad = modelConcepto.Cantidad;
                            concepto.IdProducto = modelConcepto.IdProducto;
                            concepto.PrecioUnitario = modelConcepto.PrecioUnitario;
                            concepto.Importe = modelConcepto.Importe;
                            concepto.IdVenta = venta.Id;
                            db.Concepto.Add(concepto);
                            db.SaveChanges();
                        }
                        transaction.Commit();
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw new Exception("Ocurrió un error en la inser´ción");
                    }
                }
            }
        }
    }
}
