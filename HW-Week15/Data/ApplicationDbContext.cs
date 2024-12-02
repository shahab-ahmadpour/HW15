using HW_Week15.Configuration;
using HW_Week15.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Week15.Data;

public class ApplicationDbContext : DbContext
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=DESKTOP-PU6OMQ0\\SQLEXPRESS;Database=HW15;Integrated Security=true;User ID=sa;Password=P@ssw0rd;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "Shahab" },
            new User { Id = 2, Name = "Naser" }
        );

        modelBuilder.Entity<Card>().HasData(
            new Card
            {
                Id = 1,
                CardNumber = "5352141112555355",
                Password = "0000",
                Balance = 3000.00m,
                UserId = 1
            },
            new Card
            {
                Id = 2,
                CardNumber = "1234567890123456",
                Password = "0000",
                Balance = 2000.00m,
                UserId = 1
            },
            new Card
            {
                Id = 3,
                CardNumber = "1111222233334444",
                Password = "0000",
                Balance = 1500.00m,
                UserId = 2
            }
        );

        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new CardConfiguration());
        modelBuilder.ApplyConfiguration(new TransactionConfiguration());
    }
}
