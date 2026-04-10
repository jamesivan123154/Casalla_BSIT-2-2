using System;
using GradeManagement.Model;
using GradeManagement.DataLogic;
using GradeManagement.BusinessLogic;
namespace GradeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GradeData data = new GradeData();
            GradeCalculator calc = new GradeCalculator();
            GradeModel gm = new GradeModel();


            while (true)
            {
                Console.WriteLine("\n===== GRADE MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Add Grade");
                Console.WriteLine("2. View Grades");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.WriteLine("-----GRADE SYSTEM-----");
                        Console.WriteLine("Quizzes - 10%");
                        Console.WriteLine("Assignments - 10%");
                        Console.WriteLine("Performance Task - 40%");
                        Console.WriteLine("Midterm Exam - 20%");
                        Console.WriteLine("Final Exam - 20%");

                        Console.WriteLine("\nEnter Student Name: ");
                        gm.StudentName = Console.ReadLine();

                        Console.WriteLine("\nEnter Subject Name: ");
                        gm.SubjectName = Console.ReadLine();

                        //quiz
                        GradeModel quiz = data.GetActivityScores("Quiz");
                        double quizWeighted = calc.ComputeCategory(quiz, 0.10);

                        //assignment
                        GradeModel assignment = data.GetActivityScores("Assignment");
                        double assWeighted = calc.ComputeCategory(assignment, 0.10);

                        //performace task
                        GradeModel pt = data.GetActivityScores("Performance Task");
                        double ptWeighted = calc.ComputeCategory(pt, 0.40);

                        //midterm exam
                        GradeModel midterm = data.GetExamScore("MIDTERM EXAM");

                        Console.WriteLine("\n-----MIDTERM EXAM SCORE-----");
                        Console.WriteLine("Midterm Exam: " + midterm.Score[0] + "/" + midterm.TotalItems[0]);

                        double midPercentage = calc.ComputeExamPercentage(midterm);

                        Console.WriteLine("\n-----RESULT-----");
                        Console.WriteLine($"Midterm Exam Percentage: {midPercentage:F2}%");

                        double midWeighted = calc.ComputeWeighted(midPercentage, .20);

                        Console.WriteLine($"Weighted Midterm Exam (20%): {midWeighted:F2}%");

                        //final exam
                        GradeModel finalExam = data.GetExamScore("FINAL EXAM");

                        Console.WriteLine("\n-----FINAL EXAM SCORE-----");
                        Console.WriteLine("Final Exam: " + finalExam.Score[0] + "/" + finalExam.TotalItems[0]);

                        double finalPercentage = calc.ComputeExamPercentage(finalExam);

                        Console.WriteLine("\n-----RESULT-----");
                        Console.WriteLine($"Final Exam Percentage: {finalPercentage:F2}%");

                        double finalWeighted = calc.ComputeWeighted(finalPercentage, .20);

                        Console.WriteLine($"Weighted Final Exam (20%): {finalWeighted:F2}%");

                        double finalGrade = quizWeighted + assWeighted + ptWeighted + midWeighted + finalWeighted;
                        Console.WriteLine($"\n========== GRADE REPORT ==========");
                        Console.WriteLine($"Final Grade: {finalGrade:F2}%");

                        string equivalent = calc.GetGradeEquivalent(finalGrade);
                        Console.WriteLine($"Equivalent: {equivalent}");

                        data.SaveFinalGrade(gm, finalGrade);

                        gm.FinalGrade = Math.Round(finalGrade, 2);

                        data.SaveToJson(gm);
                        break;

                    case "2":
                        data.LoadFromJson();
                        break;

                    case "3":
                        Console.WriteLine("Exiting program...");
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }




            
        }
    }
}
