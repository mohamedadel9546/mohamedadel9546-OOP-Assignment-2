using System;
using System.Collections.Generic;
using System.Text;

namespace RefactorSrp.GradeBook
{
    public class Transcripit
    {
        private readonly ADDStuudent aDDStuudent = null!;
        private readonly GradingPolicyCalculator grading = null!;
        private readonly HonorolRoll Honorol = null!;

        public Transcripit(ADDStuudent aDDStuudent, GradingPolicyCalculator grading, HonorolRoll honorol)
        {
            this.aDDStuudent = aDDStuudent;
            this.grading = grading;
            Honorol = honorol;
        }

        public string TranscriptPlain(string studentId, string fullName)
        {
            // Registrar document format ≠ grading policy.
            return $"TRANSCRIPT\nStudent: {fullName} ({studentId})\nAverage: {aDDStuudent.Average(studentId)}\nLetter: {grading.Letter(studentId)}\nHonor: {Honorol.MeetsHonorRoll(studentId)}\n";
        }
    }
}
