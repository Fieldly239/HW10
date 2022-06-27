using Dapper;
using Feedback.Models;
using Feedback.Repositories.GenericRepository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Repositories
{
    public class FeedbacksRepository : GenericRepository<Feedbacks> , IFeedbacksRepository
    {
        private readonly IConfiguration _configuration;
        //private readonly FeedbackMgmtContext _feedbackMgmtContext;

        public FeedbacksRepository(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        //public IEnumerable<Feedbacks> GetAllFeedbacks()
        //{
        //    using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
        //    {
        //        var sqlCommand = string.Format(@"SELECT * FROM [Feedbacks]");
        //        return db.Query<Feedbacks>(sqlCommand).ToList();
        //    }
            
        //}
        //public Feedbacks GetByIdFeedbacks(int id)
        //{
        //    using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
        //    {
        //        var sqlCommand = string.Format(@"SELECT * FROM [Feedbacks] WHERE Id = @Id");
        //        return db.Query<Feedbacks>(sqlCommand, new { Id = id}).FirstOrDefault();
        //    }
        //}

        public override async Task<int> Add(Feedbacks feedbacks)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"INSERT INTO [Feedbacks]
                                               ([FeedbackName]
                                               ,[Description]
                                               ,[ApplicationId])
                                         VALUES
                                               (@FeedbackName
                                               ,@Description
                                               ,@ApplicationId)");
                return await db.ExecuteAsync(sqlCommand, ParameterMapping(feedbacks));
            }
        }
        public override async Task<int> Update(Feedbacks feedbacks)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"UPDATE [Feedbacks]
                                               SET [FeedbackName] = @FeedbackName
                                                  ,[Description] = @Description
                                                  ,[ApplicationId] = @ApplicationId
                                             WHERE [Id] = @Id");
                return await db.ExecuteAsync(sqlCommand, ParameterMapping(feedbacks));
            }
        }
        public override async Task<int> Delete(int id)
        {
            using (var db = new SqlConnection(_configuration.GetSection("ConnectionStrings:ConnectionString").Value))
            {
                var sqlCommand = string.Format(@"DELETE FROM [Feedbacks] WHERE [Id] = @Id");
                return await db.ExecuteAsync(sqlCommand, new { Id = id});
            }
        }

        private Object ParameterMapping(Feedbacks feedbacks)
        {
            return new
            {
                Id = feedbacks.Id,
                FeedbackName = feedbacks.FeedbackName,
                Description = feedbacks.Description,
                ApplicationId = feedbacks.ApplicationId
            };
        }

        

        
    }
}
