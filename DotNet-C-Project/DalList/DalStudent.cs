using DalFacade.DalApi;
using DalFacade.DO;
using DO;
using Tools;
using System.Reflection;

namespace Dal;

internal class DalStudent : IStudent
{
    public int Create(Student item)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, "Starting Create Student");

        if (DataSource.Students.Any(s => s.Id == item.Id))
            throw new Exception($"Student with ID {item.Id} already exists");

        DataSource.Students.Add(item);

        LogManager.WriteToLog(projectName, funcName, $"Finished Create Student with ID: {item.Id}");
        return item.Id;
    }

    public Student? Read(int id)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Read Student for ID: {id}");

        Student? student = DataSource.Students.FirstOrDefault(s => s.Id == id);

        LogManager.WriteToLog(projectName, funcName, $"Finished Read Student for ID: {id}");
        return student;
    }
    public List<Student> ReadAll()
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, "Starting ReadAll Students");

        List<Student> students = new List<Student>(DataSource.Students);

        LogManager.WriteToLog(projectName, funcName, "Finished ReadAll Students");
        return students;
    }
    public void Update(Student item)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Update Student with ID: {item.Id}");

        var existing = Read(item.Id);
        if (existing == null) throw new Exception($"Student with ID {item.Id} does not exist");
        DataSource.Students.Remove(existing);
        DataSource.Students.Add(item);

        LogManager.WriteToLog(projectName, funcName, $"Finished Update Student with ID: {item.Id}");
    }
    public void Delete(int id)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Delete Student with ID: {id}");

        var existing = Read(id);
        if (existing == null) throw new Exception($"Student with ID {id} does not exist");
        DataSource.Students.Remove(existing);

        LogManager.WriteToLog(projectName, funcName, $"Finished Delete Student with ID: {id}");
    }
}