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

            ViewBag.Category = category.ID;
            ViewBag.CategoryTitle = category.Title;
            ViewBag.SubLink = "Request a link";

            return View();
        }

        [HttpPost]
        public ActionResult Create(int? categoryId, Topic model)
        {
            var category = _db.Category.Find(categoryId);

            ViewBag.Category = category.ID;
            ViewBag.CategoryTitle = category.Title;
            ViewBag.SubLink = "Request a link";

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

            var topic = _db.Topics.Find(id);

            if (topic == null)
            {
                return HttpNotFound();
            }

            ViewBag.Category = topic.Category.ID;
            ViewBag.CategoryTitle = topic.Category.Title;
            ViewBag.Topic = topic.ID;
            ViewBag.TopicTitle = topic.Title;

            return View(topic.Links.OrderByDescending(x => x.VoteCount));           
        }
    }
}