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
    public class GetReportDataByLocationSpec:Specification<Contact>, ISingleResultSpecification
    {
        public GetReportDataByLocationSpec(string location)
        {
            Guard.Against.NullOrEmpty(location);
            //Query.Where(c=>c.ContactDetails)
        }
    }
}
