using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week3GroupProject.Models
{
    public class GameRating
    {
        public int ID { get; set; }
        public Game game { get; set; }
        public List<ESRBRating> ratings { get; set; }

        public GameRating()
        {
            game = new Game();
            ratings = new List<ESRBRating>();
        }
    }
}
