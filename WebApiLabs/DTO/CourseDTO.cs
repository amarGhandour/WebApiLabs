using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApiLabs.Models;

namespace WebApiLabs.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }

        [Required]
        public string CourseName { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int? TopicId { get; set; }
        public string? TopicName { get; set; }
    }
}
