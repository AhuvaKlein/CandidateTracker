using CandidateTracker.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CandidateTracker.Web
{
    public class LayoutPageAttribute:ActionFilterAttribute
    {
        private string _connectionString;

        public LayoutPageAttribute(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("ConStr");
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            CandidateRepository repo = new CandidateRepository(_connectionString);
            var controller = (Controller)context.Controller;
            controller.ViewBag.Pending = repo.GetPendingCandidates().Count();
            controller.ViewBag.Declined = repo.GetDeclinedCandidates().Count();
            controller.ViewBag.Confirmed = repo.GetConfirmedCandidates().Count();
            base.OnActionExecuted(context);
        }
    }
}
