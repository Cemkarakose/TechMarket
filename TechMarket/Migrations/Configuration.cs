namespace TechMarket.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TechMarket.Models;
    using System.Collections.Generic;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<TechMarket.DAL.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TechMarket.DAL.StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            var products = new List<Product>
            {
                new Product{ productbrand="Samsung", productmodel="Galaxy Note 20",category=2,price=3849,stock=10  },
                new Product{ productbrand="Samsung", productmodel="Galaxy S20+",category=2,price=3599,stock=10  },
                new Product{ productbrand="Samsung", productmodel="Galaxy M21",category=2,price=999,stock=10  },
                new Product{ productbrand="Xiaomi", productmodel="Redmi 9",category=2,price=599,stock=10  },
                new Product{ productbrand="Xiaomi", productmodel="Redmi Note 9 Pro",category=2,price=999,stock=10  },
                new Product{ productbrand="Huawei", productmodel="P smart 2021",category=2,price=799,stock=10  },
                new Product{ productbrand="Huawei", productmodel="Y5 2019",category=2,price=369,stock=10  },
                new Product{ productbrand="Apple", productmodel="iPhone 11",category=2,price=3399,stock=10  },
                new Product{ productbrand="Apple", productmodel="iPhone 12 Pro Max",category=2,price=5758,stock=10  },

                new Product{ productbrand="Apple", productmodel="MacBook Pro MYD82ZE/A",category=1,price=6199,stock=10  },
                new Product{ productbrand="Apple", productmodel="MacBook Pro MYD92ZE/A",category=1,price=7199,stock=10  },
                new Product{ productbrand="HP", productmodel="Pavilion 16-a0019nw",category=1,price=4899,stock=10  },
                new Product{ productbrand="Huawei", productmodel="MateBook 14",category=1,price=3999,stock=10  },
                new Product{ productbrand="Asus", productmodel="TUF F15 FX506LI-HNO12T",category=1,price= 4199,stock=10  },
                new Product{ productbrand="Asus", productmodel="VivoBook 14 F413DA-EKO51T",category=1,price=2549,stock=10 }
            };

            var categories = new List<Category>
            {
                new Category{ categoryname="Laptop"},
                new Category{ categoryname="Phone"}
            };

            products.ForEach(product => context.products.AddOrUpdate(obj => obj.productmodel, product));
            context.SaveChanges();
            categories.ForEach(category => context.categories.AddOrUpdate(obj => obj.categoryname, category));
            context.SaveChanges();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }
            if (!roleManager.RoleExists("Customer"))
            {
                roleManager.Create(new IdentityRole("Customer"));
            }

            var customers = new List<ApplicationUser>
            {
                new ApplicationUser{ UserName = "j.silverhand@example.com", Email = "j.silverhand@example.com",
                    Customer = new Customer{ID=1,FirstName="Johnny",LastName="Silverhand",Birthday=DateTime.Parse("2005-09-01")} },
                new ApplicationUser{ UserName = "p.palmer@example.com", Email = "p.palmer@example.com",
                    Customer = new Customer{ID=2,FirstName="Panam",LastName="Palmer",Birthday=DateTime.Parse("2002-09-01")} },
                new ApplicationUser{ UserName = "j.alvarez@example.com", Email = "j.alvarez@example.com",
                    Customer = new Customer{ID=3,FirstName="Judy",LastName="Alvarez",Birthday=DateTime.Parse("2003-09-01")} },

            };
            string defaultPassword = "pass123";

            foreach (var customer in customers)
            {
                if (UserManager.FindByName(customer.UserName) == null)
                {
                    UserManager.Create(customer, defaultPassword);
                    UserManager.AddToRole(customer.Id, "Customer");
                }
            }



            var admins = new List<ApplicationUser>
            {
                new ApplicationUser{ UserName = "super.admin@example.com", Email = "super.admin@example.com",
                    Admin = new Admin{ID=1,FirstName="Super",LastName="Admin",HireDate=DateTime.Parse("1970-01-01")} },
            };
            foreach (var admin in admins)
            {
                if (UserManager.FindByName(admin.UserName) == null)
                {
                    UserManager.Create(admin, defaultPassword);
                    UserManager.AddToRole(admin.Id, "Admin");
                }
            }
        }
    }
}
