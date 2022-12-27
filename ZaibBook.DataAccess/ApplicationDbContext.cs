﻿using Microsoft.EntityFrameworkCore;
using ZaibBook.Models;

namespace ZaibBook.DataAccess
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
    }
}
