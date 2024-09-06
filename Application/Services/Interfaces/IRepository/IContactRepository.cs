using Application.DtoModels;
using Domain.Models;

namespace Persistance.Repository
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetAllContactAsync();

        Task<Contact> GetContactByIdAsync(int id);

        Task<Contact> AddContactAsync(ContactDto contactDto);

        Task<Contact> UpdateContactAsync(ContactDto contactDto);

        Task<Contact> DeleteContactByIdAsync(int id);
    }
}