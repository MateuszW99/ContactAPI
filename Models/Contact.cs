using ContactAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ContactAPI.Models
{
    public class Contact : IContact
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(400, MinimumLength = 5, ErrorMessage = "Message length not between [5, 400]")]
        public string Message { get; set; }
    }
}
