using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrowdVote.Models;
using System.Net;
using System.Data.Entity;

namespace CrowdVote.Controllers
{
    public class LinksController : Controller
    {
        private CrowdVoteDbContext _db = new CrowdVoteDbContext();

        public ActionResult Create(int? topicId)
        {
            if (topicId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var topic = _db.Topics.Find(topicId);

            if (topic == null)
            {
                return HttpNotFound();
            }

            ViewBag.Topic = topic.Title;

            ViewBag.Category = topic.Category.ID;
            ViewBag.CategoryTitle = topic.Category.Title;
            ViewBag.Topic = topic.ID;
            ViewBag.TopicTitle = topic.Title;
            ViewBag.SubLink = "Post a new link";

            return View();
        }

        [HttpPost]
        public ActionResult Create(int? topicId, Link model)
        {
            Topic topic = _db.Topics.Find(topicId);

           
            if (ModelState.IsValid)
            {
                topic.Links.Add(model);

                _db.Links.Add(model);
                _db.SaveChanges();

                return RedirectToAction("Details", "Topics", new { id = topicId });
            }

            return View(model);
        }

        public ActionResult UpVote(int id, int topicId)
        {

            Link link = _db.Links.Find(id);

            link.VoteCount = link.VoteCount + 1;

            _db.Entry(link).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Details", "Topics", new { id = topicId });
        }

        public ActionResult DownVote(int id, int topicId)
        {

            Link link = _db.Links.Find(id);

            link.VoteCount = link.VoteCount - 1;

            _db.Entry(link).State = EntityState.Modified;
            _db.SaveChanges();

            return RedirectToAction("Details", "Topics", new { id = topicId });
        }

    }
}