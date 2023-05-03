using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiLabs.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public int Duration { get; set; }

        public string Description { get; set; }

        [ForeignKey("Topic")]
        public int TopicId {get; set; }

        public Topic Topic { get; set; }
    }
}
