using BusinessLogic.Clases_Personalizadas;
using Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
namespace BusinessLogic.Metodos
{
    public class Departamentos : ManejadorModelo<Departamento>
    {
        public List<Departamento> ObtenerDeparamentosCombo()
        {
			try
            {
                return GetContext.DEPARTAMENTO.Where(x => x.ESTATUS).Select(x => new Departamento
                {
                    DESCRIPCION = x.DESCRIPCION,
                    ID = x.ID
                }).OrderBy(x => x.DESCRIPCION).ToList();

            }
			catch (Exception exc)
			{
				throw exc;
			}
        }
    }
}
