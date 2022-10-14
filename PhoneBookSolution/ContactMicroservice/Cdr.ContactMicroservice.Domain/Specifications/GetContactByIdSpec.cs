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
    public class GetContactByIdSpec:Specification<Contact>,ISingleResultSpecification
    {
        public GetContactByIdSpec(string contactId)
        {
            Guard.Against.NullOrEmpty(contactId);
            Query
                .Where(contact=>contact.Id==contactId);

        }
    }
}
