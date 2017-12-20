using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Comp2084_Assignment2.Models;

namespace Comp2084_Assignment2.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        // db connection moved to Models/EFGamesRepository.cs
        //private GameListModel db = new GameListModel();

        private IGamesRepository db;

            public GamesController()
        {
            this.db = new EFGamesRepository();
        }

        public GamesController(IGamesRepository db)
        {
            this.db = db;
        }

        // GET: Games
        [AllowAnonymous]
        public ViewResult Index()
        {
            var games = db.Games.Include(g => g.console);
            return View(games.ToList());
        }

        // GET: Games/Details/5
        [AllowAnonymous]
        public ViewResult Details(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            game game = db.Games.FirstOrDefault(a => a.id == id);
            if (game == null)
            {
                return View("Error");
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            ViewBag.console_id = new SelectList(db.Consoles, "id", "name");
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,title,company,rating,console_id")] game game)
        {
            if (ModelState.IsValid)
            {
                db.Save(game);
                return RedirectToAction("Index");
            }

            ViewBag.console_id = new SelectList(db.Consoles, "id", "name", game.console_id);
            return View(game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            game game = db.Games.FirstOrDefault(a => a.id == id);
            if (game == null)
            {
                return View("Error");
            }
            ViewBag.console_id = new SelectList(db.Consoles, "id", "name", game.console_id);
            return View(game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,title,company,rating,console_id")] game game)
        {
            if (ModelState.IsValid)
            {
                db.Save(game);
                return RedirectToAction("Index");
            }
            ViewBag.console_id = new SelectList(db.Consoles, "id", "name", game.console_id);
            return View(game);
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            game game = db.Games.FirstOrDefault(a => a.id == id);
            if (game == null)
            {
                return View("Error");
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ViewResult DeleteConfirmed(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }

            game game = db.Games.FirstOrDefault(a => a.id == id);

            if (game == null)
            {
                return View("Error");
            }

            db.Delete(game);
            return View("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
