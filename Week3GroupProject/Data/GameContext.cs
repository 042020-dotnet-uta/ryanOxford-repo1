using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Week3GroupProject.Models;

namespace Week3GroupProject.Data
{
    public class GameContext : DbContext
    {
        public GameContext()
        {
        }

        public GameContext (DbContextOptions<GameContext> options)
            : base(options)
        {
        }

        public DbSet<Game> Game { get; set; }
        public DbSet<ESRBRating> Rating { get; set; }
    }
}
