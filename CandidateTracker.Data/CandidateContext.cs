using Microsoft.EntityFrameworkCore;

namespace CandidateTracker.Data
{
    public class CandidateContext : DbContext
    {
        private string _connectionString;

        public CandidateContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DbSet<Candidate> Candidates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(_connectionString);
        }
    }
}
