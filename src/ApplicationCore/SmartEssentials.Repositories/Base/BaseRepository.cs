using System;
using System.Threading.Tasks;

namespace SmartEssentials.Repositories
{
    public class BaseRepository<T>
    {
        public string ConnectionString = String.Empty;

        public BaseRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Insert()
        {

        } 

        public void Delete()
        {

        }

        public void Update()
        {

        }

        public void Get()
        {

        }

        public void GetAll()
        {

        }
    }
}
