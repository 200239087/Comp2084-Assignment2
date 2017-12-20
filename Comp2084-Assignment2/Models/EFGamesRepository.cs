using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Comp2084_Assignment2.Models
{
    public class EFGamesRepository : IGamesRepository
    {
        GameListModel db = new GameListModel();


        public IQueryable<game> Games { get { return db.games; } }

        public IQueryable<console> Consoles { get { return db.consoles; } }

        public void Delete(game game)
        {
            db.games.Remove(game);
            db.SaveChanges();
        }

        public game Save(game game)
        {
            if (game.id == 0)
            {
                db.games.Add(game);
            }
            else
            {
                db.Entry(game).State = System.Data.Entity.EntityState.Modified;
            }

            db.SaveChanges();
            return game;
        }
    }
}