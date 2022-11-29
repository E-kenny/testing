using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WalletApp.Models.Entities;

namespace WalletApp.Infrastructure
{
    public class AppDbContext : IdentityDbContext<User>
    {
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> Options) : base(Options)
        {

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Wallet>().ToTable("Wallet");
            modelBuilder.Entity<Transaction>().ToTable("Transaction");
        }


    }
}