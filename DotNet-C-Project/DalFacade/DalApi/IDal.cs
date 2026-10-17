namespace DalFacade.DalApi;

public interface IDal
{
    IAnswer Answer { get; }
    IQuestion Question { get; }
    IStudent Student { get; }
    ITest Test { get; }
    IStudentQuestion StudentQuestion { get; }
}