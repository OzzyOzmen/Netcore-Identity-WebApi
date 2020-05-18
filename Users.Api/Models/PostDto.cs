using System.ComponentModel.DataAnnotations;

namespace Users.Api.Models
{
    public class PostDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}