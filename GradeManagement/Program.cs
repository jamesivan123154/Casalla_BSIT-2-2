using System;
namespace GradeManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double quizSum = 0, totalItems = 0;
            double quizAve = 0;
            Console.WriteLine("-----GRADE SYSTEM-----");
            Console.WriteLine("Number of quizes you want to encode: ");
            short numberOfQuizes = short.Parse(Console.ReadLine());
            int[] quizScore = new int[numberOfQuizes];
            for (int i = 0; i < quizScore.Length; i++)
            {
                while (true)
                {
                    Console.WriteLine($"\nQuiz {i + 1}");
                    Console.Write("Score: ");
                    quizScore[i] = int.Parse(Console.ReadLine());

                    Console.Write("Total items: ");
                    double items = double.Parse(Console.ReadLine());

                    if (quizScore[i] > items || quizScore[i] < 0)
                    {
                        Console.WriteLine("Input invalid. Score cannot exceed total items.");

                    }
                    else
                    {
                        quizSum += quizScore[i];
                        totalItems += items;
                        break;
                    }
                }
            }
            
            Console.WriteLine("\n-----QUIZ SCORES-----");
            for (int i = 0; i < quizScore.Length; i++)
            {
                Console.WriteLine("Quiz " + (i + 1) + ": " + quizScore[i]);
            }
            Console.WriteLine("\n-----RESULTS-----");
            Console.WriteLine("Total score: " + quizSum);
            Console.WriteLine("Total items: " + totalItems);

            quizAve = (quizSum / totalItems) * 100;
            Console.WriteLine($"Average (Quiz): {quizAve:F2}%");


        }
    }
}