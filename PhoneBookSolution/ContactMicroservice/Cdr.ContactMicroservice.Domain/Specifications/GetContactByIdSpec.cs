using Ardalis.GuardClauses;
using Ardalis.Specification;
using Cdr.ContactMicroservice.Domain.Entities;

namespace Cdr.ContactMicroservice.Domain.Specifications
{
    public class GetContactByIdSpec : Specification<Contact>, ISingleResultSpecification
    {
        public GetContactByIdSpec(string contactId)
        {
            Guard.Against.NullOrEmpty(contactId);
            Query
                .Where(contact => contact.Id == Guid.Parse(contactId));

        }
    }
}
