namespace Aibidia.Homework.Application.Resumes.Dtos;

public class ActiveResumeViewDto
{    
    public int Id { get; set; }

    public string FullName { get; set; }    
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public string Summary { get; set; }
    public string Description { get; set; }

    public string ExperiencesJson { get; set; }
    public string EducationsJson { get; set; }
    public string SkillsJson { get; set; }
    public string InterestsJson { get; set; }
}
