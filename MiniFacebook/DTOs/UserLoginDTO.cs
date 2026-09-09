using System.ComponentModel.DataAnnotations;

namespace MiniFacebook.DTOs
{
    public class UserLoginDTO
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }    
        
    }
}
