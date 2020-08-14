using Microsoft.EntityFrameworkCore;
using Movie_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_API
{
    public class MovieDbContext : DbContext // db repre
    {
        public MovieDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Movie> Movies { get; set; }

    }
}
