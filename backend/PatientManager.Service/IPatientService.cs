using PatientManager.Data.Model;
using PatientManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Service
{
    public interface IPatientService
    {
        long GetCount();
        IQueryable<Patient> GetPatient();
        Patient GetPatient(int id);
        void AddPatient(Patient Patient);
        void UpdatePatient(Patient Patient);
        void DeletePatient(int id);
    }
}
