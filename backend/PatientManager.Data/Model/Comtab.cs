//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PatientManager.Data.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Comtab
    {
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public System.DateTime Date { get; set; }
        public string Mode { get; set; }
        [Required]
        public decimal Montant { get; set; }
        public string Type { get; set; }
        public Nullable<int> Patient_Id { get; set; }
    
        public virtual Patient Patient { get; set; }
    }
}
