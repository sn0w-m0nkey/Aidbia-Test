using Aibidia.Homework.Application.Resumes.Dtos;
using Aibidia.Homework.DataAccess;
using Aibidia.Homework.Domain.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Aibidia.Homework.API.Services;

public class ResumeService(IMapper mapper, ApplicationDbMultiTenantContext context) : IResumeService
{
    public async Task<ResumeDto?> GetResumeAsync(int id)
    {
        var resume = await context.Resumes
            .Include(r => r.Experiences)
            .Include(r => r.Educations)
            .Include(r => r.Skills)
            .Include(r => r.Interests)
            .FirstOrDefaultAsync(r => r.Id == id);

        return resume == null ? null : mapper.Map<ResumeDto>(resume);
    }
    
    public async Task<List<ResumeDto>> GetAllResumesAsync()
    {
        var resumes = await context.Resumes
            .Include(r => r.Experiences)
            .Include(r => r.Educations)
            .Include(r => r.Skills)
            .Include(r => r.Interests)
            .ToListAsync();

        return mapper.Map<List<ResumeDto>>(resumes);
    }
}
