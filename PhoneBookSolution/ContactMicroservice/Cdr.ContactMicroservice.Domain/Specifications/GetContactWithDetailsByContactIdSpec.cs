using Ardalis.GuardClauses;
using Ardalis.Specification;
using Cdr.ContactMicroservice.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ContactMicroservice.Domain.Specifications
{
    public sealed class GetContactWithDetailsByContactIdSpec : Specification<Contact>, ISingleResultSpecification
    {
        public GetContactWithDetailsByContactIdSpec(string contactId)
        {
            Guard.Against.NullOrEmpty(contactId, nameof(contactId));
            Query
                .Where(c => c.Id == contactId)
                .Include(c => c.ContactDetails);

        }
    }
}
