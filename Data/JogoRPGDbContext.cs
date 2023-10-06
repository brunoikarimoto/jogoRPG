using API_JogoRPG.Models;
using Microsoft.EntityFrameworkCore;

namespace API_JogoRPG.Data;

public class JogoRPGDbContext : DbContext
{
    public DbSet<Player>? Player {get; set;}

    public DbSet<Quest>? Quest {get; set;}
    
    public DbSet<Montaria> Montaria {get; set;}
    
    public DbSet<Classe> Classe {get; set;}
    
    public DbSet<Item> Item {get; set;}

    public DbSet<Map> Map {get; set;}

    public DbSet<Boss> Boss {get; set;}

    public DbSet<Raid> Raid {get; set;}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=jogoRPG.db;Cache=Shared");
    }
}
