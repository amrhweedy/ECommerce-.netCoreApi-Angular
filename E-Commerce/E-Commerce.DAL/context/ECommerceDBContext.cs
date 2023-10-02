using E_Commerce.DAL.models;
using E_Commerce.DAL.models.order;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace E_Commerce.DAL.context
{
    public  class ECommerceDBContext : IdentityDbContext<ApplicationUser>
    {

        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options  ) : base(options)
        {
        }

        


        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; } 

        public DbSet<Brand> brands { get; set; }

        public DbSet<Order> orders { get; set; }

        public DbSet<productedOrdered> productedOrdereds { get; set; }

        public DbSet<DeliveryMethod> deliveryMethods { get; set; }  


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Order>().OwnsOne(a => a.Address);   //take the properties which in address and put them in orde table

            modelBuilder.Entity<productedOrdered>()
                        .HasKey(p => new { p.productid, p.orderid });
            #region seeding category

            modelBuilder.Entity<Category>().HasData(

                new Category { Id = 1, Name = "man" },
                new Category { Id = 2, Name = "woman" },
                new Category { Id = 3, Name = "child" }
                );
            #endregion

            #region seeding Brand
            modelBuilder.Entity<Brand>().HasData(

                new Brand { Id = 1, Name = "Zara" },
                new Brand { Id = 2, Name = "Nike" },
                new Brand { Id = 3, Name = "Puma" }
                );
            #endregion


            #region seeding product
            // byte[] dressWoman1 = File.ReadAllBytes("D:\\iti\\c#\\TESTDLLANDEXE\\E-Commerce\\E-Commerce.DAL\\pictures\\dressWoman1.jpeg");


            modelBuilder.Entity<Product>().HasData(

                new Product { Id = 1, Name = "Dress", Description = "this is Dress", Price = 250, Picture = "dressWoman1.jpeg", BrandId = 1, CategoryId = 2 },
                new Product { Id = 2, Name = "Dress", Description = "this is Dress", Price = 200, Picture = "dressWoman2.jpeg", BrandId = 2, CategoryId = 2 },
                new Product { Id = 3, Name = "Dress", Description = "this is Dress", Price = 300, Picture = "dressWoman3.jpeg", BrandId = 3, CategoryId = 2 },
                new Product { Id = 4, Name = "Dress", Description = "this is Dress", Price = 350, Picture = "dressWoman4.jpeg", BrandId = 1, CategoryId = 2 },

                new Product { Id = 5, Name = "Jacket", Description = "this is Jacket ", Price = 123, Picture = "jacketChild1.jpeg", BrandId = 2, CategoryId = 3 },
                new Product { Id = 6, Name = "Jacket", Description = "this is Jacket ", Price = 321, Picture = "jacketChild2.jpeg", BrandId = 3, CategoryId = 3 },

                new Product { Id = 7, Name = "Jacket", Description = "this is Jacket ", Price = 234, Picture = "jacketMan1.jpeg", BrandId = 1, CategoryId = 1 },
                new Product { Id = 8, Name = "Jacket", Description = "this is Jacket ", Price = 356, Picture = "jacketMan2.jpeg", BrandId = 2, CategoryId = 1 },

                new Product { Id = 9, Name = "Jacket", Description = "this is Jacket ", Price = 324, Picture = "jacketWoman1.jpeg", BrandId = 3, CategoryId = 2 },
                new Product { Id = 10, Name = "Jacket", Description = "this is Jacket ", Price = 564, Picture = "jacketWoman2.jpeg", BrandId = 1, CategoryId = 2 },

                new Product { Id = 11, Name = "Shirt", Description = "this is Shirt ", Price = 456, Picture = "shirtMan1.jpeg", BrandId = 2, CategoryId = 1 },
                new Product { Id = 12, Name = "Shirt", Description = "this is Shirt ", Price = 326, Picture = "shirtMan2.jpeg", BrandId = 1, CategoryId = 1 },
                new Product { Id = 13, Name = "Shirt", Description = "this is Shirt ", Price = 461, Picture = "shirtMan3.jpeg", BrandId = 2, CategoryId = 1 },
                new Product { Id = 14, Name = "Shirt", Description = "this is Shirt ", Price = 324, Picture = "shirtMan4.jpeg", BrandId = 3, CategoryId = 1 },

                new Product { Id = 15, Name = "Shoes", Description = "this is Shoes ", Price = 324, Picture = "shoesChild1.jpeg", BrandId = 1, CategoryId = 3 },
                new Product { Id = 16, Name = "Shoes", Description = "this is Shoes ", Price = 356, Picture = "shoesChild2.jpeg", BrandId = 2, CategoryId = 3 },
                new Product { Id = 17, Name = "Shoes", Description = "this is Shoes ", Price = 564, Picture = "shoesMan1.jpeg", BrandId = 3, CategoryId = 1 },
                new Product { Id = 18, Name = "Shoes", Description = "this is Shoes ", Price = 222, Picture = "shoesMan2.jpeg", BrandId = 1, CategoryId = 1 },
                new Product { Id = 19, Name = "Shoes", Description = "this is Shoes ", Price = 333, Picture = "shoesWoman1.jpeg", BrandId = 2, CategoryId = 2 },
                new Product { Id = 20, Name = "Shoes", Description = "this is Shoes ", Price = 264, Picture = "shoesWoman2.jpeg", BrandId = 3, CategoryId = 2 }


                );
            #endregion

            #region seeding role

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new IdentityRole { Id = "2", Name = "User", NormalizedName = "USER" }
                );

            #endregion


            #region seeding Admin 

            ApplicationUser Admin = new ApplicationUser
            {

                Id = "1",
                UserName = "Admin",
                NormalizedUserName = "ADMIN",
                Email = "Admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM",
                PhoneNumber = "01115910801",
                RegisterdDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"),
            };

            PasswordHasher<ApplicationUser> ph = new PasswordHasher<ApplicationUser>();
            Admin.PasswordHash = ph.HashPassword(Admin, "Admin@123");

            modelBuilder.Entity<ApplicationUser>().HasData(Admin);

            #endregion

            #region add claims to admin

            modelBuilder.Entity<IdentityUserClaim<string>>().HasData(

                new IdentityUserClaim<string>()
                {
                    Id = 1,
                    ClaimType = ClaimTypes.Role,
                    ClaimValue = "Admin",
                    UserId = "1"

                }
                );

            #endregion


            #region Add Role to user

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(

                new IdentityUserRole<string>
                {
                    UserId = Admin.Id,
                    RoleId = "1",
                }

                );

            #endregion




        }


    }
}
