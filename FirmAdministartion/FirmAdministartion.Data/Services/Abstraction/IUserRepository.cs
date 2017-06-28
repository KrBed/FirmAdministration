using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FirmAdministartion.Data.Services.Abstraction
{
    public interface IUserRepository<T> where T : class 
    { 
        IEnumerable<T> GetAll();
        IEnumerable<T> FindBy(Expression<Func<T,bool>>predicate );
        T GetSingle(string id);
        void Add(T entity);
        void Delete(T entity);
        void Edit(T entity);
    }
}
