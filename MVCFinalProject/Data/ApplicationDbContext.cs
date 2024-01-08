using MVCFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCFinalProject.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("ConStr")
        {

        }
        public DbSet<Country> countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> cities { get; set; }
        public DbSet<Ragister> Ragisters{ get; set; }



    }
}