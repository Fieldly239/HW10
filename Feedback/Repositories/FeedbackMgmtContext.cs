using Feedback.Models;
using Microsoft.EntityFrameworkCore;

namespace Feedback.Repositories
{
    public class FeedbackMgmtContext : DbContext
    {
        public FeedbackMgmtContext(DbContextOptions<FeedbackMgmtContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
        }

        public DbSet<Feedbacks> Feedbacks { get; set; }
        public DbSet<Applications> Applications { get; set; }
    }
}
