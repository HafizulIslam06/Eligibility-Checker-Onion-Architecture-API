using DomainLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class EligibilityChecker
    {
        public bool IsStudentEligibleForSubject(Student student, Subject subject)
        {
            
            if (student.EducationLevel < subject.EducationLevel)
            {
                return false;
            }
            
            if (student.ResultPercentage < subject.RequiredResultPercentage)
            {
                return false;
            }

            if (subject.RequiresIELTS && (!student.IELTS || student.IELTSScore < subject.RequiredIELTSScore))
            {
                return false;
            }

            return true;
        }
    }
}
