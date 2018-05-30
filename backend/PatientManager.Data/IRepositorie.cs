using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemCredit.Data
{
    public interface IRepositorie<Tentite> where Tentite:class
    {
        Tentite GetById(string TPk);
        //void Ajouter(Tentite t);
        //void Modifier(Tentite t);
        //void Supprimer(Tentite t);
        IQueryable<Tentite> Table { get; }
    }
}
