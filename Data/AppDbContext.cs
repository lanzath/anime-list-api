using AnimeList.Models;
using Microsoft.EntityFrameworkCore;

namespace AnimeList.Data;

public class AppDbContext : DbContext
{
    public DbSet<Anime> Animes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite("Datasource=app.db;Cache=Shared");
}
