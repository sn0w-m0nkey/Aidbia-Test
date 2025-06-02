using Aibidia.Homework.Application.Resumes.Dtos;
using Aibidia.Homework.Domain.Models;
using AutoMapper;

namespace Aibidia.Homework.Application.Resumes.Mapping;

public class ResumeProfile : Profile
{
    public ResumeProfile()
    {
        CreateMap<Resume, ResumeDto>();
        CreateMap<Experience, ExperienceDto>();
        CreateMap<Education, EducationDto>();
        CreateMap<Skill, SkillDto>();
        CreateMap<Interest, InterestDto>();
    }
}