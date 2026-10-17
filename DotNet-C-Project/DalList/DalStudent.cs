using DalFacade.DalApi;
using DalFacade.DO;
using DO;

namespace Dal;

internal class DalStudent : IStudent
{
    public int Create(Student item)
    {
        // בדיקה האם הסטודנט כבר קיים
        if (DataSource.Students.Any(s => s.Id == item.Id))
            throw new Exception($"Student with ID {item.Id} already exists");

        DataSource.Students.Add(item);
        return item.Id;
    }

    public Student? Read(int id)
    {
        return DataSource.Students.FirstOrDefault(s => s.Id == id);
    }

    public List<Student> ReadAll()
    {
        return new List<Student>(DataSource.Students);
    }

    public void Update(Student item)
    {
        var existing = Read(item.Id);
        if (existing == null)
            throw new Exception($"Student with ID {item.Id} does not exist");

        DataSource.Students.Remove(existing);
        DataSource.Students.Add(item);
    }

    public void Delete(int id)
    {
        var existing = Read(id);
        if (existing == null)
            throw new Exception($"Student with ID {id} does not exist");

        DataSource.Students.Remove(existing);
    }
}