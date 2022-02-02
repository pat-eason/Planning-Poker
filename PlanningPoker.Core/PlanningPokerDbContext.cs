using Microsoft.EntityFrameworkCore;
using PlanningPoker.Core.Entities;

namespace PlanningPoker.Core
{
    public class PlanningPokerDbContext : DbContext
    {
        public PlanningPokerDbContext(DbContextOptions<PlanningPokerDbContext> options) : base(options)
        {
        }

        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionTask> SessionTasks { get; set; }
        public DbSet<SessionTaskVote> SessionTaskVotes { get; set; }
    }
}
