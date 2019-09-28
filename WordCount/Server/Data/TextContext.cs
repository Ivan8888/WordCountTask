using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Data
{
    public class TextContext : DbContext
    {
        public TextContext(DbContextOptions<TextContext> options) : base(options)
        {
        }

        public DbSet<TextData> TextDataTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TextData>().HasData(
                new TextData
                {
                    Id = 1,
                    Text = "This is first text from database"
                },
                new TextData
                {
                    Id = 2,
                    Text = "This is second text from database"
                },
                new TextData
                {
                    Id = 3,
                    Text = "This is third text from database"
                }
            );
        }
    }
}
