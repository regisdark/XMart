//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Modelo
{
    using System;
    using System.Collections.Generic;
    
    public partial class PRODUCTO
    {
        public string ID { get; set; }
        public string DESCRIPCION { get; set; }
        public decimal PRECIO { get; set; }
        public int ID_DEPARTAMENTO { get; set; }
        public bool ESTATUS { get; set; }
    
        public virtual DEPARTAMENTO DEPARTAMENTO { get; set; }
    }
}
