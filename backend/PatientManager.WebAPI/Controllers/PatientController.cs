using PatientManager.WebAPI.Models;
using PatientManager.Data.Model;
using PatientManager.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PatientManager.WebAPI.Controllers
{
    public class PatientController : ApiController
    {
        private readonly IPatientService patientService;

        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [HttpGet]
        [Route("api/patient/count")]
        public long Count()
        {
            return patientService.GetCount();
        }

        [HttpGet]
        [Route("api/patient")]
        public IEnumerable<PatientModel> Get()
        {
            return patientService.GetPatient().Select(p => new PatientModel
            {
                Id = p.Id,
                Nom = p.Nom,
                Prenom = p.Prenom,
                Date_cre = p.Date_cre,
                CIN = p.CIN,
                Sexe = p.Sexe,
                Telephone = p.Telephone,
                Adresse = p.Adresse,
                Matricule_CNAM = p.Matricule_CNAM,
                Date_nais = p.Date_nais,
                Nom_fiche = p.Nom_fiche,
                Profession = p.Profession,
                Comtab = p.Comtab,
                Rendez = p.Rendez
            });
        }

        [HttpGet]
        [Route("api/patient/{id}")]
        public PatientModel Get(int id)
        {
            Patient p = patientService.GetPatient(id);
            PatientModel pm = new PatientModel();
            pm.Id = p.Id;
            pm.Nom = p.Nom;
            pm.Prenom = p.Prenom;
            pm.Date_cre = p.Date_cre;
            pm.CIN = p.CIN;
            pm.Sexe = p.Sexe;
            pm.Telephone = p.Telephone;
            pm.Adresse = p.Adresse;
            pm.Matricule_CNAM = p.Matricule_CNAM;
            pm.Date_nais = p.Date_nais;
            pm.Nom_fiche = p.Nom_fiche;
            pm.Profession = p.Profession;
            pm.Comtab = p.Comtab;
            pm.Rendez = p.Rendez;
            return pm;

        }

        [Route("api/patient/delete/{id}")]
        [HttpGet]
        public void Delete(int id)
        {
            patientService.DeletePatient(id);
        }

        [Route("api/patient/update")]
        [HttpPost]
        public void Update(PatientModel p)
        {
            Patient pm = new Patient();
            pm.Id = p.Id;
            pm.Nom = p.Nom;
            pm.Prenom = p.Prenom;
            pm.Date_cre = p.Date_cre;
            pm.CIN = p.CIN;
            pm.Sexe = p.Sexe;
            pm.Telephone = p.Telephone;
            pm.Adresse = p.Adresse;
            pm.Matricule_CNAM = p.Matricule_CNAM;
            pm.Date_nais = p.Date_nais;
            pm.Nom_fiche = p.Nom_fiche;
            pm.Profession = p.Profession;
            pm.Comtab = p.Comtab;
            pm.Rendez = p.Rendez;
            patientService.UpdatePatient(pm);
        }

        [Route("api/patient/create")]
        [HttpPost]
        public void Create(PatientModel p)
        {
            Patient pm = new Patient();
            pm.Id = p.Id;
            pm.Nom = p.Nom;
            pm.Prenom = p.Prenom;
            pm.Date_cre = p.Date_cre;
            pm.CIN = p.CIN;
            pm.Sexe = p.Sexe;
            pm.Telephone = p.Telephone;
            pm.Adresse = p.Adresse;
            pm.Matricule_CNAM = p.Matricule_CNAM;
            pm.Date_nais = p.Date_nais;
            pm.Nom_fiche = p.Nom_fiche;
            pm.Profession = p.Profession;
            pm.Comtab = p.Comtab;
            pm.Rendez = p.Rendez;
            patientService.AddPatient(pm);
        }
    }
}

   
