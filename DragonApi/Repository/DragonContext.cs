using Microsoft.EntityFrameworkCore;
using Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class DragonContext : DbContext
    {
        public DbSet<Dragon> Dragons { get; set; }
        //protected readonly IConfiguration Configuration;

        public DragonContext(DbContextOptions<DragonContext> options) : base(options)
        { 
        }

        //public DragonContext(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    // connect to sqlite database
        //    options.UseSqlite(Configuration.GetConnectionString("SQLiteDefault"));
        //}
    }
}