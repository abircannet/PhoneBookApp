using Cdr.ContactMicroservice.Domain.Entities;
using Cdr.ContactMicroservice.Domain.Interface;
using Cdr.ContactMicroservice.Domain.Services;
using Cdr.ContactMicroservice.RestfullAPI.Controllers;
using Cdr.ContactMicroservice.RestfullAPI.DTOs;
using Cdr.Tests.UnitTests.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cdr.Tests.UnitTests
{
    public class ContactControllerTest
    {
        private readonly Mock<IRepository<Contact>> _mockContactRepository;
        private readonly Mock<IRepository<ContactDetail>> _mockContactDetailRepository;
        private readonly IContactService _contactService;
        private readonly ContactController _controller;
        private readonly List<Contact> _contacts;
        //private readonly List<ContactInformation> _contacts;

        public ContactControllerTest()
        {
            _mockContactRepository = new Mock<IRepository<Contact>>();
            _mockContactDetailRepository = new Mock<IRepository<ContactDetail>>();
            _contactService = new ContactService(_mockContactRepository.Object,_mockContactDetailRepository.Object);
            _controller = new ContactController(_contactService);
            _contacts = SampleTestData.contactData;
            //_contacts = SampleData.contactInformationData;
        }

        [Fact]
        public void Get_ActionExecutes_ReturnOkResultWithContacts()
        {
            _mockContactRepository.Setup(x => x.ListAsync(default).Result).Returns(_contacts);
            var result = _controller.GetAll().Result;
            var actionResult =  Assert.IsAssignableFrom<IActionResult>(result);
            var okResult =  Assert.IsAssignableFrom<OkObjectResult>(actionResult);
            var returnContacts = Assert.IsAssignableFrom<IEnumerable<GetContactOutputDTO>>(okResult.Value);
            Assert.True(returnContacts.Count() > 0);
        }

        [Fact]
        public void Get_ActionExecutesWithZeroData_ReturnNoContent()
        {
            _mockContactRepository.Setup(x => x.ListAsync(default).Result).Returns(new List<Contact>());
            var result = _controller.GetAll().Result;
            var actionResult = Assert.IsAssignableFrom<IActionResult>(result);
            Assert.IsAssignableFrom<NoContentResult>(actionResult);
        }
        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000")] 
        public  void Get_IdInValid_ReturnNotFound(Guid contactId)
        {
            var contact = _contacts.First(x => x.Id == contactId);
            _mockContactRepository.Setup(x => x.GetByIdAsync(contactId,default)).ReturnsAsync(contact);
            var result =  _controller.GetById(contactId.ToString()).Result;
            var actionResult = Assert.IsAssignableFrom<IActionResult>(result);
            var notFoundResult = Assert.IsAssignableFrom<NotFoundResult>(actionResult);
            var returnContact = Assert.IsAssignableFrom<NotFoundResult>(notFoundResult);
        }

        [Fact]
        public void Post_ActionExecutes_ReturnCreatedWithContact()
        {
            var contactDTO = new CreateContactInputDTO() { Name = "Test", Surname = "User", CompanyName = "Test Company Inc." };
            var contact = new Contact( "Test",  "User",  "Test Company Inc.");
            _mockContactRepository.Setup(x => x.AddAsync(contact,default).Result).Returns(contact);
            var actionResult =   _controller.Create(contactDTO).Result;
            var createdResult = Assert.IsAssignableFrom<CreatedAtActionResult>(actionResult);
            var returnContactDTO = Assert.IsAssignableFrom<GetContactOutputDTO>(createdResult.Value);
            Assert.Equal(contactDTO.Name, returnContactDTO.Name); 
        }

        [Theory]
        [InlineData("0d466b57-75f3-4c2f-ba22-26d3f9a2bb59")]
        public async void Delete_IdIsNotEqualContact_BadRequest(Guid contactId)
        {
            Contact contact = null;
            _mockContactRepository.Setup(x => x.GetByIdAsync(contactId,default)).ReturnsAsync(contact);
            var result = await _controller.Remove(contactId.ToString());
            var objectResult = Assert.IsAssignableFrom<ObjectResult>(result);
            var exceptionResult = Assert.IsType<string>(objectResult.Value);
            Assert.Equal(StatusCodes.Status400BadRequest, objectResult?.StatusCode);
        }
        [Theory]
        [InlineData("00000000-0000-0000-0000-000000000000")]
        public async void Delete_ActionExecutes_ReturnNoContent(Guid contactId)
        {
            Contact contact = new Contact("Test", "User", "Test Company Inc.");
            _mockContactRepository.Setup(x => x.GetByIdAsync(contactId, default)).ReturnsAsync(contact);
            _mockContactRepository.Setup(x => x.DeleteAsync(contact,default));

            var result = await _controller.Remove(contactId.ToString());
            var badRequestResult = Assert.IsAssignableFrom<NoContentResult>(result);
        }

    }
}
