using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrowdVote.Models;

namespace CrowdVote.Controllers
{
    public class CategoriesController : Controller
    {
        private CrowdVoteDbContext _db = new CrowdVoteDbContext();

        // GET: Home
        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                HttpNotFound();
            }

            Subject subject = _db.Subjects.Find(id);

            if(subject == null)
            {
                return HttpNotFound();
            }

            return View(subject);
        }
    }
}