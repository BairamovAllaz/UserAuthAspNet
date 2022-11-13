using FirstAPI.App.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstAPI.App.Database;

public class Database : DbContext
{
    public DbSet<User> Users { get; set; }
    
    public Database() {}

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseMySql(Configuration[]);
    }
}