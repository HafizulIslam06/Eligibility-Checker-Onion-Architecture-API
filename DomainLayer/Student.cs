using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public EducationLevelEnum EducationLevel { get; set; }
        public double ResultPercentage { get; set; }
        public bool IELTS { get; set; }
        public int? IELTSScore { get; set; }
    }
}


