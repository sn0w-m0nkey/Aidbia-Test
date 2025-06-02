using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Aibidia.Homework.Domain.Models;

public class Resume
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Summary { get; set; } 
    
    public string? Description { get; set; }
    
    public bool IsActive { get; set; }
    
    public ICollection<Experience> Experiences { get; set; }
    public ICollection<Education> Educations { get; set; }
    public ICollection<Skill> Skills { get; set; } 
    public ICollection<Interest> Interests { get; set; } 
}

public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
{
    public void Configure(EntityTypeBuilder<Resume> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .HasMany(x => x.Experiences)
            .WithOne(x => x.Resume)
            .HasForeignKey(x => x.ResumeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.Educations)
            .WithOne(x => x.Resume)
            .HasForeignKey(x => x.ResumeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasMany(x => x.Skills)
            .WithOne(x => x.Resume)
            .HasForeignKey(x => x.ResumeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}