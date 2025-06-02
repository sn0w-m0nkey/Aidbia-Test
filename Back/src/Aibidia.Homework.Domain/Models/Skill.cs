namespace Aibidia.Homework.Domain.Models;

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int ResumeId { get; set; }
    public Resume Resume { get; set; }
}
