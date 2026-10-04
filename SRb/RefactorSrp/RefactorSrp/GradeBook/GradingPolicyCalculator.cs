using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.GradeBook
{
    public class GradingPolicyCalculator
    {
        private readonly ADDStuudent aDDStuudent = null!;

        public GradingPolicyCalculator(ADDStuudent aDDStuudent)
        {
            this.aDDStuudent = aDDStuudent;
        }

        public string Letter(string studentId)
        {
            // Academic policy bands change with faculty senate — not with CSV layout.
            var avg = aDDStuudent.Average(studentId);
            if (avg >= 90) return "A";
            if (avg >= 80) return "B";
            if (avg >= 70) return "C";
            if (avg >= 60) return "D";
            return "F";
        }
    }
}
