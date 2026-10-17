namespace DO;

/// <summary>
/// מייצג תשובה לשאלה במערכת
/// </summary>
/// <param name="Id">מספר מזהה ייחודי לתשובה</param>
/// <param name="QuestionId">מזהה הש שאלה שאליה משתייכת התשובה</param>
/// <param name="Content">תוכן התשובה</param>
public record Answer(
    int Id,
    int QuestionId,
    string Content
)
{
    public Answer() : this(0, 0, string.Empty) { }
}