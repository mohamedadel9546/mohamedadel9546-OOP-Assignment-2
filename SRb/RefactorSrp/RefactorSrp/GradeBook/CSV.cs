using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.GradeBook
{
    public class CSV
    {
        private readonly ADDStuudent aDDStuudent = null!;
        private readonly GradingPolicyCalculator grading = null!;
        private readonly HonorolRoll Honorol = null!;

        public CSV(ADDStuudent aDDStuudent, GradingPolicyCalculator grading, HonorolRoll honorol)
        {
            this.aDDStuudent = aDDStuudent;
            this.grading = grading;
            Honorol = honorol;
        }

        public string ExportCsv()
        {
            var rows = new List<string> { "studentId,average,letter,honor" };
            foreach (var id in aDDStuudent.Scores.Keys.OrderBy(x => x))
                rows.Add($"{id},{aDDStuudent.Average(id)},{grading.Letter(id)},{(Honorol.MeetsHonorRoll(id) ? 1 : 0)}");
            return string.Join('\n', rows);
        }
    }
}
