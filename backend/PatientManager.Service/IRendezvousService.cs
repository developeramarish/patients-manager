using PatientManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Service
{
    public interface IRendezvousService
    {
        long GetCount();
        IQueryable<Rendez> GetRendezvous();
        Rendez GetRendezvous(int id);
        void AddRendezvous(Rendez Rendezvous);
        void UpdateRendezvous(Rendez Rendezvous);
        void DeleteRendezvous(int id);
    }
}
