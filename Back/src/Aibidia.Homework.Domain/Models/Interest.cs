namespace Aibidia.Homework.Domain.Models;

public class Interest
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public int ResumeId { get; set; }
    public Resume Resume { get; set; }
}
