namespace Aibidia.Homework.Domain.Models;

public class Education
{
    public int Id { get; set; }
    public string Institution { get; set; }
    public string Qualification { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public int ResumeId { get; set; }
    public Resume Resume { get; set; }
}
