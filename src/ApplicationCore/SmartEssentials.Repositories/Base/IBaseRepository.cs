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
        T Get(object primaryKeyValue);
        bool Activate<AT>(object primaryKeyValue, bool value) where AT : IActivator;
        bool Delete(object primaryKeyValue);
        PagedResult<T> GetAll(PagingRequest pagingRequest);
        PagedResult<T> Search(string sql);
        dynamic ExecuteSQL(string sql);
        dynamic ExecuteStoredProcedure(string storedProcedure, params object[] args);
    }
}
