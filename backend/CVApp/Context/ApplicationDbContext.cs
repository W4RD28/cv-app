using Microsoft.EntityFrameworkCore;

namespace CVApp.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Models.User> Users { get; set; }
    public DbSet<Models.Work> Works { get; set; }
    public DbSet<Models.Education> Educations { get; set; }
    public DbSet<Models.Skill> Skills { get; set; }
    public DbSet<Models.Project> Projects { get; set; }
    public DbSet<Models.Social> Socials { get; set; }
    public DbSet<Models.Language> Languages { get; set; }
    public DbSet<Models.Certification> Certifications { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Models.User>().ToTable("users");
        modelBuilder.Entity<Models.Work>().ToTable("works");
        modelBuilder.Entity<Models.Education>().ToTable("educations");
        modelBuilder.Entity<Models.Skill>().ToTable("skills");
        modelBuilder.Entity<Models.Project>().ToTable("projects");
        modelBuilder.Entity<Models.Social>().ToTable("socials");
        modelBuilder.Entity<Models.Language>().ToTable("languages");
        modelBuilder.Entity<Models.Certification>().ToTable("certifications");
    }
}