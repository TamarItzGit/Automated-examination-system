using DalFacade.DalApi;
using DalFacade.DO;
using DO;

namespace Dal;

internal class DalStudentQuestion : IStudentQuestion
{
    public int Create(StudentQuestion item)
    {
        // בדיקה האם הסטודנט כבר ענה או קשור לשאלה הזו במבחן הזה
        if (DataSource.StudentQuestions.Any(sq => sq.StudentId == item.StudentId && sq.QuestionId == item.QuestionId))
            throw new Exception("This student question relationship already exists");

        // יצירת מספר מזהה (Id) חדש ואוטומטי לישות עצמה
        int newId = DataSource.Config.NextStudentQuestionId;
        StudentQuestion copy = item with { Id = newId }; // יצירת עותק עם המזהה החדש

        DataSource.StudentQuestions.Add(copy);
        return newId;
    }

    public StudentQuestion? Read(int id) =>
        DataSource.StudentQuestions.FirstOrDefault(sq => sq.Id == id);

    public List<StudentQuestion> ReadAll() =>
        new List<StudentQuestion>(DataSource.StudentQuestions);

    public void Update(StudentQuestion item)
    {
        var existing = Read(item.Id);
        if (existing == null)
            throw new Exception($"StudentQuestion with ID {item.Id} does not exist");

        DataSource.StudentQuestions.Remove(existing);
        DataSource.StudentQuestions.Add(item);
    }

    public void Delete(int id)
    {
        var existing = Read(id);
        if (existing == null)
            throw new Exception($"StudentQuestion with ID {id} does not exist");

        DataSource.StudentQuestions.Remove(existing);
    }
}