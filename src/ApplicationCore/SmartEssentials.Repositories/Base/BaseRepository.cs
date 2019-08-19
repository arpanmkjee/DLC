
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
        protected string _connectionString = String.Empty;
        protected ClientContext _clientContext { get; set; }

        public BaseRepository(string connectionString, ClientContext clientContext)
        {
            _connectionString = connectionString;
            _clientContext = clientContext;
        }

        private SqlConnection GetDBConn(string connStr)
        {
            return new SqlConnection(connStr);
        }

        public void Initialize(string connectionString, ClientContext clientContext)
        {
            _connectionString = connectionString;
            _clientContext = clientContext;
        }

        protected dynamic ExecuteSQL(string sql)
        {
            dynamic rtn = null;
            using (Database db = new Database(GetDBConn(_connectionString)))
            {

            }
            return rtn;
        }

        protected dynamic ExecuteStoredProcedure(string storedProcedure, params object[] args)
        {
            dynamic rtn = null;
            using (Database db = new Database(GetDBConn(_connectionString)))
            {

            }
            return rtn;
        }

        protected RT UsingDBTransact<RT>(Func<Database, RT> call) where RT : new()
        {
            RT obj = new RT();
            using (Database db = new Database(GetDBConn(_connectionString)))
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
            using (Database db = new Database(GetDBConn(_connectionString)))
            {
                obj = call(db);
            }
            return obj;
        }
    }
}
