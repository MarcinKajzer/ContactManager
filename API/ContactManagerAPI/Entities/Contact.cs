namespace ContactManagerAPI.Entities
{
    public class Contact
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public SubCategory SubCategory { get; set; }
        public int? SubCategoryId { get; set; } = null;
    }
}
