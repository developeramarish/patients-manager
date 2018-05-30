using PatientManager.Data;
using PatientManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Service
{
    public class RendezvousService:IRendezvousService
    {
        private I_RepositoryCRUD<Rendez> RendezRepos;

        public RendezvousService(I_RepositoryCRUD<Rendez> RendezRepos)
        {
            this.RendezRepos = RendezRepos;
        }

        public long GetCount()
        {
            return RendezRepos.count();
        }

        public IQueryable<Rendez> GetRendezvous()
        {
            return RendezRepos.Table;
        }

        public Rendez GetRendezvous(int id)
        {
            return RendezRepos.find(id);
        }

        public void AddRendezvous(Rendez Rendezvous)
        {
            RendezRepos.Insert(Rendezvous);
        }

        public void UpdateRendezvous(Rendez Rendezvous)
        {
            RendezRepos.update(Rendezvous);
        }

        public void DeleteRendezvous(int id)
        {
            RendezRepos.Delete(id);
        }
    }
}
