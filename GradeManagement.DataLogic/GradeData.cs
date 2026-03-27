using Microsoft.Data.SqlClient;
using GradeManagement.Model;
using System.IO;
using System.Text.Json;
using System;


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
        private string connectionString = "Server=localhost\\SQLEXPRESS;Database=GradeDB;Trusted_Connection=True;TrustServerCertificate=True;";
        public void SaveFinalGrade(GradeModel gm, double finalGrade)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"INSERT INTO FinalGrades(StudentName, SubjectName, FinalGrade)
                             VALUES(@student, @subject, @grade)";

                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@student", gm.StudentName);
                    cmd.Parameters.AddWithValue("@subject", gm.SubjectName);
                    cmd.Parameters.AddWithValue("@grade", finalGrade);

                    cmd.ExecuteNonQuery();
                }

                Console.WriteLine("\nFinal grade saved to database successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR: " + ex.Message);
            }
        }
        public void SaveToJson(GradeModel gm)
        {
            string filePath = "grades.json";

            List<GradeModel> gradesList = new List<GradeModel>();

            
            if (File.Exists(filePath))
            {
                string existingJson = File.ReadAllText(filePath);
                gradesList = JsonSerializer.Deserialize<List<GradeModel>>(existingJson) ?? new List<GradeModel>();
            }

            
            gradesList.Add(gm);

            
            string jsonString = JsonSerializer.Serialize(gradesList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);

            Console.WriteLine("\nSaved to JSON file successfully!");
        }

    }
}
