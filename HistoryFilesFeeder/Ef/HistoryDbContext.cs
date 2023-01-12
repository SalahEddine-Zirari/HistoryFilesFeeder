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
        optionsBuilder.UseSqlServer(@"Data Source=ODIN;Initial Catalog=DataHistory;Integrated security=true;Encrypt=no");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IntradayContinuous>()
            .HasKey(x => x.Id);
        modelBuilder.Entity<IntradayContinuous>()
           .Property(x => x.Id);

        modelBuilder.Entity<IntradayContinuous>()
           .Property(x => x.DeliveryStart);
        modelBuilder.Entity<IntradayContinuous>()
                 .Property(x => x.DeliveryEnd);
        modelBuilder.Entity<IntradayContinuous>()
                 .Property(x => x.Area);
        modelBuilder.Entity<IntradayContinuous>()
                 .Property(x => x.LowPrice);
        modelBuilder.Entity<IntradayContinuous>()
                 .Property(x => x.HighPrice);
        modelBuilder.Entity<IntradayContinuous>()
            .Property(x => x.LastPrice);
        modelBuilder.Entity<IntradayContinuous>()
                .Property(x => x.WeightedAveragePrice);
        modelBuilder.Entity<IntradayContinuous>()
                .Property(x => x.Currency);
        modelBuilder.Entity<IntradayContinuous>()
                .Property(x => x.LastPriceTimestamp);
        modelBuilder.Entity<IntradayContinuous>()
            .Property(x => x.VolumeBuy);
        modelBuilder.Entity<IntradayContinuous>()
            .Property(x => x.VolumeSell);
        modelBuilder.Entity<IntradayContinuous>()
                .Property(x => x.VolumeUnit);


    }
}
