using Dapper;
using Feedback.Models;
using Feedback.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Repositories
{
    public class ApplicationsRepository : GenericRepository<Applications>, IApplicationsRepository
    {
        private readonly IConfiguration _configuration;
        public ApplicationsRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        public override int Add(Applications applications)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"INSERT INTO [Applications]
                                               ([ApplicationName]
                                               ,[Description])
                                         VALUES
                                               (@ApplicationName
                                               ,@Description)");
                return db.Execute(sqlCommand, ParameterMapping(applications));
            }
        }
        public override int Update(Applications applications)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"UPDATE [Applications]
                                           SET [ApplicationName] = @ApplicationName
                                              ,[Description] = @Description
                                         WHERE [Id] = @Id");
                return db.Execute(sqlCommand, ParameterMapping(applications));
            }
        }
        public override int Delete(int id)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"DELETE FROM [Applications] WHERE [Id] = @Id");
                return db.Execute(sqlCommand, new { Id = id });
            }
        }

        

        private Object ParameterMapping(Applications applications)
        {
            return new
            {
                Id = applications.Id,
                ApplicationName = applications.ApplicationName,
                Description = applications.Description
            };
        }


        //public IEnumerable<Applications> GetAllApplications()
        //{
        //    return _feedbackMgmtContext.Applications.ToList();
        //}
        //public Applications GetByIdApplications(int id)
        //{
        //    return _feedbackMgmtContext.Applications.Find(id);
        //}

        //public void AddApplications(Applications applications)
        //{
        //    _feedbackMgmtContext.Applications.Add(applications);
        //    _feedbackMgmtContext.SaveChanges();
        //}
        //public void UpdateApplications(Applications applications)
        //{
        //    _feedbackMgmtContext.Entry(applications).State = EntityState.Modified;
        //    _feedbackMgmtContext.SaveChanges();
        //}

        //public void DeleteApplications(int id)
        //{
        //    var application = _feedbackMgmtContext.Applications.Find(id);
        //    _feedbackMgmtContext.Applications.Remove(application);
        //    _feedbackMgmtContext.SaveChanges();
        //}






    }
}
