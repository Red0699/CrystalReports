//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CrystalReports.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class productos
    {
        public int productId { get; set; }
        public string nombre { get; set; }
        public Nullable<double> precio { get; set; }
        public Nullable<int> existencia { get; set; }
        public Nullable<int> codcat { get; set; }
    
        public virtual categorias categorias { get; set; }
    }
}
