using ContactManagerAPI.DTOs;
using ContactManagerAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagerAPI.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _dbContext;
        public ContactController(AppDbContext context)
        {
            _dbContext = context;
        }

        [HttpPost]
        [Route("Contacts")]
        public IActionResult Create(CreateContactDTO contactDTO)
        {
            //Model validation acording to properies atributes
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            //Map DTO to Contact entity
            Contact contact = new Contact()
            {
                Email = contactDTO.Email,
                FirstName = contactDTO.FirstName,
                LastName = contactDTO.LastName,
                PhoneNumber = contactDTO.PhoneNumber,
                DateOfBirth = contactDTO.DateOfBirth,
                CategoryId = contactDTO.CategoryId,
                SubCategoryId = contactDTO.SubCategoryId
            };

            //Save new contact to database via dbContext
            try
            {
                _dbContext.Contacts.Add(contact);
                _dbContext.SaveChanges();
            }
            catch
            {
                return BadRequest(new
                {
                    errorMessage = "Cannot create new contact."
                }); ;
            }

            //Return status 200 after succesfull creation
            return Ok(contact);
        }
    }
}
