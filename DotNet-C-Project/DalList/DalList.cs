using DalFacade.DalApi;

namespace Dal;

public class DalList : IDal
{
    public IStudent Student => new DalStudent();
    public IQuestion Question => new DalQuestion();
    public ITest Test => new DalTest();
    public IAnswer Answer => new DalAnswer();
    public IStudentQuestion StudentQuestion => new DalStudentQuestion();
}