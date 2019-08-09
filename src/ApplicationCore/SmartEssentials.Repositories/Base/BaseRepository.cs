using PetaPoco.NetCore;
using SmartEssentials.Entities.Contracts;
using SmartEssentials.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SmartEssentials.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : new()
    {
        private string ConnectionString = String.Empty;

        public BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        private SqlConnection GetDBConn(string connStr)
        {
            return new SqlConnection(connStr);
        }

        public DBTransactionResult<T> Insert(T obj)
        {
            return UsingDBTransact<DBTransactionResult<T>>((db) =>
            {
                T dbObj = (T)db.Insert(obj);
                DBTransactionResult<T> dbTranResult = new DBTransactionResult<T>
                {
                    Obj = dbObj,
                    IsTransactionSuccess = ReflectionHelper.CheckPrimaryKeyHasValue<T>(dbObj)
                };
                return dbTranResult;
            });
        }

        public DBTransactionResult<T> Update(T obj)
        {
            return UsingDBTransact<DBTransactionResult<T>>((db) =>
            {
                int rtn = db.Update(obj, ReflectionHelper.GetPrimaryKeyValue<T>(obj));
                DBTransactionResult<T> dbTranResult = new DBTransactionResult<T>
                {
                    Obj = obj,
                    IsTransactionSuccess = rtn > 0
                };
                return dbTranResult;
            });
        }

        public T Get(string column, string value)
        {
            T newObj = new T();
            using (Database db = new Database(GetDBConn(ConnectionString)))
            {

            }
            return newObj;
        }

        public bool Delete(string column, string value)
        {
            bool rtn = true;
            using (Database db = new Database(GetDBConn(ConnectionString)))
            {

            }
            return rtn;
        }

        public T Activate(bool value)
        {
            T newObj = new T();
            using (Database db = new Database(GetDBConn(ConnectionString)))
            {

            }
            return newObj;
        }

        public IList<T> GetAll()
        {
            IList<T> lst = null;
            using (Database db = new Database(GetDBConn(ConnectionString)))
            {

            }
            return lst;
        }

        public PagedResult<T> Search(string sql)
        {
            PagedResult<T> lst = null;
            using (Database db = new Database(GetDBConn(ConnectionString)))
            {

            }
            return lst;
        }

        public dynamic ExecuteSQL(string sql)
        {
            dynamic rtn = null;
            using (Database db = new Database(GetDBConn(ConnectionString)))
            {

            }
            return rtn;
        }

        public dynamic ExecuteStoredProcedure(string storedProcedure, params object[] args)
        {
            dynamic rtn = null;
            using (Database db = new Database(GetDBConn(ConnectionString)))
            {

            }
            return rtn;
        }

        private RT UsingDBTransact<RT>(Func<Database, RT> call) where RT : new()
        {
            RT obj = new RT();
            using (Database db = new Database(GetDBConn(ConnectionString)))
            {
                using (var transaction = db.GetTransaction())
                {
                    // Some transactional DB work
                    obj = call(db);

                    transaction.Complete();
                }
            }
            return obj;
        }

        private RT UsingDB<RT>(Func<Database, RT> call) where RT : new()
        {
            RT obj = new RT();
            using (Database db = new Database(GetDBConn(ConnectionString)))
            {
                obj = call(db);
            }
            return obj;
        }
    }
}
