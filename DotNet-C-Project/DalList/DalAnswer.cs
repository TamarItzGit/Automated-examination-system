using DalFacade.DalApi;
using DalFacade.DO;
using DO;

namespace Dal;

internal class DalAnswer : IAnswer
{
    public int Create(Answer item)
    {
        if (DataSource.Answers.Any(a => a.Id == item.Id))
            throw new Exception($"Answer with ID {item.Id} already exists");

        DataSource.Answers.Add(item);
        return item.Id;
    }

    public Answer? Read(int id) => DataSource.Answers.FirstOrDefault(a => a.Id == id);
    public List<Answer> ReadAll() => new List<Answer>(DataSource.Answers);

    public void Update(Answer item)
    {
        var existing = Read(item.Id);
        if (existing == null) throw new Exception($"Answer with ID {item.Id} does not exist");
        DataSource.Answers.Remove(existing);
        DataSource.Answers.Add(item);
    }

    public void Delete(int id)
    {
        var existing = Read(id);
        if (existing == null) throw new Exception($"Answer with ID {id} does not exist");
        DataSource.Answers.Remove(existing);
    }
}