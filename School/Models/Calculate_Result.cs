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
    
    public partial class Calculate_Result
    {
        public int id_situation { get; set; }
        public bool is_debtor { get; set; }
        public bool is_situation_complete { get; set; }
        public int final_grade { get; set; }
        public int fk_student { get; set; }
        public int fk_teacher_subject { get; set; }
    }
}
