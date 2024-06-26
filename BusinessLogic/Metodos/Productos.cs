using BusinessLogic.Clases_Personalizadas;
using Modelo;
using System;
namespace BusinessLogic.Metodos 
{
    public class Productos : ManejadorModelo<Producto>
    {
        public bool GuardarProducto(Producto producto)
        {
			try
			{
                GetContext.PRODUCTO.Add(new PRODUCTO ()
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
    }
}
