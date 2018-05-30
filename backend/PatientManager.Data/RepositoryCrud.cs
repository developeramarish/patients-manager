using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PatientManager.Data.Model
{
    public class RepositoryCrud <T> :I_RepositoryCRUD<T> where T:class
    {
        private medicalEntities db;
        private DbSet<T> table;

        public RepositoryCrud()
        {
            db = new medicalEntities();
            table = db.Set<T>();
        }

        public IEnumerable<T> findAll()
        {
            return table.ToList();
        }

        public long count()
        {
            return table.Count();
        }

        public T find(object id)
        {
            return table.Find(id);
        }

        public void Insert(T obj)
        {
            table.Add(obj);
            db.SaveChanges();
        }
        public void Delete(object id)
        {
            T t = table.Find(id);
            table.Remove(t);
            db.SaveChanges();
        }
        public void update(T obj)
        {
            table.Attach(obj);
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
        
        public IQueryable<T> Table
        {
            get
            {
                return this.table;
            }
        }

    }
}