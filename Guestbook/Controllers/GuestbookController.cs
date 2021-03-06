﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Guestbook.Models;

namespace Guestbook.Controllers
{
    public class GuestbookController : Controller
    {
        //
        // GET: /Guestbook/
        private GuestbookContext _db = new GuestbookContext();

        public ActionResult Index()
        {
            var mostRecentEntries = (from entry in _db.Entries orderby entry.DateAdded descending select entry).Take(0);
            ViewBag.Entries = mostRecentEntries;
            //ViewBag.Test = _db.Entries.ToList().Take(5);
            
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GuestbookEntry entry)
        {
            entry.DateAdded = DateTime.Now;
            _db.Entries.Add(entry);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
