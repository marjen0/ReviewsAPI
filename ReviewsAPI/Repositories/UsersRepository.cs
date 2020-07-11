using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ReviewsAPI.Data;
using ReviewsAPI.Models;
using ReviewsAPI.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsAPI.Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        private readonly ReviewsContext _context;
        public UsersRepository(ReviewsContext context) : base(context)
        {
            _context = context ?? throw new ArgumentException(nameof(context));
            
        }
    }
}
