using DalFacade.DalApi;
using DalFacade.DO;
using Do;
using DO;
using System;

namespace DalTest;

internal class Program
{
    private static readonly IDal s_dal = new Dal.DalList();

    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Initializing system with dummy data...");
            Initialization.Initialize(s_dal);

            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("\n=== Main Menu ===");
                Console.WriteLine("0. Exit");
                Console.WriteLine("1. Manage Students");
                Console.WriteLine("2. Manage Tests");
                Console.WriteLine("3. Manage Questions");
                Console.WriteLine("4. Manage Student-Questions");
                Console.Write("Choose an option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                    continue;

                switch (choice)
                {
                    case 0: exit = true; break;
                    case 1: StudentMenu(); break;
                    case 2: TestMenu(); break;
                    case 3: QuestionMenu(); break;
                    case 4: StudentQuestionMenu(); break;
                    default: Console.WriteLine("Invalid option. Try again."); break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\nSystem Error: {ex.Message}");
        }
    }

    // --- פונקציות עזר גנריות (לפי דרישת ההנחיות) ---
    private static void Read<T>(ICrud<T> crud)
    {
        Console.Write("Enter ID to view: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;

        T? item = crud.Read(id);
        if (item != null)
            Console.WriteLine(item);
        else
            Console.WriteLine("Item not found.");
    }

    private static void ReadAll<T>(ICrud<T> crud)
    {
        var items = crud.ReadAll();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }

    private static void Delete<T>(ICrud<T> crud)
    {
        Console.Write("Enter ID to delete: ");
        if (!int.TryParse(Console.ReadLine(), out int id)) return;

        crud.Delete(id);
        Console.WriteLine("Deleted successfully!");
    }

    // ==========================================
    //                 תפריטים
    // ==========================================

    // --- 1. תפריט סטודנטים ---
    private static void StudentMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\n--- Manage Students ---");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("1. Add Student (Create)");
            Console.WriteLine("2. View Student (Read)");
            Console.WriteLine("3. View All Students (ReadAll)");
            Console.WriteLine("4. Update Student (Update)");
            Console.WriteLine("5. Delete Student (Delete)");
            Console.Write("Choose an action: ");

            if (!int.TryParse(Console.ReadLine(), out int action)) continue;

            try
            {
                switch (action)
                {
                    case 0: back = true; break;
                    case 1:
                        Console.Write("Enter ID (Teudat Zehut): ");
                        int id = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter Name: ");
                        string name = Console.ReadLine()!;
                        Console.Write("Enter Test ID: ");
                        int testId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter Grade: ");
                        int grade = int.Parse(Console.ReadLine()!);

                        Student newStudent = new Student(id, name, testId, grade);
                        s_dal.Student.Create(newStudent);
                        Console.WriteLine("Student added successfully!");
                        break;
                    case 2: Read(s_dal.Student); break;
                    case 3: ReadAll(s_dal.Student); break;
                    case 4:
                        Console.Write("Enter Student ID to update: ");
                        int updateId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter New Name: ");
                        string newName = Console.ReadLine()!;
                        Console.Write("Enter New Test ID: ");
                        int newTestId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter New Grade: ");
                        int newGrade = int.Parse(Console.ReadLine()!);

                        Student updatedStudent = new Student(updateId, newName, newTestId, newGrade);
                        s_dal.Student.Update(updatedStudent);
                        Console.WriteLine("Student updated successfully!");
                        break;
                    case 5: Delete(s_dal.Student); break;
                    default: Console.WriteLine("Invalid action."); break;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }
    }

    // --- 2. תפריט מבחנים ---
    private static void TestMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\n--- Manage Tests ---");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("1. Add Test (Create)");
            Console.WriteLine("2. View Test (Read)");
            Console.WriteLine("3. View All Tests (ReadAll)");
            Console.WriteLine("4. Update Test (Update)");
            Console.WriteLine("5. Delete Test (Delete)");
            Console.Write("Choose an action: ");

            if (!int.TryParse(Console.ReadLine(), out int action)) continue;

            try
            {
                switch (action)
                {
                    case 0: back = true; break;
                    case 1:
                        Console.Write("Enter Subject ID (e.g., 1 for Math): ");
                        int subjectVal = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter Questions Count: ");
                        int qCount = int.Parse(Console.ReadLine()!);

                        Test newTest = new Test(0, (Subject)subjectVal, DateTime.Now, qCount);
                        int newId = s_dal.Test.Create(newTest);
                        Console.WriteLine($"Test added successfully! Auto-generated ID: {newId}");
                        break;
                    case 2: Read(s_dal.Test); break;
                    case 3: ReadAll(s_dal.Test); break;
                    case 4:
                        Console.Write("Enter Test ID to update: ");
                        int updateId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter New Subject ID: ");
                        int newSubj = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter New Questions Count: ");
                        int newQCount = int.Parse(Console.ReadLine()!);

                        Test updatedTest = new Test(updateId, (Subject)newSubj, DateTime.Now, newQCount);
                        s_dal.Test.Update(updatedTest);
                        Console.WriteLine("Test updated successfully!");
                        break;
                    case 5: Delete(s_dal.Test); break;
                    default: Console.WriteLine("Invalid action."); break;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }
    }

    // --- 3. תפריט שאלות ---
    private static void QuestionMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\n--- Manage Questions ---");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("1. Add Question (Create)");
            Console.WriteLine("2. View Question (Read)");
            Console.WriteLine("3. View All Questions (ReadAll)");
            Console.WriteLine("4. Update Question (Update)");
            Console.WriteLine("5. Delete Question (Delete)");
            Console.Write("Choose an action: ");

            if (!int.TryParse(Console.ReadLine(), out int action)) continue;

            try
            {
                switch (action)
                {
                    case 0: back = true; break;
                    case 1:
                        Console.Write("Enter Subject ID (e.g., 1 for Math): ");
                        int subjectVal = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter Question Text: ");
                        string text = Console.ReadLine()!;
                        Console.Write("Enter Param 4 (Number): ");
                        int param4 = int.Parse(Console.ReadLine()!);

                        Question newQuestion = new Question(0, (Subject)subjectVal, text, param4);
                        int newId = s_dal.Question.Create(newQuestion);
                        Console.WriteLine($"Question added successfully! Auto-generated ID: {newId}");
                        break;
                    case 2: Read(s_dal.Question); break;
                    case 3: ReadAll(s_dal.Question); break;
                    case 4:
                        Console.Write("Enter Question ID to update: ");
                        int updateId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter New Subject ID: ");
                        int newSubj = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter New Text: ");
                        string newText = Console.ReadLine()!;
                        Console.Write("Enter New Param 4 (Number): ");
                        int newParam4 = int.Parse(Console.ReadLine()!);

                        Question updatedQuestion = new Question(updateId, (Subject)newSubj, newText, newParam4);
                        s_dal.Question.Update(updatedQuestion);
                        Console.WriteLine("Question updated successfully!");
                        break;
                    case 5: Delete(s_dal.Question); break;
                    default: Console.WriteLine("Invalid action."); break;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }
    }

    // --- 4. תפריט שאלות-תלמיד (StudentQuestion) ---
    private static void StudentQuestionMenu()
    {
        bool back = false;
        while (!back)
        {
            Console.WriteLine("\n--- Manage Student-Questions ---");
            Console.WriteLine("0. Back to Main Menu");
            Console.WriteLine("1. Add Student-Question (Create)");
            Console.WriteLine("2. View Student-Question (Read)");
            Console.WriteLine("3. View All Student-Questions (ReadAll)");
            Console.WriteLine("4. Update Student-Question (Update)");
            Console.WriteLine("5. Delete Student-Question (Delete)");
            Console.Write("Choose an action: ");

            if (!int.TryParse(Console.ReadLine(), out int action)) continue;

            try
            {
                switch (action)
                {
                    case 0: back = true; break;
                    case 1:
                        Console.Write("Enter Student ID: ");
                        int studentId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter Question ID: ");
                        int questionId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter Test ID: ");
                        int TestId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter Selected Answer ID: ");
                        int SelectedAnswerId = int.Parse(Console.ReadLine()!);


                        StudentQuestion newSq = new StudentQuestion(0, studentId,TestId, questionId, SelectedAnswerId);
                        int newId = s_dal.StudentQuestion.Create(newSq);
                        Console.WriteLine($"Student-Question added successfully! Auto-generated ID: {newId}");
                        break;
                    case 2: Read(s_dal.StudentQuestion); break;
                    case 3: ReadAll(s_dal.StudentQuestion); break;
                    case 4:
                        Console.Write("Enter Student-Question ID to update: ");
                        int id = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter Student-Question ID to update: ");
                        int updateId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter New Student ID: ");
                        int newStudentId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter New Question ID: ");
                        int newQuestionId = int.Parse(Console.ReadLine()!);
                        Console.Write("Enter New Selected Answer ID: ");
                        int newSelectedAnswerId = int.Parse(Console.ReadLine()!);

                        StudentQuestion updatedSq = new StudentQuestion(id,updateId, newStudentId, newQuestionId, newSelectedAnswerId);
                        s_dal.StudentQuestion.Update(updatedSq);
                        Console.WriteLine("Student-Question updated successfully!");
                        break;
                    case 5: Delete(s_dal.StudentQuestion); break;
                    default: Console.WriteLine("Invalid action."); break;
                }
            }
            catch (Exception ex) { Console.WriteLine($"Error: {ex.Message}"); }
        }
    }
}