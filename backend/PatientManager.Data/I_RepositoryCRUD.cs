using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace PatientManager.Data.Model
{
    public interface I_RepositoryCRUD<T> where T : class
    {
        IQueryable<T> Table { get; }
        IEnumerable<T> findAll();
       
        void Insert(T obj);
        void Delete(object T);
        
        void update ( T obj);

        long count();

        T find(object T);

    }
}

