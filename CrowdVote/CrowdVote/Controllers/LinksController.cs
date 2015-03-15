﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrowdVote.Models;
using System.Net;

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
    }
}