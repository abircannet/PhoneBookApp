using Ardalis.Specification;
using Cdr.ContactMicroservice.Domain.Entities;

namespace Cdr.ContactMicroservice.Domain.Specifications
{
    public class GetPhoneContactDetailsByContactIdsSpec : Specification<ContactDetail>
    {
        public GetPhoneContactDetailsByContactIdsSpec(IEnumerable<Guid> ids)
        {
            Query.Where(c => ids.Contains(c.ContactId) && c.ContactDetailType == ContactDetailType.Phone);
        }
    }
}
