using System;
using System.Collections.Generic;
namespace GradeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("-----GRADE SYSTEM-----");
            Console.WriteLine("Quizzes - 10%");
            Console.WriteLine("Assignments - 10%");
            Console.WriteLine("Performance Task - 40%");
            Console.WriteLine("Midterm Exam - 20%");
            Console.WriteLine("Final Exam - 20%");

            double quizGrade = ComputeQuiz();
            double assGrade = ComputeAssignment();
            double ptGrade = ComputePerformanceTask();
            double midGrade = ComputeMidtermExam();
            double finalExam = ComputeFinalExam();


            double finalGrade = quizGrade + assGrade + ptGrade + midGrade + finalExam;
            Console.WriteLine("\n\n========== GRADE REPORT ==========");
            Console.WriteLine($"Final Grade: {finalGrade:F2}%");
            if (finalGrade >= 96)
            {
                Console.WriteLine("Equivalent: 1.00\nStatus: Passed");
            }
            else if (finalGrade >= 94)
            {
                Console.WriteLine("1.25 | Passed");
            }
            else if (finalGrade >= 92)
            {
                Console.WriteLine("1.50 | Passed");
            }
            else if (finalGrade >= 89)
            {
                Console.WriteLine("1.75 | Passed");
            }
            else if (finalGrade >= 87)
            {
                Console.WriteLine("2.00 | Passed");
            }
            else if (finalGrade >= 84)
            {
                Console.WriteLine("2.25 | Passed");
            }
            else if (finalGrade >= 82)
            {
                Console.WriteLine("2.50 | Passed");
            }
            else if (finalGrade >= 79)
            {
                Console.WriteLine("2.75 | Passed");
            }
            else if (finalGrade >= 75)
            {
                Console.WriteLine("3.00 | Passed");
            }
            else
            {
                Console.WriteLine("5.00 | Failed");
            }

        }

        static double ComputeQuiz()
        {
            double quizSum = 0, totalItems = 0;
            double quizPercentage = 0, weightedAve = 0;
            Console.WriteLine("\n-----QUIZ-----");
            Console.WriteLine("Number of quizes you want to encode: ");
            short numberOfQuizes = short.Parse(Console.ReadLine());
            List<int> quizScore = new List<int>();
            List<int> items = new List<int>();

            for (int i = 0; i < numberOfQuizes; i++)
            {
                while (true)
                {
                    Console.WriteLine($"\nQuiz {i + 1}");
                    Console.Write("Score: ");
                    int score = int.Parse(Console.ReadLine());

                    Console.Write("Total items: ");
                    int total = int.Parse(Console.ReadLine());

                    if (score > total || score < 0)
                    {
                        Console.WriteLine("Input invalid. Score cannot exceed total items.");

                    }
                    else
                    {
                        quizScore.Add(score);
                        items.Add(total);

                        quizSum += score;
                        totalItems += total;
                        break;
                    }
                }
            }

            Console.WriteLine("\n-----QUIZ SCORES-----");
            for (int i = 0; i < quizScore.Count; i++)
            {
                Console.WriteLine("Quiz " + (i + 1) + ": " + quizScore[i] + "/" + items[i]);
            }
            Console.WriteLine("\n-----RESULT-----");
            Console.WriteLine("Total score: " + quizSum);
            Console.WriteLine("Total items: " + totalItems);

            quizPercentage = (quizSum / totalItems) * 100;
            Console.WriteLine($"Quiz Percentage: {quizPercentage:F2}%");
            weightedAve = quizPercentage * 0.10; // quiz is 10% of the grade
            Console.WriteLine($"Weighted Quiz (10%): {weightedAve:F2}%");
            return weightedAve;
        }
        static double ComputeAssignment()
        {
            double assSum = 0, totalItems = 0;
            double assPercentage = 0, weightedAve = 0;
            Console.WriteLine("\n-----ASSIGNMENT-----");
            Console.WriteLine("Number of assignment you want to encode: ");
            short numberOfAss = short.Parse(Console.ReadLine());
            List<int> assScore = new List<int>();
            List<int> items = new List<int>();

            for (int i = 0; i < numberOfAss; i++)
            {
                while (true)
                {
                    Console.WriteLine($"\nAssignment {i + 1}");
                    Console.Write("Score: ");
                    int score = int.Parse(Console.ReadLine());

                    Console.Write("Total items: ");
                    int total = int.Parse(Console.ReadLine());

                    if (score > total || score < 0)
                    {
                        Console.WriteLine("Input invalid. Score cannot exceed total items.");

                    }
                    else
                    {
                        assScore.Add(score);
                        items.Add(total);

                        assSum += score;
                        totalItems += total;
                        break;
                    }
                }
            }

            Console.WriteLine("\n-----ASSIGNMENT SCORES-----");
            for (int i = 0; i < assScore.Count; i++)
            {
                Console.WriteLine("Assignment " + (i + 1) + ": " + assScore[i] + "/" + items[i]);
            }
            Console.WriteLine("\n-----RESULT-----");
            Console.WriteLine("Total score: " + assSum);
            Console.WriteLine("Total items: " + totalItems);

            assPercentage = (assSum / totalItems) * 100;
            Console.WriteLine($"Assignment Percentage: {assPercentage:F2}%");
            weightedAve = assPercentage * 0.10; // ass is 10% of the grade
            Console.WriteLine($"Weighted Assignment (10%): {weightedAve:F2}%");
            return weightedAve;

        }
        static double ComputePerformanceTask()
        {
            double ptSum = 0, totalItems = 0;
            double ptPercentage = 0, weightedAve = 0;
            Console.WriteLine("\n-----PERFORMANCE TASK-----");
            Console.WriteLine("Number of performance task you want to encode: ");
            short numberOfPt = short.Parse(Console.ReadLine());
            List<int> ptScore = new List<int>();
            List<int> items = new List<int>();

            for (int i = 0; i < numberOfPt; i++)
            {
                while (true)
                {
                    Console.WriteLine($"\nPerformance Task {i + 1}");
                    Console.Write("Score: ");
                    int score = int.Parse(Console.ReadLine());

                    Console.Write("Total items: ");
                    int total = int.Parse(Console.ReadLine());

                    if (score > total || score < 0)
                    {
                        Console.WriteLine("Input invalid. Score cannot exceed total items.");

                    }
                    else
                    {
                        ptScore.Add(score);
                        items.Add(total);

                        ptSum += score;
                        totalItems += total;
                        break;
                    }
                }
            }

            Console.WriteLine("\n-----PERFORMANCE TASK SCORES-----");
            for (int i = 0; i < ptScore.Count; i++)
            {
                Console.WriteLine("Performance Task " + (i + 1) + ": " + ptScore[i] + "/" + items[i]);
            }
            Console.WriteLine("\n-----RESULT-----");
            Console.WriteLine("Total score: " + ptSum);
            Console.WriteLine("Total items: " + totalItems);

            ptPercentage = (ptSum / totalItems) * 100;
            Console.WriteLine($"Performance Task Percentage: {ptPercentage:F2}%");
            weightedAve = ptPercentage * 0.40; // pt is 40% of the grade
            Console.WriteLine($"Weighted Performance Task (40%): {weightedAve:F2}%");
            return weightedAve;
        }
        static double ComputeMidtermExam()
        {
            double midPercentage = 0, weightedAve = 0;

            Console.WriteLine("\n-----MIDTERM EXAM-----");

            List<int> midScore = new List<int>();
            List<int> items = new List<int>();

            while (true)
            {
                Console.Write("Score: ");
                int score = int.Parse(Console.ReadLine());

                Console.Write("Total items: ");
                int total = int.Parse(Console.ReadLine());

                if (score > total || score < 0)
                {
                    Console.WriteLine("Input invalid. Score cannot exceed total items.");
                }
                else
                {
                    midScore.Add(score);
                    items.Add(total);
                    break;
                }
            }

            Console.WriteLine("\n-----MIDTERM SCORE-----");
            Console.WriteLine("Midterm Exam: " + midScore[0] + "/" + items[0]);

            Console.WriteLine("\n-----RESULT-----");
            midPercentage = ((double)midScore[0] / items[0]) * 100;
            Console.WriteLine($"Midterm Percentage: {midPercentage:F2}%");

            weightedAve = midPercentage * 0.20; // 20% weight
            Console.WriteLine($"Weighted Midterm (20%): {weightedAve:F2}%");

            return weightedAve;
        }
        static double ComputeFinalExam()
        {
            double finalPercentage = 0, weightedAve = 0;

            Console.WriteLine("\n-----FINAL EXAM-----");

            List<int> finalScore = new List<int>();
            List<int> items = new List<int>();

            while (true)
            {
                Console.Write("Score: ");
                int score = int.Parse(Console.ReadLine());

                Console.Write("Total items: ");
                int total = int.Parse(Console.ReadLine());

                if (score > total || score < 0)
                {
                    Console.WriteLine("Input invalid. Score cannot exceed total items.");
                }
                else
                {
                    finalScore.Add(score);
                    items.Add(total);
                    break;
                }
            }

            Console.WriteLine("\n-----FINAL EXAM SCORE-----");
            Console.WriteLine("Final Exam: " + finalScore[0] + "/" + items[0]);

            Console.WriteLine("\n-----RESULT-----");
            finalPercentage = ((double)finalScore[0] / items[0]) * 100;
            Console.WriteLine($"Final Exam Percentage: {finalPercentage:F2}%");

            weightedAve = finalPercentage * 0.20; // Final exam is 20%
            Console.WriteLine($"Weighted Final Exam (20%): {weightedAve:F2}%");

            return weightedAve;
        }
    }
}
