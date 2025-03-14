public class Migrant 
{
    public int UserId { get; set; }
    public User? User { get; set; }
    public List<Answer> Answers { get; set; } = new List<Answer>();
}
