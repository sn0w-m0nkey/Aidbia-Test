using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Aibidia.Homework.Domain.Models;

public class Resume
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}

public class ResumeConfiguration : IEntityTypeConfiguration<Resume>
{
    public void Configure(EntityTypeBuilder<Resume> builder)
    {
        builder.HasKey(e => e.Id);
    }
}