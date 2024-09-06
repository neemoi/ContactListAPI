using Application.DtoModels;

namespace Application.Services.Interfaces.IServices
{
    public interface IContactService
    {
        Task<List<ContactDto>> GetAllContactAsync();

        Task<ContactDto> GetContactByIdAsync(int id);

        Task<ContactDto> AddContactAsync(ContactDto contactDto);

        Task<ContactDto> UpdateContactAsync(ContactDto contactDto);

        Task<ContactDto> DeleteContactByIdAsync(int id);
    }
}