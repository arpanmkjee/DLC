
using Microsoft.Extensions.Options;
using PetaPoco.NetCore;
using SmartEssentials.Entities.Contracts;
using SmartEssentials.Infrastructure.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SmartEssentials.Repositories.Base
{
    public class FullBaseRepository<T> : IFullBaseRepository<T> where T : new()
    {
        protected AppSettings _appSettings;
        protected IClientContext _clientContext { get; set; }

        public FullBaseRepository(IOptions<AppSettings> appSettings,
                              IClientContext clientContext)
        {
            _appSettings = appSettings.Value;
            _clientContext = clientContext;
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

        public T Get(object primaryKeyValue)
        {
            return UsingDB<T>((db) =>
            {
                T dbObj = db.Single<T>(primaryKeyValue);
                return dbObj;
            });
        }

        public bool Delete(object primaryKeyValue)
        {
            return UsingDB<bool>((db) =>
            {
                int rtn = db.Delete<T>(primaryKeyValue);
                return rtn > 0;
            });
        }

        public bool Activate<AT>(object primaryKeyValue, bool value) where AT:IActivator
        {
            return UsingDB<bool>((db) =>
            {
                AT dbObj = db.Single<AT>(primaryKeyValue);
                dbObj.Active = value;
                int rtn = db.Update(dbObj, new List<string> { "Active" });
                return rtn > 0;
            });
        }

        public PagedResult<T> GetAll(PagingRequest pagingRequest)
        {
            return UsingDB<PagedResult<T>>((db) =>
            {
                string sqlCount = "SELECT COUNT(1) FROM " + typeof(T).Name + " WHERE TenantID='" + _clientContext.TenantID;

                int recordCount = db.ExecuteScalar<int>(sqlCount);

                Sql sql = Sql.Builder.Where("TenantID = @0", _clientContext.TenantID);

                // Assumes EnableAutoSelect is true
                List<T> records = (List<T>)db.SkipTake<T>((pagingRequest.PageNo-1) * pagingRequest.PageSize, pagingRequest.PageSize, sql);

                PagedResult<T> lstPagedResults = new PagedResult<T>
                {
                    Results = records,
                    CurrentPage = pagingRequest.PageNo,
                    PageSize = pagingRequest.PageSize,
                    TotalCount = recordCount
                };
                return lstPagedResults;
            });
        }

        public PagedResult<T> Search(string whereSql, PagingRequest pagingRequest)
        {
            return UsingDB<PagedResult<T>>((db) =>
            {
                string sqlCount = "SELECT COUNT(1) FROM " + typeof(T).Name + " WHERE TenantID='" + db.EscapeSqlIdentifier(_clientContext.TenantID.ToString())+" AND ("+db.EscapeSqlIdentifier(whereSql)+")";

                int recordCount = db.ExecuteScalar<int>(sqlCount);

                Sql sql = Sql.Builder.Where("TenantID = @0 AND ( @1 )", db.EscapeSqlIdentifier(_clientContext.TenantID.ToString()), db.EscapeSqlIdentifier(whereSql));

                // Assumes EnableAutoSelect is true
                List<T> records = (List<T>)db.SkipTake<T>((pagingRequest.PageNo - 1) * pagingRequest.PageSize, pagingRequest.PageSize, sql);

                PagedResult<T> lstPagedResults = new PagedResult<T>
                {
                    Results = records,
                    CurrentPage = pagingRequest.PageNo,
                    PageSize = pagingRequest.PageSize,
                    TotalCount = recordCount
                };
                return lstPagedResults;
            });
        }

        public dynamic ExecuteSQL(string sql)
        {
            dynamic rtn = null;
            using (Database db = new Database(GetDBConn(_appSettings.ConnectionString)))
            {

            }
            return rtn;
        }

        public dynamic ExecuteStoredProcedure(string storedProcedure, params object[] args)
        {
            dynamic rtn = null;
            using (Database db = new Database(GetDBConn(_appSettings.ConnectionString)))
            {

            }
            return rtn;
        }

        protected RT UsingDBTransact<RT>(Func<Database, RT> call) where RT : new()
        {
            RT obj = new RT();
            using (Database db = new Database(GetDBConn(_appSettings.ConnectionString)))
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

        protected RT UsingDB<RT>(Func<Database, RT> call) where RT : new()
        {
            RT obj = new RT();
            using (Database db = new Database(GetDBConn(_appSettings.ConnectionString)))
            {
                obj = call(db);
            }
            return obj;
        }
    }
}
