using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;
using Guestbook.Models;
using Microsoft.Ajax.Utilities;
using log4net;
using log4net.Config;


namespace Guestbook.Controllers
{
    public class MathController : Controller
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(MathController));
        //
        // GET: /Math/
        private GuestbookContext _db = new GuestbookContext();

        private ActionResult GetLastValue()
        {
            var lists = _db.Maths.OrderByDescending(id => id.Id).Take(1);
            return View("CreateMath", lists.ToList());
        }

        public ActionResult IndexMath()
        {
            var lists = _db.Maths.OrderByDescending(id => id.Id).Take(5);
            ViewBag.List = lists;
            return View(lists);
            //return View(lists.ToList());

            //var lists = (from entryMath in _db.Maths join entryMathType in _db.MathTypes on entryMath.TypeId equals entryMathType.TypeId orderby entryMath.Id descending select new { entryMath.FirstNumber, entryMath.SecondNumber, entryMath.Total, entryMath.TypeId, entryMathType.OperationType }).Take(5);

            //var lists = _db.Maths.Join(_db.MathTypes, p => p.TypeId, c => c.TypeId,
            //    (p, c) => new {c.OperationType, p.FirstNumber});

            ////var recentMath = (from entryMath in _db.Maths orderby entryMath.Id descending select entryMath).Take(5);
            ////ViewBag.Maths = recentMath;
            //ViewBag.List = _db.Maths.ToList().Take(5).OrderByDescending(k => k.Id);
            //return View();


        }
        [HttpGet]
        public ActionResult CreateMath()
        {
            var lists = _db.Maths.OrderByDescending(id => id.Id).Take(0);
            return View(lists.ToList());
        }

        [HttpPost]
        public ActionResult CreateMath(GuestbookMath entryMath, string action)
        {


            if (ModelState.IsValid)
            {
                if (action == "+")
                {
                    entryMath.TypeId = 1;
                    entryMath.Total = new Functions().GetSum(entryMath.FirstNumber, entryMath.SecondNumber);
                    _db.Maths.Add(entryMath);
                    _db.SaveChanges();
                    log.Debug(entryMath.FirstNumber + " + " + entryMath.SecondNumber + " = " + entryMath.Total);
                    GetLastValue();
                }
                else if (action == "-")
                {
                    entryMath.TypeId = 2;
                    entryMath.Total = new Functions().GetMinus(entryMath.FirstNumber, entryMath.SecondNumber);
                    _db.Maths.Add(entryMath);
                    _db.SaveChanges();
                    GetLastValue();

                }
                else if (action == "*")
                {
                    entryMath.TypeId = 3;
                    entryMath.Total = new Functions().GetMult(entryMath.FirstNumber, entryMath.SecondNumber);
                    _db.Maths.Add(entryMath);
                    _db.SaveChanges();
                    GetLastValue();
                }


                else if (action == "/")
                {

                    if (entryMath.SecondNumber == 0)
                    {
                        ViewBag.DerividZero = "Cannot dirived by zero";

                    }
                    else
                    {
                        entryMath.TypeId = 4;
                        entryMath.Total = new Functions().GetDerived(entryMath.FirstNumber, entryMath.SecondNumber);
                        _db.Maths.Add(entryMath);
                        _db.SaveChanges();
                        GetLastValue();
                    }

                    
                }
                

            }



            var list = _db.Maths.OrderByDescending(id => id.Id).Take(0);
            return View(list.ToList());

        }

    }

}
