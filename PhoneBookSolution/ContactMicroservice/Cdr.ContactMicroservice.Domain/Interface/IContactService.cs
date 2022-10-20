using Cdr.ContactMicroservice.Domain.Entities;

namespace Cdr.ContactMicroservice.Domain.Interface
{
    public interface IContactService
    {
        Task<Contact> AddContactAsync(Contact contact);
        Task<ContactDetail> AddDetailToContactAsync(string contactId, ContactDetail contactDetail);
        Task DeleteContactAsync(string contactId);
        Task DeleteDetailFromContactAsync(string contactId, string detailId);
        Task<IReadOnlyCollection<Contact>> GetAllContactsAsync();
        Task<Contact> GetContactWithDetailAsync(string contactId);
    }
}