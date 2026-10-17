using DO;
using System.Collections.Generic;
using DalFacade;
using DalFacade.DO;

namespace Dal;

/// <summary>
/// מחלקה סטטית המרכזת את כל רשימות הנתונים בזיכרון עבור מערכת הבחינות
/// </summary>
internal static class DataSource
{
    internal static List<Test?> Tests { get; set; } = [];
    internal static List<Question?> Questions { get; set; } = [];
    internal static List<Answer?> Answers { get; set; } = [];
    internal static List<Student?> Students { get; set; } = [];
    internal static List<StudentQuestion?> StudentQuestions { get; set; } = [];

    internal static class Config
    {
        // מספר רץ עבור מבחן
        internal const int s_startTestId = 1000;
        private static int s_nextTestId = s_startTestId;
        internal static int NextTestId { get => s_nextTestId++; }

        // מספר רץ עבור שאלה
        internal const int s_startQuestionId = 1;
        private static int s_nextQuestionId = s_startQuestionId;
        internal static int NextQuestionId { get => s_nextQuestionId++; }
        // מספר רץ עבור סטודנט-שאלה (StudentQuestion)
        internal const int s_startStudentQuestionId = 1;
        private static int s_nextStudentQuestionId = s_startStudentQuestionId;
        internal static int NextStudentQuestionId { get => s_nextStudentQuestionId++; }
    }
}
