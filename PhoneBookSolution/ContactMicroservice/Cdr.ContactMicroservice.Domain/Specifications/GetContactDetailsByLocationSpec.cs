using Ardalis.GuardClauses;
using Ardalis.Specification;
using Cdr.ContactMicroservice.Domain.Entities;

namespace Cdr.ContactMicroservice.Domain.Specifications
{
    public class GetContactDetailsByLocationSpec : Specification<ContactDetail>
    {
        public GetContactDetailsByLocationSpec(string location)
        {
            Guard.Against.NullOrEmpty(location);
            Query
                .Where(c => c.ContactDetailType == ContactDetailType.Location && c.Content == location);

        }
    }
}
