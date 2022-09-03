namespace ContactManagerAPI.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category Category { get; set; }
        public int CategoryId { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}
