using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrowdVote.Models;

namespace CrowdVote.Controllers
{
    public class LinksController : Controller
    {
        private CrowdVoteDbContext _db = new CrowdVoteDbContext();

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int? linkId, Link model)
        {
            Topic topic = _db.Topics.Find(linkId);

           
            if (ModelState.IsValid)
            {
                topic.Links.Add(model);

                return RedirectToAction("Details", "Topics", new { id = model.ID });
            }

            return View(model);
        }
    }
}