using SmartEssentials.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartEssentials.Repositories.Base
{
    public interface IBaseRepository<T> where T : new()
    {
        void Initialize(string connectionString, ClientContext clientContext);
    }
}
