public class PossibleAnswer
{
    public int Id { get; set; }
    public Question? Question { get; set; } 
    public string AnswerText { get; set; } = string.Empty; 
}
