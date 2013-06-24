using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FGR.Models;

namespace FGR.Controllers
{
    public class PlayerController : Controller
    {
        private dbFGRContext db = new dbFGRContext();

        //
        // GET: /Player/
        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Players.OrderBy(p=>p.Nickname).OrderByDescending(p=> p.Status));
        }

        [HttpPost]
        public ActionResult Index(string Nickname)
        {
            
            var player = from players in db.Players
                         where players.Nickname.Contains(Nickname)
                         select players;

            return View("Index", player.Where(p=> p.Nickname.Contains(Nickname)));
        }

        //
        // GET: /Player/Details/5
        
        public ActionResult Details(int id = 0)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //
        // GET: /Player/Create

        public ActionResult Create()
        {

            return View();


        }

        //
        // POST: /Player/Create

        [HttpPost]
        public ActionResult Create(Player player)
        {
            bool exists = NicknameExists(player);

            if (ModelState.IsValid)
            {
                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
 
            return View(player);
        }

        //
        // GET: /Player/Edit/5


        private bool NicknameExists(Player player)
        {
            using (db)
            {
                var players = from p in db.Players
                            where p.Nickname == player.Nickname
                            select  p;
                db =  new dbFGRContext();
                return players.Any();
            }
        }


        public ActionResult Edit(int id = 0)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //
        // POST: /Player/Edit/5

        [HttpPost]
        public ActionResult Edit(Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        //
        // GET: /Player/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Player player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        //
        // POST: /Player/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Player player = db.Players.Find(id);
            db.Players.Remove(player);
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