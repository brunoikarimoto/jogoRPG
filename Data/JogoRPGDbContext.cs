using API_JogoRPG.Models;
using Microsoft.EntityFrameworkCore;

namespace API_JogoRPG.Data;

public class JogoRPGDbContext : DbContext
{
    public DbSet<Player>? Player {get; set;}

    public DbSet<Quest>? Quest {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=jogoRPG.db;Cache=Shared");
    }
}
