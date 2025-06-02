using Aibidia.Homework.Application.Resumes.Dtos;

namespace Aibidia.Homework.API.Services;

public interface IResumeService
{
    Task<ResumeDto?> GetResumeAsync(int id);
    Task<List<ResumeDto>> GetAllResumesAsync();
}
