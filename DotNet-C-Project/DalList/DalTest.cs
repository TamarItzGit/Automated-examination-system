using DalFacade.DO;
using DalFacade.DalApi;

namespace Dal;

internal class DalTest : ITest
{
    public int Create(Test item)
    {
        int newId = DataSource.Config.NextTestId;
        Test copy = item with { Id = newId };
        DataSource.Tests.Add(copy);
        return newId;
    }

    public Test? Read(int id)
    {
        return DataSource.Tests.FirstOrDefault(t => t.Id == id);
    }

    public List<Test> ReadAll()
    {
        return new List<Test>(DataSource.Tests);
    }

    public void Update(Test item)
    {
        var existing = Read(item.Id);
        if (existing == null)
            throw new Exception($"Test with ID {item.Id} does not exist");

        DataSource.Tests.Remove(existing);
        DataSource.Tests.Add(item);
    }

    public void Delete(int id)
    {
        var existing = Read(id);
        if (existing == null)
            throw new Exception($"Test with ID {id} does not exist");

        DataSource.Tests.Remove(existing);
    }
}