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
    
    public partial class Transaccion
    {
        public int idTransaccion { get; set; }
        public string Tipo { get; set; }
        public int idArticulo { get; set; }
        public System.DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        public decimal Monto { get; set; }
        public bool Estado { get; set; }
        public Nullable<int> idAsiento { get; set; }
        public string cuentaDB { get; set; }
        public string cuentaCD { get; set; }
    
        public virtual Articulo Articulo { get; set; }
    }
}