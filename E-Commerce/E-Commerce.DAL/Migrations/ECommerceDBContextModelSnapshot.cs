﻿// <auto-generated />
using System;
using E_Commerce.DAL.context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace E_Commerce.DAL.Migrations
{
    [DbContext(typeof(ECommerceDBContext))]
    partial class ECommerceDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("E_Commerce.DAL.models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("RegisterdDate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "8dd4e06b-5d40-4fe2-a6a2-0b14170bc96e",
                            Email = "Admin@admin.com",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@ADMIN.COM",
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAIAAYagAAAAEKWedVqtOuuTn7Rh9TJ+N6/RF29e6YJ4NdK6pmtKfZtmlChJFTmav4fZHiK3ytbkdg==",
                            PhoneNumber = "01115910801",
                            PhoneNumberConfirmed = false,
                            RegisterdDate = "29/08/2023 07:57:26 AM",
                            SecurityStamp = "811ea1b6-f4b2-4ed4-afa3-83964aeffafb",
                            TwoFactorEnabled = false,
                            UserName = "Admin"
                        });
                });

            modelBuilder.Entity("E_Commerce.DAL.models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Zara"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Nike"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Puma"
                        });
                });

            modelBuilder.Entity("E_Commerce.DAL.models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "man"
                        },
                        new
                        {
                            Id = 2,
                            Name = "woman"
                        },
                        new
                        {
                            Id = 3,
                            Name = "child"
                        });
                });

            modelBuilder.Entity("E_Commerce.DAL.models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Picture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CategoryId = 2,
                            Description = "this is Dress",
                            Name = "Dress",
                            Picture = "dressWoman1.jpeg",
                            Price = 250.0
                        },
                        new
                        {
                            Id = 2,
                            BrandId = 2,
                            CategoryId = 2,
                            Description = "this is Dress",
                            Name = "Dress",
                            Picture = "dressWoman2.jpeg",
                            Price = 200.0
                        },
                        new
                        {
                            Id = 3,
                            BrandId = 3,
                            CategoryId = 2,
                            Description = "this is Dress",
                            Name = "Dress",
                            Picture = "dressWoman3.jpeg",
                            Price = 300.0
                        },
                        new
                        {
                            Id = 4,
                            BrandId = 1,
                            CategoryId = 2,
                            Description = "this is Dress",
                            Name = "Dress",
                            Picture = "dressWoman4.jpeg",
                            Price = 350.0
                        },
                        new
                        {
                            Id = 5,
                            BrandId = 2,
                            CategoryId = 3,
                            Description = "this is Jacket ",
                            Name = "Jacket",
                            Picture = "jacketChild1.jpeg",
                            Price = 123.0
                        },
                        new
                        {
                            Id = 6,
                            BrandId = 3,
                            CategoryId = 3,
                            Description = "this is Jacket ",
                            Name = "Jacket",
                            Picture = "jacketChild2.jpeg",
                            Price = 321.0
                        },
                        new
                        {
                            Id = 7,
                            BrandId = 1,
                            CategoryId = 1,
                            Description = "this is Jacket ",
                            Name = "Jacket",
                            Picture = "jacketMan1.jpeg",
                            Price = 234.0
                        },
                        new
                        {
                            Id = 8,
                            BrandId = 2,
                            CategoryId = 1,
                            Description = "this is Jacket ",
                            Name = "Jacket",
                            Picture = "jacketMan2.jpeg",
                            Price = 356.0
                        },
                        new
                        {
                            Id = 9,
                            BrandId = 3,
                            CategoryId = 2,
                            Description = "this is Jacket ",
                            Name = "Jacket",
                            Picture = "jacketWoman1.jpeg",
                            Price = 324.0
                        },
                        new
                        {
                            Id = 10,
                            BrandId = 1,
                            CategoryId = 2,
                            Description = "this is Jacket ",
                            Name = "Jacket",
                            Picture = "jacketWoman2.jpeg",
                            Price = 564.0
                        },
                        new
                        {
                            Id = 11,
                            BrandId = 2,
                            CategoryId = 1,
                            Description = "this is Shirt ",
                            Name = "Shirt",
                            Picture = "shirtMan1.jpeg",
                            Price = 456.0
                        },
                        new
                        {
                            Id = 12,
                            BrandId = 1,
                            CategoryId = 1,
                            Description = "this is Shirt ",
                            Name = "Shirt",
                            Picture = "shirtMan2.jpeg",
                            Price = 326.0
                        },
                        new
                        {
                            Id = 13,
                            BrandId = 2,
                            CategoryId = 1,
                            Description = "this is Shirt ",
                            Name = "Shirt",
                            Picture = "shirtMan3.jpeg",
                            Price = 461.0
                        },
                        new
                        {
                            Id = 14,
                            BrandId = 3,
                            CategoryId = 1,
                            Description = "this is Shirt ",
                            Name = "Shirt",
                            Picture = "shirtMan4.jpeg",
                            Price = 324.0
                        },
                        new
                        {
                            Id = 15,
                            BrandId = 1,
                            CategoryId = 3,
                            Description = "this is Shoes ",
                            Name = "Shoes",
                            Picture = "shoesChild1.jpeg",
                            Price = 324.0
                        },
                        new
                        {
                            Id = 16,
                            BrandId = 2,
                            CategoryId = 3,
                            Description = "this is Shoes ",
                            Name = "Shoes",
                            Picture = "shoesChild2.jpeg",
                            Price = 356.0
                        },
                        new
                        {
                            Id = 17,
                            BrandId = 3,
                            CategoryId = 1,
                            Description = "this is Shoes ",
                            Name = "Shoes",
                            Picture = "shoesMan1.jpeg",
                            Price = 564.0
                        },
                        new
                        {
                            Id = 18,
                            BrandId = 1,
                            CategoryId = 1,
                            Description = "this is Shoes ",
                            Name = "Shoes",
                            Picture = "shoesMan2.jpeg",
                            Price = 222.0
                        },
                        new
                        {
                            Id = 19,
                            BrandId = 2,
                            CategoryId = 2,
                            Description = "this is Shoes ",
                            Name = "Shoes",
                            Picture = "shoesWoman1.jpeg",
                            Price = 333.0
                        },
                        new
                        {
                            Id = 20,
                            BrandId = 3,
                            CategoryId = 2,
                            Description = "this is Shoes ",
                            Name = "Shoes",
                            Picture = "shoesWoman2.jpeg",
                            Price = 264.0
                        });
                });

            modelBuilder.Entity("E_Commerce.DAL.models.order.DeliveryMethod", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.ToTable("deliveryMethods");
                });

            modelBuilder.Entity("E_Commerce.DAL.models.order.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderedStatus")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("deliveryMethodId")
                        .HasColumnType("int");

                    b.Property<string>("paymentIntentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("deliveryMethodId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("E_Commerce.DAL.models.order.productedOrdered", b =>
                {
                    b.Property<int>("productid")
                        .HasColumnType("int");

                    b.Property<int>("orderid")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("productid", "orderid");

                    b.HasIndex("orderid");

                    b.ToTable("productedOrdereds");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "http://schemas.microsoft.com/ws/2008/06/identity/claims/role",
                            ClaimValue = "Admin",
                            UserId = "1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "1",
                            RoleId = "1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("E_Commerce.DAL.models.Product", b =>
                {
                    b.HasOne("E_Commerce.DAL.models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.DAL.models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("E_Commerce.DAL.models.order.Order", b =>
                {
                    b.HasOne("E_Commerce.DAL.models.ApplicationUser", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.DAL.models.order.DeliveryMethod", "DeliveryMethod")
                        .WithMany("orders")
                        .HasForeignKey("deliveryMethodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("E_Commerce.DAL.models.order.Address", "Address", b1 =>
                        {
                            b1.Property<int>("OrderId")
                                .HasColumnType("int");

                            b1.Property<string>("city")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("firstName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("lastName")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("state")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("street")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("OrderId");

                            b1.ToTable("orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderId");
                        });

                    b.Navigation("Address");

                    b.Navigation("DeliveryMethod");

                    b.Navigation("User");
                });

            modelBuilder.Entity("E_Commerce.DAL.models.order.productedOrdered", b =>
                {
                    b.HasOne("E_Commerce.DAL.models.order.Order", "order")
                        .WithMany("orderItems")
                        .HasForeignKey("orderid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.DAL.models.Product", "product")
                        .WithMany("productedOrdereds")
                        .HasForeignKey("productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("order");

                    b.Navigation("product");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("E_Commerce.DAL.models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("E_Commerce.DAL.models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("E_Commerce.DAL.models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("E_Commerce.DAL.models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("E_Commerce.DAL.models.ApplicationUser", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("E_Commerce.DAL.models.Brand", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("E_Commerce.DAL.models.Category", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("E_Commerce.DAL.models.Product", b =>
                {
                    b.Navigation("productedOrdereds");
                });

            modelBuilder.Entity("E_Commerce.DAL.models.order.DeliveryMethod", b =>
                {
                    b.Navigation("orders");
                });

            modelBuilder.Entity("E_Commerce.DAL.models.order.Order", b =>
                {
                    b.Navigation("orderItems");
                });
#pragma warning restore 612, 618
        }
    }
}
