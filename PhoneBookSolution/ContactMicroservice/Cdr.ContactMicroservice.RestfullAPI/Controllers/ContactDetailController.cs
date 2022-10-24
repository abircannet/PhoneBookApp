using Cdr.ContactMicroservice.Domain.Entities;
using Cdr.ContactMicroservice.Domain.Interface;
using Cdr.ContactMicroservice.RestfullAPI.DTOs;
using Cdr.ContactMicroservice.RestfullAPI.Filters;
using Microsoft.AspNetCore.Mvc;

namespace Cdr.ContactMicroservice.RestfullAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactDetailController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactDetailController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [ValidateModel]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddContactDetailInputDTO dto)
        {

            try
            {


                var contactDetail = await contactService.AddDetailToContactAsync(dto.ContactId, new ContactDetail(dto.ContactDetailType, dto.Content, dto.ContactId));

                return Ok(contactDetail);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status422UnprocessableEntity, ex.Message);
            }

        }
        [HttpDelete]
        public async Task<IActionResult> Remove(string contactId, string detailId)
        {
            try
            {
                await contactService.DeleteDetailFromContactAsync(contactId, detailId);
                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}