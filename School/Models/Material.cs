//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace School.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Material
    {
        public int id_material { get; set; }
        public string link { get; set; }
        public string type { get; set; }
        public int fk_assignment { get; set; }
    
        public virtual Assignment Assignment { get; set; }
    }
}