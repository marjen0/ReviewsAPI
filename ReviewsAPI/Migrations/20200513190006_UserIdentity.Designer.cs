﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ReviewsAPI.Data;

namespace ReviewsAPI.Migrations
{
    [DbContext(typeof(ReviewsContext))]
    [Migration("20200513190006_UserIdentity")]
    partial class UserIdentity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ReviewsAPI.Models.Review", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AdminId");

                    b.Property<DateTime?>("ConfirmedAt");

                    b.Property<string>("Cons")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<DateTime?>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("getdate()");

                    b.Property<bool>("IsRecommended");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Pros")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<long>("RegularUserId");

                    b.Property<int>("Status");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("RegularUserId");

                    b.ToTable("Reviews");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            ConfirmedAt = new DateTime(2020, 5, 13, 22, 0, 5, 783, DateTimeKind.Local).AddTicks(9416),
                            Cons = "nėra dalių",
                            CreatedAt = new DateTime(2020, 5, 13, 22, 0, 5, 777, DateTimeKind.Local).AddTicks(9803),
                            IsRecommended = true,
                            Model = "Suzuki VTR 1200",
                            Pros = "Negenda",
                            RegularUserId = 4L,
                            Status = 0,
                            Text = "labai geras motociklas"
                        },
                        new
                        {
                            Id = 2L,
                            ConfirmedAt = new DateTime(2020, 5, 13, 22, 0, 5, 784, DateTimeKind.Local).AddTicks(1335),
                            Cons = "nėra dalių",
                            CreatedAt = new DateTime(2020, 5, 13, 22, 0, 5, 784, DateTimeKind.Local).AddTicks(1320),
                            IsRecommended = true,
                            Model = "Honda CBR 600",
                            Pros = "Negenda",
                            RegularUserId = 4L,
                            Status = 0,
                            Text = "geras motociklas"
                        },
                        new
                        {
                            Id = 3L,
                            ConfirmedAt = new DateTime(2020, 5, 13, 22, 0, 5, 784, DateTimeKind.Local).AddTicks(1352),
                            Cons = "nėra dalių",
                            CreatedAt = new DateTime(2020, 5, 13, 22, 0, 5, 784, DateTimeKind.Local).AddTicks(1348),
                            IsRecommended = true,
                            Model = "Suzuki RMZ 450",
                            Pros = "Negenda",
                            RegularUserId = 4L,
                            Status = 0,
                            Text = "labai geras motociklas"
                        });
                });

            modelBuilder.Entity("ReviewsAPI.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail");

                    b.Property<string>("NormalizedUserName");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("Role");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("User");
                });

            modelBuilder.Entity("ReviewsAPI.Models.Admin", b =>
                {
                    b.HasBaseType("ReviewsAPI.Models.User");

                    b.HasDiscriminator().HasValue("Admin");
                });

            modelBuilder.Entity("ReviewsAPI.Models.RegularUser", b =>
                {
                    b.HasBaseType("ReviewsAPI.Models.User");

                    b.HasDiscriminator().HasValue("RegularUser");
                });

            modelBuilder.Entity("ReviewsAPI.Models.Review", b =>
                {
                    b.HasOne("ReviewsAPI.Models.Admin")
                        .WithMany("ConfirmedReviews")
                        .HasForeignKey("AdminId");

                    b.HasOne("ReviewsAPI.Models.RegularUser")
                        .WithMany("PostedReviews")
                        .HasForeignKey("RegularUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}