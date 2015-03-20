using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrowdVote.Models;

namespace CrowdVote.Controllers
{
    public class CategoriesController : Controller
    {
        private CrowdVoteDbContext _db = new CrowdVoteDbContext();

        public ActionResult Index()
        {
            var categories = _db.Category.ToList();

            if(categories == null)
            {
                return View();
            }

            return View(categories);
        }

        public ActionResult Details(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ViewBag.Category = id;

            Category category = _db.Category.Find(id);

            if(category == null)
            {
                return HttpNotFound();
            }

            ViewBag.CategoryTitle = category.Title;

            return View(category);
        }
    }
}