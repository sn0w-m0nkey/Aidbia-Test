using Aibidia.Homework.Application.Resumes.Dtos;
using Aibidia.Homework.Domain.Models.Views;
using AutoMapper;

namespace Aibidia.Homework.Application.Resumes.Mapping;

public class ResumeViewProfile : Profile
{
    public ResumeViewProfile()
    {
        CreateMap<ActiveResumeView, ActiveResumeViewDto>();
    }
}
