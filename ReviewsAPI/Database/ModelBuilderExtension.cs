using Microsoft.EntityFrameworkCore;
using ReviewsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ReviewsAPI.Data
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>().HasData(
                new Review() { Id = 1, Text = "labai geras motociklas", Pros = "Negenda", Cons = "nėra dalių", Model = "Suzuki VTR 1200", IsRecommended = true, CreatedAt = DateTime.Now, ConfirmedAt = DateTime.Now, RegularUserId=14 },
                new Review() { Id = 2, Text = "geras motociklas", Pros = "Negenda", Cons = "nėra dalių", Model = "Honda CBR 600", IsRecommended = true, CreatedAt = DateTime.Now, ConfirmedAt = DateTime.Now, RegularUserId=14 },
                new Review() { Id = 3, Text = "labai geras motociklas", Pros = "Negenda", Cons = "nėra dalių", Model = "Suzuki RMZ 450", IsRecommended = true, CreatedAt = DateTime.Now, ConfirmedAt = DateTime.Now, RegularUserId=14 }
            );
        }
    }
}
