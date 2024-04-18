using DomainLayer;

namespace uI__Layer.Models
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
