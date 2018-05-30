using PatientManager.Data;
using PatientManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Service
{
    public class PatientService:IPatientService
    {
        private I_RepositoryCRUD<Patient> PatientRepos;

        public PatientService(I_RepositoryCRUD<Patient> PatientRepos)
        {
            this.PatientRepos = PatientRepos;
        }

        public long GetCount()
        {
            return PatientRepos.count();
        }

        public IQueryable<Patient> GetPatient()
        {
            return PatientRepos.Table;
        }

        public Patient GetPatient(int id)
        {
            return PatientRepos.find(id);
        }

        public void AddPatient(Patient Patient)
        {
            PatientRepos.Insert(Patient);
        }

        public void UpdatePatient(Patient Patient)
        {
            PatientRepos.update(Patient);
        }

        public void DeletePatient(int id)
        {
            PatientRepos.Delete(id);
        }
    }
}
