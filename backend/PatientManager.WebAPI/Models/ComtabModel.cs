using PatientManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManager.WebAPI.Models
{
    public class ComtabModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public System.DateTime Date { get; set; }
        public string Mode { get; set; }
        public decimal Montant { get; set; }
        public string Type { get; set; }
        public Nullable<int> Patient_Id { get; set; }

        public virtual Patient Patient { get; set; }
    }
}