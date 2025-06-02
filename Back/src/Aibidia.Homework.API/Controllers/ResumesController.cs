using Aibidia.Homework.API.Services;
using Aibidia.Homework.Application.Resumes.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aibidia.Homework.API.Controllers;


[ApiController]
public class ResumesController: ControllerBase
{
    private readonly IResumeService _resumeService;

    public ResumesController(IResumeService resumeService)
    {
        _resumeService = resumeService;
    }

    [HttpGet("api/resumes/all")]
    [ProducesResponseType(typeof(IList<ResumeDto>), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public async Task<ActionResult<IList<ResumeDto>>> GetAll()
    {
        var resumes = await _resumeService.GetAllResumesAsync();
        
        return Ok(resumes);
    }
}
