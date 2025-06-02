using Aibidia.Homework.Application.Resumes.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aibidia.Homework.API.Controllers;


[ApiController]
public class ResumesController: ControllerBase
{
    public ResumesController()
    {
    }

    [HttpGet("api/resumes/all")]
    [ProducesResponseType(typeof(IList<ResumeDto>), StatusCodes.Status200OK)]
    [AllowAnonymous]
    public ActionResult<IList<ResumeDto>> GetAll()
    {
         var resumeList = new List<ResumeDto>
        {
            new ResumeDto
            {
                Id = 1,
                Name = "John Doe",
                Description = "Experienced software engineer with 5+ years in full-stack development."
            },
            new ResumeDto
            {
                Id = 2,
                Name = "Jane Smith",
                Description = "Project manager with expertise in agile methodologies and team leadership."
            },
            new ResumeDto
            {
                Id = 3,
                Name = "Alice Johnson",
                Description = "UX/UI designer skilled in creating intuitive and user-friendly interfaces."
            },
            new ResumeDto
            {
                Id = 4,
                Name = "Bob Brown",
                Description = "Data scientist with a focus on machine learning and data visualization."
            }
        };

        return Ok(resumeList);
    }
}
