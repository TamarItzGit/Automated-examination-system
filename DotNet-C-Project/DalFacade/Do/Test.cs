using Do;

/// <summary>
/// מייצג בחינה במערכת
/// </summary>
/// <param name="Id">מספר מזהה ייחודי לבחינה</param>
/// <param name="Subject">נושא הבחינה</param>
/// <param name="Date">תאריך הבחינה</param>
/// <param name="QuestionsCount">מספר השאלות בבחינה</param>
public record Test(
    int Id,
    Subject Subject,
    DateTime Date,
    int QuestionsCount
)
{
    public Test() : this(0, default, DateTime.Now, 0) { }
}
