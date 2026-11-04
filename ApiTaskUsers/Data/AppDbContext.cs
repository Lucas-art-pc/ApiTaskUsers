using ApiTaskUsers.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiTaskUsers.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Question> Questions => Set<Question>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>()
            .HasKey(user => user.Id);

        modelBuilder.Entity<Question>()
            .HasOne(question => question.User)
            .WithMany(user => user.Questions)
            .HasForeignKey(question => question.UserId);


    }
}
