using Cdr.ContactMicroservice.Domain.Core;

namespace Cdr.ContactMicroservice.Domain.Entities
{
    public class ContactDetail:BaseEntity
    {
        public ContactDetail(ContactDetailType contactDetailType, string content)
        { 
            ContactDetailType = contactDetailType;
            Content = content;
        }

        private ContactDetail()
        {

        }

        public ContactDetailType ContactDetailType { get;private set; }
        public string Content { get;private set; }

        public Contact Contact { get;private set; }
        public Guid  ContactId { get;private set; }
    }
}