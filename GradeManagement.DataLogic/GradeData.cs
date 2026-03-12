using GradeManagement.Model;
using System;
using System.Diagnostics;

namespace GradeManagement.DataLogic
{
    public class GradeData
    {
        public GradeModel GetActivityScores(string activityName)
        {
            GradeModel gm = new GradeModel();

            Console.WriteLine($"\n-----{activityName.ToUpper()}-----");
            Console.WriteLine($"Number of {activityName} you want to encode: ");

            short numberOfActivities = short.Parse(Console.ReadLine());

            for(int i = 0; i < numberOfActivities; i++)
            while (true)
            {
                Console.WriteLine($"\n{activityName} {i + 1}");

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
                    gm.Score.Add(score);
                    gm.TotalItems.Add(total);
                    break;
                }
            }
            Console.WriteLine($"\n-----{activityName.ToUpper()} SCORES-----");
            for (int i = 0; i < gm.Score.Count; i++)
            {
                Console.WriteLine($"{activityName} {i + 1}: {gm.Score[i]}/{gm.TotalItems[i]}");
            }
            return gm;
        }
        public GradeModel GetExamScore(string examName)
        {
            GradeModel gm = new GradeModel();

            Console.WriteLine($"\n-----{examName}-----");

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
                    gm.Score.Add(score);
                    gm.TotalItems.Add(total);
                    break;
                }
            }
            return gm;
        }
    }
}
