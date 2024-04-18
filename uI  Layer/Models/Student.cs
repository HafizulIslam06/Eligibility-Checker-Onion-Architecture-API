using DomainLayer;

namespace uI__Layer.Models
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
