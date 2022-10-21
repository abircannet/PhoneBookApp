using Ardalis.GuardClauses;
using Cdr.ContactMicroservice.Domain.Entities;
using Cdr.ContactMicroservice.Domain.Interface;
using Cdr.ContactMicroservice.Domain.Specifications;
using Core.Interfaces;

namespace Cdr.ContactMicroservice.Domain.Services
{
    public class ContactService : IContactService
    {
        private readonly IRepository<Contact> _contactRepository;

        public ContactService(IRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> AddContactAsync(Contact contact)
        {
            Guard.Against.Null(contact, nameof(contact));
            await _contactRepository.AddAsync(contact);
            return contact;
        } 
        public async Task<ContactDetail> AddDetailToContactAsync(string contactId, ContactDetail contactDetail)
        {
            var contact = await _contactRepository.FirstOrDefaultAsync(new GetContactWithDetailsByContactIdSpec(contactId));
            contact.AddDetail(contactDetail);

            await _contactRepository.UpdateAsync(contact);

            return contactDetail;
        } 
        public async Task DeleteContactAsync(string contactId)
        {
            var contact = await _contactRepository.GetByIdAsync(Guid.Parse(contactId));
            Guard.Against.Null(contact, nameof(contact), $"Entity with {contactId} not found.");
            await _contactRepository.DeleteAsync(contact);
        } 
        public async Task DeleteDetailFromContactAsync(string contactId, string detailId)
        {
            var contact = await GetContactWithDetailAsync(contactId);
            contact.RemoveDetail(detailId);
            await _contactRepository.UpdateAsync(contact);
        } 
        public async Task<IReadOnlyCollection<Contact>> GetAllContactsAsync()
        {
            return (await _contactRepository.ListAsync()).AsReadOnly();
        } 
        public async Task<Contact> GetContactWithDetailAsync(string contactId)
        {
            Guard.Against.Null(contactId, nameof(contactId));

            var contact = await _contactRepository.FirstOrDefaultAsync(new GetContactWithDetailsByContactIdSpec(contactId));
            return contact;
        }
    }
}
