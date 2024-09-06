using Application.DtoModels;
using Application.Services.Interfaces.IServices;
using Microsoft.AspNetCore.Mvc;

namespace TestTaskContactListAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("GetAllContact")]
        public async Task<IActionResult> GetAllContactAsync()
        {
            try
            {
                return Ok(await _contactService.GetAllContactAsync());
            }
            catch (Exception ex)
            {
                return BadRequest($"Error in ContactsController -> GetAllContactAsync: {ex.Message}");
            }
        }

        [HttpGet("GetContact/{id}")]
        public async Task<IActionResult> GetContactByIdAsync(int id)
        {
            try
            {
                return Ok(await _contactService.GetContactByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error in ContactsController -> GetContactByIdAsync: {ex.Message}");
            }
        }

        [HttpPost("AddContact")]
        public async Task<IActionResult> AddContactAsync([FromBody] ContactDto contactDto)
        {
            try
            {
                return Ok(await _contactService.AddContactAsync(contactDto));

            }
            catch (Exception ex)
            {
                return BadRequest($"Error in ContactsController -> AddContactAsync: {ex.Message}");
            }
        }

        [HttpPut("UpdateContact")]
        public async Task<IActionResult> UpdateContactAsync([FromBody] ContactDto contactDto)
        {
            try
            {
                return Ok(await _contactService.UpdateContactAsync(contactDto));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error in ContactsController -> UpdateContactAsync: {ex.Message}");
            }
        }

        [HttpDelete("DeleteContact/{id}")]
        public async Task<IActionResult> DeleteContactByIdAsync(int id)
        {
            try
            {
                return Ok(await _contactService.DeleteContactByIdAsync(id));
            }
            catch (Exception ex)
            {
                return BadRequest($"Error in ContactsController -> DeleteContactByIdAsync: {ex.Message}");
            }
        }
    }
}