using CandidateTracker.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateTracker.Web.Models
{
    public class CandidatesViewModel
    {
        public IEnumerable<Candidate> Candidates { get; set; }
        public string Title { get; set; }
        public bool IsPending { get; set; }
    }
}
