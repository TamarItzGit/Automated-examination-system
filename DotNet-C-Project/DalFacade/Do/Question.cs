using Do;

namespace DalFacade.DO;


/// <summary>
/// מייצג שאלה במאגר השאלות
/// </summary>
/// <param name="Id">מספר מזהה ייחודי לשאלה</param>
/// <param name="Subject">נושא השאלה</param>
/// <param name="Content">תוכן השאלה</param>
/// <param name="CorrectAnswerId">מזהה התשובה הנכונה</param>
public record Question(
    int Id,
    Subject Subject,
    string Content,
    int CorrectAnswerId
)
{
    public Question() : this(0, default, string.Empty, 0) { }
}