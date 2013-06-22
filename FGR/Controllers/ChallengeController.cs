using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FGR.Models;

namespace FGR.Controllers
{
    public class ChallengeController : Controller
    {
        private dbFGRContext db = new dbFGRContext();

        //
        // GET: /Challenge/

        public ActionResult Index()
        {
            var challenges = db.Challenges.Include(c => c.Game).Include(c => c.Ranking).Include(c => c.Ranking1);
            return View(challenges.ToList());
        }

        //
        // GET: /Challenge/Details/5

        public ActionResult Details(int id = 0)
        {
            Challenge challenge = db.Challenges.Find(id);
            if (challenge == null)
            {
                return HttpNotFound();
            }
            return View(challenge);
        }

        //
        // GET: /Challenge/Create

        public ActionResult Create()
        {
            ViewBag.GameID = new SelectList(db.Games, "ID", "GameTitle");
            ViewBag.ChallengerPlayerID = new SelectList(db.Rankings, "ID", "ID");
            ViewBag.RivalPlayerID = new SelectList(db.Rankings, "ID", "ID");
            return View();
        }

        //
        // POST: /Challenge/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Challenge challenge)
        {
            if (ModelState.IsValid)
            {
                db.Challenges.Add(challenge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GameID = new SelectList(db.Games, "ID", "GameTitle", challenge.GameID);
            ViewBag.ChallengerPlayerID = new SelectList(db.Rankings, "ID", "ID", challenge.ChallengerPlayerID);
            ViewBag.RivalPlayerID = new SelectList(db.Rankings, "ID", "ID", challenge.RivalPlayerID);
            return View(challenge);
        }

        //
        // GET: /Challenge/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Challenge challenge = db.Challenges.Find(id);
            if (challenge == null)
            {
                return HttpNotFound();
            }
            ViewBag.GameID = new SelectList(db.Games, "ID", "GameTitle", challenge.GameID);
            ViewBag.ChallengerPlayerID = new SelectList(db.Rankings, "ID", "ID", challenge.ChallengerPlayerID);
            ViewBag.RivalPlayerID = new SelectList(db.Rankings, "ID", "ID", challenge.RivalPlayerID);
            return View(challenge);
        }

        //
        // POST: /Challenge/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Challenge challenge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(challenge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.GameID = new SelectList(db.Games, "ID", "GameTitle", challenge.GameID);
            ViewBag.ChallengerPlayerID = new SelectList(db.Rankings, "ID", "ID", challenge.ChallengerPlayerID);
            ViewBag.RivalPlayerID = new SelectList(db.Rankings, "ID", "ID", challenge.RivalPlayerID);
            return View(challenge);
        }

        //
        // GET: /Challenge/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Challenge challenge = db.Challenges.Find(id);
            if (challenge == null)
            {
                return HttpNotFound();
            }
            return View(challenge);
        }

        //
        // POST: /Challenge/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Challenge challenge = db.Challenges.Find(id);
            db.Challenges.Remove(challenge);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}