using System.Collections.Generic;
using System.Text.Json.Serialization;
namespace GradeManagement.Model
{
    public class GradeModel
    {
        [JsonIgnore]
        public List<int> Score { get; set; } = new List<int>();
        [JsonIgnore]
        public List<int> TotalItems { get; set; } = new List<int>();
        public string StudentName { get; set; }
        public string SubjectName { get; set; }
        public double FinalGrade { get; set; }

    }
}
