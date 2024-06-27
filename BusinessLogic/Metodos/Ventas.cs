using BusinessLogic.Clases_Personalizadas;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;

namespace BusinessLogic.Metodos
{
    public class Ventas : ManejadorModelo<VENTA>
    {
        public bool GuardarVenta(Clases_Personalizadas.Venta _v, string _usuario)
        {
            try
            {
                var Contexto = GetContext;
                using (var _transaccion = Contexto.Database.BeginTransaction())
                {
                    //calculos base para la entidad: Venta
                    int _cantidadProductos = 0;
                    decimal _importeTotal = decimal.Zero;

                    //obtener usuario
                    var _u = Contexto.USUARIO.FirstOrDefault(a => a.USUARIO1 == _usuario);
                    if (_u == null)
                        return false;

                    //crear entidad: venta
                    var _venta = Contexto.VENTA.Add(new VENTA()
                    {
                        ESTATUS = _v.ESTATUS,
                        ID_USUARIO = _u.ID,
                        FECHA = _v.FECHA,
                        ID = Guid.NewGuid().ToString(),
                    });

                    //crea entidad: sub-venta
                    if (_v.SUB_VENTAS.Any())
                        foreach (var item in _v.SUB_VENTAS)
                        {
                            var _precioProducto = GetContext.PRODUCTO.FirstOrDefault(d => d.ID == item.ID_PRODUCTO);
                            _cantidadProductos += (int)item.CANTIDAD;
                            _importeTotal += _precioProducto != null ? (_precioProducto.PRECIO * item.CANTIDAD) : 0;
                            GetContext.SUB_VENTA.Add(new SUB_VENTA()
                            {
                                CANTIDAD = item.CANTIDAD,
                                ESTATUS = item.ESTATUS,
                                ID = Guid.NewGuid().ToString(),
                                ID_PRODUCTO = item.ID_PRODUCTO,
                                IMPORTE = _precioProducto != null ? (_precioProducto.PRECIO * item.CANTIDAD) : 0,
                                ID_VENTA = _venta.ID
                            });
                        }

                    _venta.CANT_PRODUCTOS = _cantidadProductos;
                    _venta.IMPORTE_TOTAL = _importeTotal;

                    Contexto.SaveChanges();
                    _transaccion.Commit();
                }

                return true;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<GeneradoresData.ListadoOperacionesAutomaticas> GenerarOperaciones(int _cantidad)
        {
            try
            {
                List<GeneradoresData.ListadoOperacionesAutomaticas> lista = new List<GeneradoresData.ListadoOperacionesAutomaticas>();
                var _productos = (from _a in GetContext.PRODUCTO where _a.ESTATUS select new { id = _a.ID, producto = _a.DESCRIPCION }).ToList();
                Random _r = new Random();
                for (int i = 0; i < _cantidad; i++)
                {
                    var _indice = _r.Next(_productos.Count());
                    var elemento = _productos.ElementAt(_indice);
                    lista.Add(new GeneradoresData.ListadoOperacionesAutomaticas() { ID_PRODUCTO = elemento.id, PRODUCTO = elemento.producto, CANTIDAD = _r.Next(1, 50) });
                }

                return lista;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
