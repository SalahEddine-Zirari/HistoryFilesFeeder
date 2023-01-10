using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HistoryFilesFeeder.Epex.Epex.EntityFramework;

public class IntradayContinuousDbContext : DbContext
{
    public DbSet<IntradayContinuous> IntradayContinuous { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=.\SQLExpress;Database=DataHistory;Trusted_Connection=true;Encrypt=no");
    }
}
