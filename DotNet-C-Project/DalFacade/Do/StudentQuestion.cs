namespace DO;

/// <summary>
/// מייצג את הקשר בין תלמיד, בחינה, שאלה והתשובה שבחר
/// </summary>
/// <param name="StudentId">מזהה התלמיד</param>
/// <param name="TestId">מזהה הבחינה</param>
/// <param name="QuestionId">מזהה השאלה</param>
/// <param name="SelectedAnswerId">מזהה התשובה שנבחרה בפועל ע"י התלמיד</param>
public record StudentQuestion(
    int Id,             
    int StudentId,
    int TestId,
    int QuestionId,
    int SelectedAnswerId
)
{
    public StudentQuestion() : this(0, 0, 0, 0, 0) { }
}