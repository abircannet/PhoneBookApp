using Core.Base;

namespace Cdr.ContactMicroservice.Domain.Entities
{
    public class ContactDetail : BaseEntity
    {
        public ContactDetail(ContactDetailType contactDetailType, string content)
        {
            ContactDetailType = contactDetailType;
            Content = content;
        }
        public ContactDetail(ContactDetailType contactDetailType, string content, string contactId) : this(contactDetailType, content)
        {
            ContactId = Guid.Parse(contactId);
        }
        private ContactDetail()
        {

        }

        public ContactDetailType ContactDetailType { get; private set; }
        public string Content { get; private set; }

        public Guid ContactId { get; private set; }
    }
}