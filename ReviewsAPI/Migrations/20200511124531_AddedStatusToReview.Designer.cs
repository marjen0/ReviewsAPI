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
    [Migration("20200511124531_AddedStatusToReview")]
    partial class AddedStatusToReview
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
                            ConfirmedAt = new DateTime(2020, 5, 11, 15, 45, 31, 427, DateTimeKind.Local).AddTicks(4949),
                            Cons = "nėra dalių",
                            CreatedAt = new DateTime(2020, 5, 11, 15, 45, 31, 421, DateTimeKind.Local).AddTicks(2468),
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
                            ConfirmedAt = new DateTime(2020, 5, 11, 15, 45, 31, 427, DateTimeKind.Local).AddTicks(7550),
                            Cons = "nėra dalių",
                            CreatedAt = new DateTime(2020, 5, 11, 15, 45, 31, 427, DateTimeKind.Local).AddTicks(7520),
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
                            ConfirmedAt = new DateTime(2020, 5, 11, 15, 45, 31, 427, DateTimeKind.Local).AddTicks(7576),
                            Cons = "nėra dalių",
                            CreatedAt = new DateTime(2020, 5, 11, 15, 45, 31, 427, DateTimeKind.Local).AddTicks(7571),
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
