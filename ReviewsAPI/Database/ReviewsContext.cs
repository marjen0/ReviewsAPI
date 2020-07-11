using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReviewsAPI.Models;
using Microsoft.AspNetCore.Identity;

namespace ReviewsAPI.Data
{
    public class ReviewsContext : IdentityDbContext<User,IdentityRole<long>,long>
    {
        public ReviewsContext(DbContextOptions<ReviewsContext> options):base(options)
        {

        }
        public DbSet<Review> Reviews { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<RegularUser> RegularUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Review>().Property(r => r.CreatedAt).HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
                .Ignore(x => x.NormalizedUserName)
                .Ignore(x => x.NormalizedEmail)
                .Ignore(x => x.PhoneNumberConfirmed)
                .Ignore(x => x.TwoFactorEnabled)
                .Ignore(x => x.LockoutEnd)
                .Ignore(x => x.LockoutEnabled)
                .Ignore(x => x.AccessFailedCount)
                .Ignore(x => x.ConcurrencyStamp);
            modelBuilder.Ignore<IdentityRoleClaim<string>>();
            modelBuilder.Ignore<IdentityUserRole<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityRole>();

            //modelBuilder.Seed();
        }
    }
}
