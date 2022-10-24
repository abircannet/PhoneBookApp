using Cdr.ContactMicroservice.Domain.Entities;

namespace Cdr.ContactMicroservice.RestfullAPI.DTOs
{
    public class GetContactWithDetailOutputDTO
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CompanyName { get; set; }
        public IEnumerable<GetContactDetailOutputDTO> Details { get; set; }
    }
    public class GetContactDetailOutputDTO
    {
        public string Id { get; set; }
        public ContactDetailType ContactDetailType { get; set; }
        public string Content { get; set; }
    }
}
