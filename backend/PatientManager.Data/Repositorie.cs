using DemCredit.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemCredit.Data
{
    public class Repositorie<Tentite>:IRepositorie<Tentite> where Tentite:class
    {
        private readonly DemCreditEntities contextes;
        private IDbSet<Tentite> entites;

        public Repositorie(DemCreditEntities contx)
        {
            this.contextes = contx;
        }




        public Tentite GetById(string TPk)
        {
            return this.Entite.Find(TPk);
        }



        //public void Ajouter(Tentite t)
        //{
        //    throw new NotImplementedException();
        //}


        //public void Modifier(Tentite t)
        //{
        //    throw new NotImplementedException();
        //}


        //public void Supprimer(Tentite t)
        //{
        //    throw new NotImplementedException();
        //}


        public IQueryable<Tentite> Table
        {
            get
            {
                return this.Entite;
            }
        }



        private IDbSet<Tentite> Entite
        {
            get
            {
                if (entites == null)
                {
                    entites = contextes.Set<Tentite>();
                }
                return entites;
            }
        }
    }
}
