using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Week3GroupProject.Models;
using Microsoft.EntityFrameworkCore;

namespace Week3GroupProject.Data
{
    /// <summary>
    /// This class is used as a bridge between the controllers and the context
    /// </summary>
    public static class DbAccess

    {

        public static GameContext db = new GameContext();
        public static List<ESRBRating> ReturnRatingList(Game game)
        {
            //var new = db.Game.Include("Rating").Where(x => x.Rating.Rating = game.Rating.Rating);
            //var temp = db.Game.Include(r => r.Rating).Where(x => x.Rating.ID = game.Rating.ID).FirstOrDefault();
            //
            var temp = db.Rating.ToList();
            return temp;
        }


    }
}
