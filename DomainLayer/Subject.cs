using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DomainLayer
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public EducationLevelEnum EducationLevel { get; set; }
        public double RequiredResultPercentage { get; set; }
        public bool RequiresIELTS { get; set; }
        public int? RequiredIELTSScore { get; set; }
    }
}
