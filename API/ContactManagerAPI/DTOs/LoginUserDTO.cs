using System.ComponentModel.DataAnnotations;

namespace ContactManagerAPI.DTOs
{
    public class LoginUserDTO
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(32)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
