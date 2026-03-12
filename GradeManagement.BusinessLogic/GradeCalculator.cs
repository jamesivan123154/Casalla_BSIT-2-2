using System;
using GradeManagement.Model;
namespace GradeManagement.BusinessLogic
{
    public class GradeCalculator
    {
        public double ComputeCategory(GradeModel gm, double weight)
        {
            double sum = 0;
            double totalItems = 0;

            for (int i = 0; i < gm.Score.Count; i++)
            {
                sum += gm.Score[i];
                totalItems += gm.TotalItems[i];
            }

            double percentage = (sum / totalItems) * 100;

            double weightedAve = percentage * weight;

            Console.WriteLine("\n-----RESULT-----");
            Console.WriteLine("Total score: " + sum);
            Console.WriteLine("Total items: " + totalItems);
            Console.WriteLine($"Percentage: {percentage:F2}%");
            Console.WriteLine($"Weighted ({weight * 100}%): {weightedAve:F2}%");

            return weightedAve;
        }
        public double ComputeExamPercentage(GradeModel gm)
        {
            double percentage = ((double)gm.Score[0] / gm.TotalItems[0]) * 100;
            return percentage;
        }

        public double ComputeWeighted(double percentage, double weight)
        {
            return percentage * weight;
        }
        public string GetGradeEquivalent(double finalGrade)
        {
            if (finalGrade >= 96) return "1.00 | Passed";
            if (finalGrade >= 94) return "1.25 | Passed";
            if (finalGrade >= 92) return "1.50 | Passed";
            if (finalGrade >= 89) return "1.75 | Passed";
            if (finalGrade >= 87) return "2.00 | Passed";
            if (finalGrade >= 84) return "2.25 | Passed";
            if (finalGrade >= 82) return "2.50 | Passed";
            if (finalGrade >= 79) return "2.75 | Passed";
            if (finalGrade >= 75) return "3.00 | Passed";
            return "5.00 | Failed";
        }
    }
}
