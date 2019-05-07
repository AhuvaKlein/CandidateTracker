using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CandidateTracker.Web.Models;
using CandidateTracker.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CandidateTracker.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _connectionString;
        private CandidateRepository _repo;
        private LayoutPageAttribute _lpa;

        public HomeController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
            _repo = new CandidateRepository(_connectionString);
            _lpa = new LayoutPageAttribute(configuration);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddCandidate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCandidate(Candidate c)
        {
            _repo.AddCandidate(c);
            return Redirect("/home/pending");
        }

        public IActionResult Pending()
        {
            CandidatesViewModel vm = new CandidatesViewModel();
            vm.Candidates = _repo.GetPendingCandidates();
            vm.Title = "Pending Candidates";
            vm.IsPending = true;
            return View("CandidatesView", vm);
        }

        public IActionResult Confirmed()
        {
            CandidatesViewModel vm = new CandidatesViewModel();
            vm.Candidates = _repo.GetConfirmedCandidates();
            vm.Title = "Confirmed Candidates";
            vm.IsPending = false;
            return View("CandidatesView", vm);
        }

        public IActionResult Declined()
        {
            CandidatesViewModel vm = new CandidatesViewModel();
            vm.Candidates = _repo.GetDeclinedCandidates();
            vm.Title = "Declined Candidates";
            vm.IsPending = false;
            return View("CandidatesView", vm);
        }

        public IActionResult ViewDetails(int id)
        {
            Candidate c = _repo.GetCandidate(id);

            if (c == null)
            {
                return Redirect("/home/index");
            }

            if (c.Confirmed != null)
            {
                return Redirect("/home/index");
            }

            return View(c);
        }

        [HttpPost]
        public IActionResult DeclineCandidate(int id)
        {
            _repo.DeclineCandidate(id);
            var ids = new 
            {
                Pending = _repo.GetPendingCandidates().Count(),
                Confirmed = _repo.GetConfirmedCandidates().Count(),
                Declined = _repo.GetDeclinedCandidates().Count()
            };

            return Json(ids);
        }

        [HttpPost]
        public IActionResult ConfirmCandidate(int id)
        {
            _repo.ConfirmCandidate(id);

            var ids = new 
            {
                Pending = _repo.GetPendingCandidates().Count(),
                Confirmed = _repo.GetConfirmedCandidates().Count(),
                Declined = _repo.GetDeclinedCandidates().Count()
            };
            return Json(ids);
        }

    }
}
