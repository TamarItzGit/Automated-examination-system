using DalFacade.DalApi;
using DalFacade.DO;
using DO;
using Tools;
using System.Reflection;

namespace Dal;

internal class DalAnswer : IAnswer
{
    public int Create(Answer item)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, "Starting Create Answer");

        if (DataSource.Answers.Any(a => a.Id == item.Id))
            throw new Exception($"Answer with ID {item.Id} already exists");

        DataSource.Answers.Add(item);

        LogManager.WriteToLog(projectName, funcName, $"Finished Create Answer with ID: {item.Id}");
        return item.Id;
    }

    public Answer? Read(int id)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Read Answer for ID: {id}");

        Answer? answer = DataSource.Answers.FirstOrDefault(a => a.Id == id);

        LogManager.WriteToLog(projectName, funcName, $"Finished Read Answer for ID: {id}");
        return answer;
    }
    public List<Answer> ReadAll()
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, "Starting ReadAll Answers");

        List<Answer> answers = new List<Answer>(DataSource.Answers);

        LogManager.WriteToLog(projectName, funcName, "Finished ReadAll Answers");
        return answers;
    }
    public void Update(Answer item)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Update Answer with ID: {item.Id}");

        var existing = Read(item.Id);
        if (existing == null) throw new Exception($"Answer with ID {item.Id} does not exist");
        DataSource.Answers.Remove(existing);
        DataSource.Answers.Add(item);

        LogManager.WriteToLog(projectName, funcName, $"Finished Update Answer with ID: {item.Id}");
    }
    public void Delete(int id)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Delete Answer with ID: {id}");

        var existing = Read(id);
        if (existing == null) throw new Exception($"Answer with ID {id} does not exist");
        DataSource.Answers.Remove(existing);

        LogManager.WriteToLog(projectName, funcName, $"Finished Delete Answer with ID: {id}");
    }
}