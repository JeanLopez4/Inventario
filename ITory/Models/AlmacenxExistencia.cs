//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ITory.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class AlmacenxExistencia
    {
        public int idAlmacen { get; set; }
        public int idArticulo { get; set; }
        public string Cantidad { get; set; }
    
        public virtual Almacen Almacen { get; set; }
        public virtual Articulo Articulo { get; set; }
    }
}
