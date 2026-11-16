using System;
using System.IO;

namespace Tools
{
    public static class LogManager
    {
        // הניתוב היחסי לתיקיית קבצי הלוג של הפרויקט
        private const string BASE_LOG_DIR = "Log";

        // פונקציה לקבלת ניתוב התיקייה הנוכחית (לפי חודש ושנה)
        private static string GetCurrentMonthDirectory()
        {
            DateTime now = DateTime.Now;
            // יוצר מחרוזת בסגנון "MM-yyyy", למשל "11-2026"
            string monthFolder = $"{now.Month:D2}-{now.Year}";

            // מחזיר את הנתיב המלא: "Log/11-2026" (מתאים לסביבת העבודה הנוכחית)
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, BASE_LOG_DIR, monthFolder);
        }

        // פונקציה לקבלת ניתוב הקובץ הנוכחי (לפי יום)
        private static string GetCurrentDayFilePath()
        {
            DateTime now = DateTime.Now;
            // יוצר שם קובץ בסגנון "dd-MM-yyyy.log", למשל "10-11-2026.log"
            string fileName = $"{now.Day:D2}-{now.Month:D2}-{now.Year}.log";

            string directoryPath = GetCurrentMonthDirectory();
            return Path.Combine(directoryPath, fileName);
        }
        // פונקציה לכתיבה לקובץ הלוג
        public static void WriteToLog(string projectName, string funcName, string message)
        {
            string directoryPath = GetCurrentMonthDirectory();
            string filePath = GetCurrentDayFilePath();

            // וידוא שהתיקייה קיימת - ואם לא, יצירתה
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // יצירת מחרוזת הלוג בתבנית הנדרשת
            string logEntry = $"{DateTime.Now}\t{projectName}.{funcName}:\t{message}\n";

            // הוספת השורה לקובץ. הפונקציה AppendAllText יוצרת את הקובץ אם הוא לא קיים.
            File.AppendAllText(filePath, logEntry);
        }

        // פונקציה לניקוי קבצי לוג ישנים (מעל חודשיים)
        public static void CleanOldLogs()
        {
            string baseDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, BASE_LOG_DIR);

            if (!Directory.Exists(baseDir))
            {
                return; // אם התיקייה הראשית לא קיימת, אין מה לנקות
            }

            DateTime thresholdDate = DateTime.Now.AddMonths(-2);

            // עובר על כל התיקיות תחת תיקיית Log
            string[] directories = Directory.GetDirectories(baseDir);
            foreach (string dir in directories)
            {
                // קבלת שם התיקייה בלבד (ללא הנתיב המלא)
                string dirName = new DirectoryInfo(dir).Name;

                // ניסיון לפרק את שם התיקייה לחודש ושנה
                string[] parts = dirName.Split('-');
                if (parts.Length == 2 &&
                    int.TryParse(parts[0], out int month) &&
                    int.TryParse(parts[1], out int year))
                {
                    // יצירת תאריך המייצג את התיקייה (היום הראשון באותו חודש)
                    DateTime dirDate = new DateTime(year, month, 1);

                    // אם התאריך ישן יותר מחודשיים, מוחקים את התיקייה וכל תוכנה
                    if (dirDate < new DateTime(thresholdDate.Year, thresholdDate.Month, 1))
                    {
                        Directory.Delete(dir, true);
                    }
                }
            }
        }
    }
}