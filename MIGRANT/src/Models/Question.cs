public class Question
{
    public int Id { get; set; }
    public string? QuestionText { get; set; }
    public List<PossibleAnswer> possibleAnswers = new List<PossibleAnswer>();
}
