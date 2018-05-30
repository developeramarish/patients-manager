using PatientManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PatientManager.WebAPI.Models
{
    public class PatientModel
    {
        public PatientModel()
        {
            this.Comtab = new HashSet<Comtab>();
            this.Rendez = new HashSet<Rendez>();
        }
    
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public System.DateTime Date_cre { get; set; }
        public Nullable<decimal> CIN { get; set; }
        public string Sexe { get; set; }
        public Nullable<decimal> Telephone { get; set; }
        public string Adresse { get; set; }
        public Nullable<decimal> Matricule_CNAM { get; set; }
        public Nullable<System.DateTime> Date_nais { get; set; }
        public string Nom_fiche { get; set; }
        public string Profession { get; set; }
    
        public virtual ICollection<Comtab> Comtab { get; set; }
        public virtual ICollection<Rendez> Rendez { get; set; }
    }
}