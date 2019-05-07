using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace CandidateTracker.Data
{
    public class CandidateRepository
    {
        private string _connectionString;

        public CandidateRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Candidate> GetPendingCandidates()
        {
            using (var ctx = new CandidateContext(_connectionString))
            {
                return ctx.Candidates.Where(c => c.Confirmed == null).ToList();
            }
        }

        public IEnumerable<Candidate> GetConfirmedCandidates()
        {
            using (var ctx = new CandidateContext(_connectionString))
            {
                return ctx.Candidates.Where(c => c.Confirmed == true).ToList();
            }
        }

        public IEnumerable<Candidate> GetDeclinedCandidates()
        {
            using (var ctx = new CandidateContext(_connectionString))
            {
                return ctx.Candidates.Where(c => c.Confirmed == false).ToList();
            }
        }

        public void AddCandidate(Candidate c)
        {
            using (var ctx = new CandidateContext(_connectionString))
            {
                ctx.Candidates.Add(c);
                ctx.SaveChanges();
            }
        }

        public Candidate GetCandidate(int id)
        { 
            using (var ctx = new CandidateContext(_connectionString))
            {
                return ctx.Candidates.FirstOrDefault(c => c.Id == id);
            }

        }

        public void DeclineCandidate(int id)
        {
            using (var ctx = new CandidateContext(_connectionString))
            {
                ctx.Database.ExecuteSqlCommand(
                    "UPDATE Candidates SET Confirmed = 'False' WHERE Id = @id",
                    new SqlParameter("@id", id));
            }
        }

        public void ConfirmCandidate(int id)
        {
            using (var ctx = new CandidateContext(_connectionString))
            {
                ctx.Database.ExecuteSqlCommand(
                    "UPDATE Candidates SET Confirmed = 'True' WHERE Id = @id",
                    new SqlParameter("@id", id));
            }
        }
    }
}
