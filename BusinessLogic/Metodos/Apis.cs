using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Metodos
{
    public class Apis : ManejadorModelo<VENTA>
    {
        public IQueryable<object> ObtenerVentasSimple()
        {
			try
			{
                return GetContext.VENTA.Where(x => x.ESTATUS).Select(w => new
                {
                    w.ID,
                    w.CANT_PRODUCTOS,
                    w.IMPORTE_TOTAL
                });
            }
			catch (Exception exc)
			{
				throw exc;
			}
        }
    }
}
