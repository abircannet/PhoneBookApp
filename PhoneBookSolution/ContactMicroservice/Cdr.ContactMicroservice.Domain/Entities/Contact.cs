using Ardalis.GuardClauses;
using Cdr.ContactMicroservice.Domain.Core; 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ContactMicroservice.Domain.Entities
{
    public class Contact : BaseEntity, IAggregateRoot
    {
        private Contact() { }

        public Contact(string name, string surname):this(name,surname,null)
        { 
        }
        public Contact(string name, string surname, string companyName)
        {
            Guard.Against.Null(name, nameof(name), $"{nameof(name)} can not be null.");
            Guard.Against.Null(surname, nameof(surname), $"{nameof(surname)} can not be null.");

            Name = name;
            Surname = surname;
            CompanyName = companyName;
        }
        public void AddDetail(ContactDetail contactDetail)
        {
            Guard.Against.Null(contactDetail, nameof(contactDetail), $"{nameof(contactDetail)} can not be null.");

            _contactDetails.Add(contactDetail);
        }
        public void RemoveDetail(string detailId)
        {
            Guard.Against.NullOrEmpty(detailId, nameof(detailId));
            var detail=_contactDetails.FirstOrDefault(d => d.Id == Guid.Parse(detailId));
            Guard.Against.Null(detail,message: $"Entity with {detailId} not found.");
            _contactDetails.Remove(detail);
        }

        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string CompanyName { get; private set; }

        private readonly List<ContactDetail> _contactDetails = new List<ContactDetail>();
        public IReadOnlyCollection<ContactDetail> ContactDetails => _contactDetails.AsReadOnly();

    }
}
