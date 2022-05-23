using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Tricktionary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tricktionary.Data
{
    public class TrickContext : DbContext
    {
        public DbSet<Trick> Tricks { get; set; }
        public TrickContext(DbContextOptions<TrickContext> options) : base(options) { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) { 
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Trick>().HasData(
                new Trick() { Id = 1, Name = "Royale", Description = "Two footed groove trick"},
                new Trick() { Id = 2, Name = "Soul", Description = "A lot of people learn this trick first"},
                new Trick() { Id = 3, Name = "Makio", Description = "One footed soul, but people say it doesn't count if you don't grab it" },
                new Trick() { Id = 4, Name = "Acid", Description = "A trick you feel in the hips"},
                new Trick() { Id = 5, Name = "Mistrial", Description = "A simple but steezy trick"},
                new Trick() { Id = 6, Name = "Mizou", Description = "A good trick for beginners"}
                );
        }
    }
}
