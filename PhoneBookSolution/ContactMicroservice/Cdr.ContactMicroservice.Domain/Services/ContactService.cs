using Ardalis.GuardClauses;
using Cdr.ContactMicroservice.Domain.Entities;
using Cdr.ContactMicroservice.Domain.Interface;
using Cdr.ContactMicroservice.Domain.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cdr.ContactMicroservice.Domain.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContactService(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> AddContact(Contact contact)
        {
            Guard.Against.Null(contact, nameof(contact));
            await _contactRepository.AddAsync(contact);
            return contact;
        }

        public async Task AddDetailToContact(string contactId, ContactDetail contactDetail)
        {
            var contact = await GetContactWithDetail(contactId);
            contact.AddDetail(contactDetail);
            await _contactRepository.UpdateAsync(contact);
        }

        public async Task DeleteContact(string contactId)
        {
            var contact = await _contactRepository.GetByIdAsync(contactId);
            Guard.Against.Null(contact, nameof(contact), $"Entity with {contactId} not found.");
            await _contactRepository.DeleteAsync(contact);
        }

        public async Task DeleteDetailFromContact(string contactId, string detailId)
        {
            var contact = await GetContactWithDetail(contactId);
            contact.RemoveDetail(detailId);
            await _contactRepository.UpdateAsync(contact);
        }

        public async Task<IReadOnlyCollection<Contact>> GetAllContacts()
        {
            return (await _contactRepository.ListAsync()).AsReadOnly();
        }

        public async Task<Contact> GetContactWithDetail(string contactId)
        {
            var contact = await _contactRepository.FirstOrDefaultAsync(new GetContactWithDetailsByContactIdSpec(contactId));
            Guard.Against.Null(contact, nameof(contact), $"Entity with {contactId} not found.");
            return contact;
        }
    }
}
