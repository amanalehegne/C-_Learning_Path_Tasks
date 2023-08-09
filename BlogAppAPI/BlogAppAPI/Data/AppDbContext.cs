using Microsoft.EntityFrameworkCore;
using BlogAppAPI.Models;


namespace BlogAppAPI.Data;
public class AppDbContext : DbContext
{
    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<Comment> Comments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasOne(p => p.Post)
            .WithMany(c => c.Comments)
            .HasForeignKey(id => id.PostId)
            .OnDelete(DeleteBehavior.Cascade)
            .HasConstraintName("FK_Comment_Post");
        });

        modelBuilder.Entity<Post>().Property(p => p.CreatedAt).HasDefaultValueSql("now()");

        modelBuilder.Entity<Comment>().Property(c => c.CreatedAt).HasDefaultValueSql("now()");

    }
}