using ContactManagerAPI.DTOs;
using ContactManagerAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        [HttpGet]
        [Route("Contacts/{email}")]
        public IActionResult Get(string? email)
        {
            //reading contacts from database
            var contacts = _dbContext.Contacts
                .Include(c => c.Category)
                .Include(c => c.SubCategory)
                .Where(c => c.Email == email)
                .ToList();

            //creating empty list for DTOs
            List<GetContactDTO>  getContactsDTOs = new List<GetContactDTO>();

            //mapping contacts to contatDTOs
            contacts.ForEach(c => getContactsDTOs.Add(new GetContactDTO {
                Email = c.Email,
                FirstName = c.FirstName, 
                LastName = c.LastName,
                PhoneNumber = c.PhoneNumber,
                DateOfBirth = c.DateOfBirth,
                CategoryId = c.CategoryId,
                CategoryName = c.Category.Name,
                SubCategoryId = c.SubCategoryId,
                SubCategoryName = c.SubCategory.Name
            }));

            //returning mapped result
            return Ok(getContactsDTOs);
        }
    }
}
