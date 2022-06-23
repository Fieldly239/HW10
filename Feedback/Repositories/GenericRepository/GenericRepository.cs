using Dapper;
using Microsoft.Data.SqlClient;

namespace Feedback.Repositories.GenericRepository
{
    public abstract class GenericRepository<T>
    {
        private readonly IConfiguration _configuration;
        protected readonly string connectionStrings = "";
        public GenericRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionStrings = _configuration.GetSection("ConnectionStrings:ConnectionString").Value;
        }

        public IEnumerable<T> GetAll()
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var className = typeof(T).Name;
                var sqlCommand = $"SELECT * FROM {className}";
                return db.Query<T>(sqlCommand).ToList();
            }
        }

        public T GetById(int id)
        {
            using (var db = new SqlConnection(connectionStrings))
            {
                var className = typeof(T).Name;
                var sqlCommand = $"SELECT * FROM {className} WHERE [Id] = @Id";
                return db.Query<T>(sqlCommand,new { Id = id}).FirstOrDefault();
            }
        }

        public abstract int Add(T model);
        public abstract int Update(T model);
        public abstract int Delete(int id);
    }
}
