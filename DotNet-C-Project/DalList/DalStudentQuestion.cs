using DalFacade.DalApi;
using DalFacade.DO;
using DO;
using Tools;
using System.Reflection;

namespace Dal;

internal class DalStudentQuestion : IStudentQuestion
{
    public int Create(StudentQuestion item)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, "Starting Create StudentQuestion");

        if (DataSource.StudentQuestions.Any(sq => sq.Id == item.Id))
            throw new Exception($"StudentQuestion with ID {item.Id} already exists");

        DataSource.StudentQuestions.Add(item);

        LogManager.WriteToLog(projectName, funcName, $"Finished Create StudentQuestion with ID: {item.Id}");
        return item.Id;
    }

    public StudentQuestion? Read(int id)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Read StudentQuestion for ID: {id}");

        StudentQuestion? studentQuestion = DataSource.StudentQuestions.FirstOrDefault(sq => sq.Id == id);

        LogManager.WriteToLog(projectName, funcName, $"Finished Read StudentQuestion for ID: {id}");
        return studentQuestion;
    }
    public List<StudentQuestion> ReadAll()
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, "Starting ReadAll StudentQuestions");

        List<StudentQuestion> studentQuestions = new List<StudentQuestion>(DataSource.StudentQuestions);

        LogManager.WriteToLog(projectName, funcName, "Finished ReadAll StudentQuestions");
        return studentQuestions;
    }
    public void Update(StudentQuestion item)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Update StudentQuestion with ID: {item.Id}");

        var existing = Read(item.Id);
        if (existing == null) throw new Exception($"StudentQuestion with ID {item.Id} does not exist");
        DataSource.StudentQuestions.Remove(existing);
        DataSource.StudentQuestions.Add(item);

        LogManager.WriteToLog(projectName, funcName, $"Finished Update StudentQuestion with ID: {item.Id}");
    }
    public void Delete(int id)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Delete StudentQuestion with ID: {id}");

        var existing = Read(id);
        if (existing == null) throw new Exception($"StudentQuestion with ID {id} does not exist");
        DataSource.StudentQuestions.Remove(existing);

        LogManager.WriteToLog(projectName, funcName, $"Finished Delete StudentQuestion with ID: {id}");
    }
}