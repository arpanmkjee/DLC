
using Microsoft.Extensions.Options;
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
        protected AppSettings _appSettings;
        protected IClientContext _clientContext { get; set; }

        public BaseRepository(IOptions<AppSettings> appSettings, 
                              IClientContext clientContext)
        {
            _appSettings = appSettings.Value;
            _clientContext = clientContext;
        }

        private SqlConnection GetDBConn(string connStr)
        {
            return new SqlConnection(connStr);
        }

        protected dynamic ExecuteSQL(string sql)
        {
            dynamic rtn = null;
            using (Database db = new Database(GetDBConn(_appSettings.ConnectionString)))
            {

            }
            return rtn;
        }

        protected dynamic ExecuteStoredProcedure(string storedProcedure, params object[] args)
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
