using SmartEssentials.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEssentials.Repositories.Base
{
    public interface IBaseRepository<T> where T : new()
    {
        DBTransactionResult<T> Insert(T obj);
        DBTransactionResult<T> Update(T obj);
        T Get(string column, string value);
        T Activate(bool value);
        bool Delete(string column, string value);
        IList<T> GetAll();
        PagedResult<T> Search(string sql);
        dynamic ExecuteSQL(string sql);
        dynamic ExecuteStoredProcedure(string storedProcedure, params object[] args);
    }
}
