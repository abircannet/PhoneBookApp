using Ardalis.GuardClauses;
using Ardalis.Specification;
using Cdr.ContactMicroservice.Domain.Entities;

namespace Cdr.ContactMicroservice.Domain.Specifications
{
    public sealed class GetContactWithDetailsByContactIdSpec : Specification<Contact>, ISingleResultSpecification
    {
        public GetContactWithDetailsByContactIdSpec(string contactId)
        {
            Guard.Against.NullOrEmpty(contactId, nameof(contactId));
            Query
                .Where(c => c.Id == Guid.Parse(contactId))
                .Include(c => c.ContactDetails);

        }
    }
}
