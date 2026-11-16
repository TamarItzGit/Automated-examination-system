using DalFacade.DalApi;
using DalFacade.DO;
using DO;
using System.Reflection;
using Tools;

namespace Dal;

internal class DalQuestion : IQuestion
{
    public int Create(Question item)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, "Starting Create Question");

        if (DataSource.Questions.Any(q => q.Id == item.Id))
            throw new Exception($"Question with ID {item.Id} already exists");

        DataSource.Questions.Add(item);

        LogManager.WriteToLog(projectName, funcName, $"Finished Create Question with ID: {item.Id}");
        return item.Id;
    }

    public Question? Read(int id)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Read Question for ID: {id}");

        Question? question = DataSource.Questions.FirstOrDefault(q => q.Id == id);

        LogManager.WriteToLog(projectName, funcName, $"Finished Read Question for ID: {id}");
        return question;
    }
    public List<Question> ReadAll()
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, "Starting ReadAll Questions");

        List<Question> questions = new List<Question>(DataSource.Questions);

        LogManager.WriteToLog(projectName, funcName, "Finished ReadAll Questions");
        return questions;
    }
    public void Update(Question item)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Update Question with ID: {item.Id}");

        var existing = Read(item.Id);
        if (existing == null) throw new Exception($"Question with ID {item.Id} does not exist");
        DataSource.Questions.Remove(existing);
        DataSource.Questions.Add(item);

        LogManager.WriteToLog(projectName, funcName, $"Finished Update Question with ID: {item.Id}");
    }
    public void Delete(int id)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Delete Question with ID: {id}");

        var existing = Read(id);
        if (existing == null) throw new Exception($"Question with ID {id} does not exist");
        DataSource.Questions.Remove(existing);

        LogManager.WriteToLog(projectName, funcName, $"Finished Delete Question with ID: {id}");
    }
}