using BusinessLogic.Clases_Personalizadas;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLogic.Metodos
{
    public class Productos : ManejadorModelo<Producto>
    {
        public bool GuardarProducto(Producto producto)
        {
            try
            {
                GetContext.PRODUCTO.Add(new PRODUCTO()
                {
                    ESTATUS = producto.ESTATUS,
                    DESCRIPCION = producto.DESCRIPCION,
                    ID_DEPARTAMENTO = producto.ID_DEPARTAMENTO,
                    PRECIO = producto.PRECIO,
                    ID = Guid.NewGuid().ToString()
                });

                GetContext.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public List<Producto> ObtenerProductos(int IdDepto)
        {
            try
            {
                return GetContext.PRODUCTO.Where(w => w.ID_DEPARTAMENTO == IdDepto).Select(s => new Producto
                {
                    ID = s.ID,
                    DESCRIPCION = s.DESCRIPCION,
                    ESTATUS = s.ESTATUS,
                    PRECIO = s.PRECIO
                }).ToList();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public Producto ObtenerProducto(string id)
        {
            try
            {
                var _elemento = GetContext.PRODUCTO.FirstOrDefault(d => d.ID == id);
                return _elemento == null ? new Producto() { } : new Producto() { ID = _elemento.ID, DESCRIPCION = _elemento.DESCRIPCION, ESTATUS = _elemento.ESTATUS, PRECIO = _elemento.PRECIO, ID_DEPARTAMENTO = _elemento.ID_DEPARTAMENTO };
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public bool EditarProducto(Producto producto)
        {
            try
            {
                if (GetContext.PRODUCTO.FirstOrDefault(d => d.ID == producto.ID) != null)
                {
                    var _registro = GetContext.PRODUCTO.FirstOrDefault(d => d.ID == producto.ID);
                    _registro.PRECIO = producto.PRECIO;
                    _registro.ID_DEPARTAMENTO = producto.ID_DEPARTAMENTO;
                    _registro.DESCRIPCION = producto.DESCRIPCION;
                    _registro.ESTATUS = producto.ESTATUS;
                }

                GetContext.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
    }
}
