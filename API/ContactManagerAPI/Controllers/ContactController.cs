using ContactManagerAPI.DTOs;
using ContactManagerAPI.Entities;
using Microsoft.AspNetCore.Authorization;
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
        //[Authorize]
        public IActionResult Create([FromBody] CreateContactDTO contactDTO)
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
                });
            }

            //Return status 200 after succesfull creation
            return Ok(contact);
        }

        [HttpGet]
        [Route("Contacts/{email}")]
        public IActionResult Get(string email)
        {
            //reading contacts from database
            var contact = _dbContext.Contacts
                .Include(c => c.Category)
                .Include(c => c.SubCategory)
                .Where(c => c.Email == email)
                .FirstOrDefault();

            if (contact == null)
                return NotFound();

            //mapping contact to contatDTO
            GetContactDTO contactDTO = new GetContactDTO
            {
                Email = contact.Email,
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                PhoneNumber = contact.PhoneNumber,
                DateOfBirth = contact.DateOfBirth,
                CategoryId = contact.CategoryId,
                CategoryName = contact.Category.Name,
                SubCategoryId = contact.SubCategoryId,
                SubCategoryName = contact.SubCategory.Name
            };
           
            //returning mapped result
            return Ok(contactDTO);
        }

        [HttpGet]
        [Route("Contacts")]
        public IActionResult GetAll()
        {
            //reading contacts from database
            var contacts = _dbContext.Contacts
                .Include(c => c.Category)
                .Include(c => c.SubCategory)
                .ToList();

            //creating empty list for DTOs
            List<GetContactDTO> getContactsDTOs = new List<GetContactDTO>();

            //mapping contacts to contatDTOs
            contacts.ForEach(c => getContactsDTOs.Add(new GetContactDTO
            {
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

        [HttpPut]
        [Route("Contacts")]
        [Authorize]
        public IActionResult Update([FromBody] CreateContactDTO contactDTO)
        {
            //Model validation acording to properies atributes
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //Reading contact from database
            var contact = _dbContext.Contacts.Where(c => c.Email == contactDTO.Email).FirstOrDefault();

            //Checking if contact exists
            if (contact == null)
                return NotFound();

            //Updating properties
            contact.Email = contactDTO.Email;
            contact.FirstName = contactDTO.FirstName;
            contact.LastName = contactDTO.LastName;
            contact.PhoneNumber = contactDTO.PhoneNumber;
            contact.DateOfBirth = contactDTO.DateOfBirth;
            contact.CategoryId = contactDTO.CategoryId;
            contact.SubCategoryId = contactDTO.SubCategoryId;

            //Saving changes to database
            try
            {
                _dbContext.SaveChanges();
            }
            catch
            {
                //Return 400 status if some error occurs
                return BadRequest(new
                {
                    errorMessage = "Cannot update the contact."
                });
            }
            
            //Return status ok if updated succesfully
            return Ok();
        }

        [HttpDelete]
        [Route("Contacts/{email}")]
        [Authorize]
        public IActionResult Delete(string email)
        {
            if (email == null)
                return BadRequest();

            //Reading contact from database
            var contact = _dbContext.Contacts
                .Where(c => c.Email == email)
                .FirstOrDefault();

            //Checking if contact exists
            if (contact == null)
                NotFound();

            //Delete from database
            try
            {
                _dbContext.Remove(contact);
                _dbContext.SaveChanges();
            }
            catch
            {
                //Return 400 status if some error occurs
                return BadRequest(new
                {
                    errorMessage = "Cannot delete the contact."
                });
            }

            //Return statsu ok if deleted succesfully
            return Ok();
        }
    }
}
