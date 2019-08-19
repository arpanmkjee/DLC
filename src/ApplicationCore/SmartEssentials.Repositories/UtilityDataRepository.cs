using SmartEssentials.Entities.Contracts;
using SmartEssentials.Entities.Core;
using SmartEssentials.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEssentials.Repositories
{
    public class UtilityDataRepository : BaseRepository<Utility>
    {
        public UtilityDataRepository(string connectionString, ClientContext clientContext) : base(connectionString, clientContext)
        {
            _connectionString = connectionString;
            _clientContext = clientContext;
        }
    }
}
