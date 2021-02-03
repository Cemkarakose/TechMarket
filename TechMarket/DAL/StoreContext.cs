using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using TechMarket.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TechMarket.DAL
{
    public class StoreContext : IdentityDbContext<ApplicationUser>
    {
        public StoreContext() : base("DBConnString") {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<StoreContext, TechMarket.Migrations.Configuration>());
        }
        public static StoreContext Create()
        {
            return new StoreContext();
        }

        public DbSet<Category> categories { get; set; }
        public DbSet<Sale> sales { get; set; }
        public DbSet<Person> people { get; set; }
        public DbSet<Product> products { get; set; }

    }
}