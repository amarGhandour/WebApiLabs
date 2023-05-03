using System.ComponentModel.DataAnnotations;

namespace WebApiLabs.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

       
        public HashSet<Course> Courses { get; set;} = new HashSet<Course>();



    }
}
