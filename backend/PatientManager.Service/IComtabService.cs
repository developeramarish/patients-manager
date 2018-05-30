using PatientManager.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientManager.Service
{
    public interface IComtabService
    {
        long GetCount();
        IQueryable<Comtab> GetComtab();
        Comtab GetComtab(int id);
        void AddComtab(Comtab Comtab);
        void UpdateComtab(Comtab Comtab);
        void DeleteComtab(int id);
    }
}
