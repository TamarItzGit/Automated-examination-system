using DalFacade.DalApi;
using DalFacade.DO;
using DO;
using System.Reflection;
using Tools;

namespace Dal;

internal class DalTest : ITest
{
    public int Create(Test item)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, "Starting Create Test");

        if (DataSource.Tests.Any(t => t.Id == item.Id))
            throw new Exception($"Test with ID {item.Id} already exists");

        DataSource.Tests.Add(item);

        LogManager.WriteToLog(projectName, funcName, $"Finished Create Test with ID: {item.Id}");
        return item.Id;
    }

    public Test? Read(int id)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Read Test for ID: {id}");

        Test? test = DataSource.Tests.FirstOrDefault(t => t.Id == id);

        LogManager.WriteToLog(projectName, funcName, $"Finished Read Test for ID: {id}");
        return test;
    }
    public List<Test> ReadAll()
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, "Starting ReadAll Tests");

        List<Test> tests = new List<Test>(DataSource.Tests);

        LogManager.WriteToLog(projectName, funcName, "Finished ReadAll Tests");
        return tests;
    }
    public void Update(Test item)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Update Test with ID: {item.Id}");

        var existing = Read(item.Id);
        if (existing == null) throw new Exception($"Test with ID {item.Id} does not exist");
        DataSource.Tests.Remove(existing);
        DataSource.Tests.Add(item);

        LogManager.WriteToLog(projectName, funcName, $"Finished Update Test with ID: {item.Id}");
    }
    public void Delete(int id)
    {
        string projectName = MethodBase.GetCurrentMethod()!.DeclaringType!.FullName!;
        string funcName = MethodBase.GetCurrentMethod()!.Name;

        LogManager.WriteToLog(projectName, funcName, $"Starting Delete Test with ID: {id}");

        var existing = Read(id);
        if (existing == null) throw new Exception($"Test with ID {id} does not exist");
        DataSource.Tests.Remove(existing);

        LogManager.WriteToLog(projectName, funcName, $"Finished Delete Test with ID: {id}");
    }
}