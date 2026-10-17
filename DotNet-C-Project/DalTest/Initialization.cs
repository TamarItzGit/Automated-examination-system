using DalFacade.DalApi;
using DalFacade.DO;
using Do;
using DO;
using System;

namespace DalTest;
public static class Initialization
{
    private static IDal? s_dal;
    private static void createStudents()
    {
        Student s1 = new Student(111111111, "Reuven", 5,6);
        Student s2 = new Student(222222222, "Shimon", 7,8);
        s_dal!.Student.Create(s1);
        s_dal!.Student.Create(s2);
    }
    private static void createTests()
    {
        Test t1 = new Test(0, Subject.Math, DateTime.Now, 10);
        s_dal!.Test.Create(t1);
    }
    private static void createQuestions()
    {
        Question q1 = new Question(0, Subject.Math, "What is 10 + 10?", 7);
        s_dal!.Question.Create(q1);
    }
    public static void Initialize(IDal dal)
    {
        s_dal = dal; 
        createStudents();
        createTests();
        createQuestions();
    }
}