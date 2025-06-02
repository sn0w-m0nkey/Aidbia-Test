using Aibidia.Homework.Domain.Models;
using Aibidia.Homework.Domain.Models.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Aibidia.Homework.DataAccess;

public class ApplicationDbMultiTenantContext : DbContext, IApplicationDbContext
{
    private readonly ITenantService _tenantService;

    public ApplicationDbMultiTenantContext(
        ITenantService tenantService)
    {
        _tenantService = tenantService;
    }

    public DbSet<Resume> Resumes { get; set; } = null!;
    public DbSet<Experience> Experiences { get; set; } = null!;
    public DbSet<Education> Educations { get; set; } = null!;
    public DbSet<Skill> Skills { get; set; } = null!;

    public DbSet<ResumeActive> ActiveResumes { get; set; } = null!;

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Remove(typeof(TableNameFromDbSetConvention));
        base.ConfigureConventions(configurationBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");

        modelBuilder.ApplyConfiguration(new ResumeConfiguration());
        modelBuilder.ApplyConfiguration(new ResumeActiveConfiguration());

        modelBuilder.Entity<ResumeActive>().Metadata.SetIsTableExcludedFromMigrations(true);

        modelBuilder.Entity<Resume>()
            .HasMany(r => r.Experiences)
            .WithOne(e => e.Resume)
            .HasForeignKey(e => e.ResumeId);

        modelBuilder.Entity<Resume>()
            .HasMany(r => r.Educations)
            .WithOne(e => e.Resume)
            .HasForeignKey(e => e.ResumeId);

        modelBuilder.Entity<Resume>()
            .HasMany(r => r.Skills)
            .WithOne(s => s.Resume)
            .HasForeignKey(s => s.ResumeId);

        modelBuilder.Entity<Resume>()
            .HasMany(r => r.Interests)
            .WithOne(i => i.Resume)
            .HasForeignKey(i => i.ResumeId);
        
        // Seed data for Resumes, Experiences, Education, Skills, and Interests
        modelBuilder.Entity<Resume>().HasData(
            new Resume
            {
                Id = 1,
                FullName = "Owen M",
                Email = "owen@gmail.com",
                PhoneNumber = "07123 456 789",
                Summary = "Full Stack Developer with 5+ years of experience.",
                Description = "Looking for remote backend roles.",
                IsActive = true
            },
            new Resume
            {
                Id = 2,
                FullName = "Jane Doe",
                Email = "jane.doe@example.com",
                PhoneNumber = "07234 567 890",
                Summary = "Frontend Developer with a passion for UI/UX.",
                Description = "Open to contract opportunities.",
                IsActive = true
            }
        );

        modelBuilder.Entity<Experience>().HasData(
            new Experience
            {
                Id = 1,
                CompanyName = "Kainos",
                Position = "Software Engineer",
                StartDate = new DateTime(2021, 8, 16),
                EndDate = null,
                Description = "Worked on lots of government projects.",
                Website = "https://kainos.com",
                ResumeId = 1
            },
            new Experience
            {
                Id = 2,
                CompanyName = "Mr Lender",
                Position = "Senior Developer",
                StartDate = new DateTime(2015, 1, 1),
                EndDate = new DateTime(2020, 10, 26),
                Description = "Ripped people off with high interest loans.",
                Website = "https://mrlender.com",
                ResumeId = 1
            },
            new Experience
            {
                Id = 3,
                CompanyName = "Some Company",
                Position = "Frontend Engineer",
                StartDate = new DateTime(2012, 5, 1),
                EndDate = new DateTime(2024, 8, 31),
                Description = "Developed lots of web applications.",
                Website = "https://somecompany.com",
                ResumeId = 2
            }
        );

        modelBuilder.Entity<Education>().HasData(
            new Education
            {
                Id = 1,
                Institution = "NZ University",
                Qualification = "B.Sc. in Computer Science",
                StartDate = new DateTime(2015, 9, 1),
                EndDate = new DateTime(2019, 6, 30),
                ResumeId = 1
            },            
            new Education
            {
                Id = 2,
                Institution = "Microsoft",
                Qualification = "AZ-900: Microsoft Azure Fundamentals",
                StartDate = new DateTime(2023, 9, 1),
                EndDate = new DateTime(2022, 3, 30),
                ResumeId = 1
            },
            new Education
            {
                Id = 3,
                Institution = "Some other University",
                Qualification = "B.Sc. in Information Technology",
                StartDate = new DateTime(2014, 9, 1),
                EndDate = new DateTime(2018, 6, 30),
                ResumeId = 2
            }
        );

        modelBuilder.Entity<Skill>().HasData(
            new Skill { Id = 1, Name = "C#", ResumeId = 1 },
            new Skill { Id = 2, Name = ".NET Core", ResumeId= 1 },
            new Skill { Id = 3, Name = "Vue",  ResumeId = 1 },
            
            new Skill { Id = 4, Name = "VB", ResumeId = 2 },
            new Skill { Id = 5, Name = ".NET", ResumeId= 2 },
            new Skill { Id = 6, Name = "Blazor",  ResumeId = 2 }
        );

        modelBuilder.Entity<Interest>().HasData(
            new Interest { Id = 1, Name = "Muay Thai", ResumeId = 1 },
            new Interest { Id = 2, Name = "Diving", ResumeId = 1 },
            
            new Interest { Id = 3, Name = "Traveling", ResumeId = 2 },
            new Interest { Id = 4, Name = "Reading", ResumeId = 2 }
        );
    }

    public async Task<int> SaveChangesAsync()
    {
        return await base.SaveChangesAsync();
    }

    public async Task ExecuteCommandAsync(string rawSqlQuery, params object[] parameters)
    {
        await using var transaction = await Database.BeginTransactionAsync();
        try
        {
            await Database.ExecuteSqlRawAsync(rawSqlQuery, parameters);
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = _tenantService.GetConnectionString();
        optionsBuilder.UseSqlServer(connectionString);
    }
}
