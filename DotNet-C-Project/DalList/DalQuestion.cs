using DalFacade.DO;
using DalFacade.DalApi;

namespace Dal;

internal class DalQuestion : IQuestion
{
    public int Create(Question item)
    {
        int newId = DataSource.Config.NextQuestionId;
        Question copy = item with { Id = newId }; // יצירת עותק עם המספר הרץ החדש
        DataSource.Questions.Add(copy);
        return newId;
    }

    public Question? Read(int id)
    {
        return DataSource.Questions.FirstOrDefault(q => q.Id == id);
    }

    public List<Question> ReadAll()
    {
        return new List<Question>(DataSource.Questions);
    }

    public void Update(Question item)
    {
        var existing = Read(item.Id);
        if (existing == null)
            throw new Exception($"Question with ID {item.Id} does not exist");

        DataSource.Questions.Remove(existing);
        DataSource.Questions.Add(item);
    }

    public void Delete(int id)
    {
        var existing = Read(id);
        if (existing == null)
            throw new Exception($"Question with ID {id} does not exist");

        DataSource.Questions.Remove(existing);
    }
}