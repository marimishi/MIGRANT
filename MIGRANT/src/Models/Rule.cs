public class Rule
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }

    public List<Answer> Answers { get; set; } = new List<Answer>();

    public string? ToDo { get; set; } 
    public string? ToGet { get; set; } 
    public DateTime? Date { get; set; }
}
