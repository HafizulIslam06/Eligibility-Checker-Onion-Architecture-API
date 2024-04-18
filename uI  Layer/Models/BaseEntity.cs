using System.ComponentModel.DataAnnotations;

namespace uI__Layer.Models
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string IPAddress { get; set; }
    }
}
