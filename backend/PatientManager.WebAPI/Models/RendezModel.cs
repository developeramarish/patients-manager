using PatientManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManager.WebAPI.Models
{
    public class RendezModel
    {
        public int Id { get; set; }
        public System.DateTime Date { get; set; }
        public string Comment { get; set; }
        public int Patient_Id { get; set; }

        public virtual Patient Patient { get; set; }
    }
}