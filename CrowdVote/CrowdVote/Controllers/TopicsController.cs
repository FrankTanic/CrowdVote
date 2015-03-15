using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrowdVote.Models;
using System.Net;

namespace CrowdVote.Controllers
{
    public class TopicsController : Controller
    {
        private CrowdVoteDbContext _db = new CrowdVoteDbContext();

        public ActionResult Create(int? categoryId)
        {
            if (categoryId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var category = _db.Category.Find(categoryId);

            if(category == null)
            {
                return HttpNotFound();
            }

            ViewBag.Category = category.Title;

            return View();
        }

        [HttpPost]
        public ActionResult Create(int? categoryId, Topic model)
        {
            Category category = _db.Category.Find(categoryId);

            ViewBag.Category = category.Title;

            if(ModelState.IsValid)
            {
                category.Topics.Add(model);

                _db.Topics.Add(model);
                _db.SaveChanges();

                return RedirectToAction("Details", "Topics", new { id = model.ID });
            }

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.Topic = id;

            Topic topic = _db.Topics.Find(id);
            topic.Links.OrderByDescending(l => l.ID);

            if (topic == null)
            {
                return HttpNotFound();
            }

            return View(topic);           
        }
    }
}