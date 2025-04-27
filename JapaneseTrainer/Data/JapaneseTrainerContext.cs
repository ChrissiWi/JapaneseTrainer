using Microsoft.EntityFrameworkCore;
using JapaneseTrainer.Models;

namespace JapaneseTrainer.Data;

public class JapaneseTrainerContext : DbContext
{
    public DbSet<Vocabulary> Vocabularies { get; set; }

    public JapaneseTrainerContext(DbContextOptions<JapaneseTrainerContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vocabulary>()
            .HasIndex(v => v.JapaneseWord)
            .IsUnique();
    }
} 