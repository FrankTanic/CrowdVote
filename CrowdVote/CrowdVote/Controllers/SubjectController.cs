using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrowdVote.Models;

namespace CrowdVote.Controllers
{
    public class SubjectController : Controller
    {
        private CrowdVoteDbContext _db = new CrowdVoteDbContext();

        // GET: Subject
        public ActionResult Index()
        {
            var subjects = _db.Subjects.ToList();

            return View(subjects);

        }
    }
}