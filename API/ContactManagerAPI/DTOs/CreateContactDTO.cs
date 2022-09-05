using System.ComponentModel.DataAnnotations;

namespace ContactManagerAPI.DTOs
{
    public class CreateContactDTO
    {
        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MinLength(7)]
        [MaxLength(9)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public int? SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
    }
}
