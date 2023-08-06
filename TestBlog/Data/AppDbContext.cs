﻿using Microsoft.EntityFrameworkCore;

namespace TestBlog.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set;  }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
    }
}
