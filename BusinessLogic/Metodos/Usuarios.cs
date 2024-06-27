using Modelo;
using System;
using System.Linq;

namespace BusinessLogic.Metodos
{
    public class Usuarios : ManejadorModelo<USUARIO>
    {
        public int? ObtenerUsuario(string _usuario, string _semilla)
        {
			try
			{
                var _registro = GetContext.USUARIO.FirstOrDefault(d => d.USUARIO1 == _usuario && d.CONTRASENIA == _semilla);
                if (_registro != null)
                    return _registro.ID_TIPO;

                return null;
            }
			catch (Exception exc)
			{
				throw exc;
			}
        }
    }
}
