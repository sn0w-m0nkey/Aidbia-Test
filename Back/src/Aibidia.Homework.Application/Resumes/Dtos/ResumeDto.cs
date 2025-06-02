namespace Aibidia.Homework.Application.Resumes.Dtos;

public class ResumeDto
{
    public int Id { get; set; }

    public string FullName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public string Summary { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }

    public List<ExperienceDto> Experiences { get; set; }
    public List<EducationDto> Educations { get; set; }
    public List<SkillDto> Skills { get; set; }
    public List<InterestDto> Interests { get; set; }
}
