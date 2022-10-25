using Cdr.ContactMicroservice.Domain.Entities;
using Cdr.ContactMicroservice.Domain.Interface;
using Cdr.ContactMicroservice.RestfullAPI.DTOs;
using Cdr.ContactMicroservice.RestfullAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Cdr.ContactMicroservice.RestfullAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [ValidateModel]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateContactInputDTO dto)
        {

            try
            {
                var contact = await contactService.AddContactAsync(new Contact(dto.Name, dto.Surname, dto.CompanyName));
                //return Ok(new CreateContactOutputDTO { Id = contact.Id.ToString(), Name = contact.Name, Surname = contact.Surname, CompanyName = contact.CompanyName });

                return CreatedAtAction(
                           nameof(GetById),
                           new { id = contact.Id },
                           new GetContactOutputDTO
                           {
                               Id = contact.Id.ToString(),
                               CompanyName = contact.CompanyName,
                               Name = contact.Name,
                               Surname = contact.Surname
                           });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
            }

        }
        [HttpDelete]
        public async Task<IActionResult> Remove(string contactId)
        {
            try
            {
                await contactService.DeleteContactAsync(contactId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = (await contactService.GetAllContactsAsync());
            if (data.Count == 0)
                return NoContent();

            var dto = data
                .Select(x => new GetContactOutputDTO { Id = x.Id.ToString(), Name = x.Name, Surname = x.Surname, CompanyName = x.CompanyName });


            return Ok(dto);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var data = (await contactService.GetContactWithDetailAsync(id));
            if (data == null)
                return NotFound();

            var dto = new GetContactWithDetailOutputDTO()
            {
                Id = id.ToString(),
                Name = data.Name,
                Surname = data.Surname,
                CompanyName = data.CompanyName,
                Details = data.ContactDetails?.Select(d => new GetContactDetailOutputDTO { Id = d.Id.ToString(), Content = d.Content, ContactDetailType = d.ContactDetailType })
            };


            return Ok(dto);
        }
        [HttpGet("[action]/{location}")]
        public async Task<IActionResult> GetReportDataAsync(string location)
        {
            var dto = await contactService.GetContactReportData(location);
            if (dto == null)
                NotFound();
            return Ok(dto);
        }
    }
}