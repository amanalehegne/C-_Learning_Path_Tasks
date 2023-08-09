using Microsoft.EntityFrameworkCore;
using BlogAppConsole.Entities;

namespace BlogAppConsole.DataControl;
public class BlogAppContext : DbContext
{
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }

    // Database Connection
    public string DbConnectionString { get; }
    public string DbPath { get; }

    public BlogAppContext()
    {
        DbConnectionString = "User ID =amanuelwubete; Password=AMAN#69loza; Server=localhost; Port=5432;Database=blogappconsole;";
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(DbConnectionString);
    }
}