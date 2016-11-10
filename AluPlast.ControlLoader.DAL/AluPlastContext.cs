using AluPlast.ControlLoader.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluPlast.ControlLoader.DAL
{
    public class AluPlastContext : DbContext
    {
        public DbSet<Load> Loads { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


        public AluPlastContext()
            : base("AluPlastDbConnection")
        {

        }


    }
}
