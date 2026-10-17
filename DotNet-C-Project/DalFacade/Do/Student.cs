namespace DO;

/// <summary>
/// מייצג תלמיד (נבחן) במערכת
/// </summary>
/// <param name="Id">תעודת זהות / מזהה התלמיד</param>
/// <param name="Name">שם התלמיד</param>
/// <param name="TestId">מזהה הבחינה שאליה משתייך</param>
/// <param name="Grade">ציון הבחינה</param>
public record Student(
    int Id,
    string Name,
    int TestId,
    int Grade
)
{
    public Student() : this(0, string.Empty, 0, 0) { }
}