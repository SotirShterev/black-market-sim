using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class BlackMarketDBContext : DbContext
    {
        public DbSet<Artifact> Artifacts { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>().HasOne(m => m.Buyer)
                        .WithMany(t => t.Buyers)
                        .HasForeignKey(m => m.BuyerId).OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Transaction>().HasOne(m => m.Seller)
                        .WithMany(t => t.Sellers)
                        .HasForeignKey(m => m.SellerId).OnDelete(DeleteBehavior.NoAction);
        }
 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=RAINBOWDRAGON;Database=BlackMarketSimulator;User Id=soti;Password=sotipass;");
        }

    }
}
