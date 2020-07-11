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
    [Migration("20200507112317_AddUserPassword")]
    partial class AddUserPassword
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

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(2000);

                    b.HasKey("Id");

                    b.HasIndex("AdminId");

                    b.HasIndex("RegularUserId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("ReviewsAPI.Models.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("Role");

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