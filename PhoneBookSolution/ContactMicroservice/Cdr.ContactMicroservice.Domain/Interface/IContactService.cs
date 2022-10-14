using Cdr.ContactMicroservice.Domain.Entities;

namespace Cdr.ContactMicroservice.Domain.Interface
{
    public interface IContactService
    {
        Task<Contact> AddContact(Contact contact);
        Task AddDetailToContact(string contactId, ContactDetail contactDetail);
        Task DeleteContact(string contactId);
        Task DeleteDetailFromContact(string contactId, string detailId);
        Task<IReadOnlyCollection<Contact>> GetAllContacts();
        Task<Contact> GetContactWithDetail(string contactId);
    }
}