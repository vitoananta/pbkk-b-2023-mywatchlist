using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyWatchlist.Models;

namespace MyWatchlist.Data
{
    public class MyWatchlistContext : DbContext
    {
        public MyWatchlistContext (DbContextOptions<MyWatchlistContext> options)
            : base(options)
        {
        }

        public DbSet<MyWatchlist.Models.Symbol> Symbol { get; set; } = default!;
    }
}
