using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.GradeBook
{
    public class HonorolRoll
    {
        private readonly ADDStuudent aDDStuudent = null!;
        private readonly GradingPolicyCalculator grading = null!;

        public HonorolRoll(ADDStuudent aDDStuudent, GradingPolicyCalculator grading)
        {
            this.aDDStuudent = aDDStuudent;
            this.grading = grading;
        }

        public bool MeetsHonorRoll(string studentId)
        {
            // Extra academic rule set embedded beside averaging.
            return aDDStuudent.Average(studentId) >= 85 && grading.Letter(studentId) is "A" or "B";
        }
    }
}
