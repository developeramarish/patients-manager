using PatientManager.Data;
using PatientManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Service
{
    public class ComtabService:IComtabService
    {
        private I_RepositoryCRUD<Comtab> ComtabRepos;

        public ComtabService(I_RepositoryCRUD<Comtab> ComtabRepos)
        {
            this.ComtabRepos = ComtabRepos;
        }

        public long GetCount()
        {
            return ComtabRepos.count();
        }

        public IQueryable<Comtab> GetComtab()
        {
            return ComtabRepos.Table;
        }

        public Comtab GetComtab(int id)
        {
            return ComtabRepos.find(id);
        }

        public void AddComtab(Comtab Comtab)
        {
            ComtabRepos.Insert(Comtab);
        }

        public void UpdateComtab(Comtab Comtab)
        {
            ComtabRepos.update(Comtab);
        }

        public void DeleteComtab(int id)
        {
            ComtabRepos.Delete(id);
        }
    }
}
