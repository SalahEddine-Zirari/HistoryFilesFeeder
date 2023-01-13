using HistoryFilesFeeder.Epex;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryFilesFeeder.Ef;

public class DataHistoryDbContext : DbContext
{
    public DbSet<IntradayContinuous> IntradayContinuous { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=ODIN;Initial Catalog=test;Integrated security=true;Encrypt=no");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<IntradayContinuous>()
            .HasKey(x=>new {x.DeliveryStart,x.DeliveryEnd,x.Area});


    }
}
