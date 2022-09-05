using System.ComponentModel.DataAnnotations;

namespace ContactManagerAPI.DTOs
{
    public class RegisterUserDTO
    {
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(32)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-.]).{8,32}$", ErrorMessage = "Invalid password.")]
        public string Password { get; set; }

        [Required]
        [MinLength(8)]
        [MaxLength(32)]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password does not match.")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-.]).{8,32}$", ErrorMessage = "Invalid password.")]
        public string ConfirmPassword { get; set; }
    }
}
