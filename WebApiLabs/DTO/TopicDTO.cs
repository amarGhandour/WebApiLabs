using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using WebApiLabs.Models;

namespace WebApiLabs.DTO
{
    public class TopicDTO
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public HashSet<string> Courses { get; set; } = new HashSet<string>();
    }
}
