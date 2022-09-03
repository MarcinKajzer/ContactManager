using System.ComponentModel.DataAnnotations;

namespace ContactManagerAPI.DTOs
{
    public class CreateContactDTO
    {
        [Required]
        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(9)]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
