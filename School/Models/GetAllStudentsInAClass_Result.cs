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
    
    public partial class GetAllStudentsInAClass_Result
    {
        public int id_student { get; set; }
        public Nullable<bool> is_debtor { get; set; }
        public Nullable<double> annual_grade { get; set; }
        public Nullable<int> fk_class { get; set; }
        public int id_person { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
