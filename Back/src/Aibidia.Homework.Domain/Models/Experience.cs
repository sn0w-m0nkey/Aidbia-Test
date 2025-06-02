namespace Aibidia.Homework.Domain.Models;

public class Experience
{
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public string Position { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string Website { get; set; } 
    public string Description { get; set; }

    public int ResumeId { get; set; }
    public Resume Resume { get; set; }
}
