using System.ComponentModel.DataAnnotations;

namespace ContactAPI.Domain.Request
{
    public class UserRegistrationRequest
    { 
        [Required, EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
