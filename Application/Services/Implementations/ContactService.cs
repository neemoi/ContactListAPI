using Application.DtoModels;
using Application.Services.Interfaces.IServices;
using Application.UnitOfWork;
using AutoMapper;

namespace Application.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ContactService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<ContactDto>> GetAllContactAsync()
        {
            try
            {
                var result = await _unitOfWork.ContactRepository.GetAllContactAsync();

                return _mapper.Map<List<ContactDto>>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ContactService -> GetAllContactAsync: {ex.Message}");
            }
        }

        public async Task<ContactDto> GetContactByIdAsync(int contactId)
        {
            try
            {
                var result = await _unitOfWork.ContactRepository.GetContactByIdAsync(contactId);

                return _mapper.Map<ContactDto>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ContactService -> GetContactByIdAsync: {ex.Message}");
            }
        }

        public async Task<ContactDto> AddContactAsync(ContactDto contactDto)
        {
            try
            {
                var result = await _unitOfWork.ContactRepository.AddContactAsync(contactDto);

                return _mapper.Map<ContactDto>(result);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ContactService -> AddContactAsync: {ex.Message}");
            }
        }

        public async Task<ContactDto> UpdateContactAsync(ContactDto contactDto)
        {
            try
            {
                var contact = await _unitOfWork.ContactRepository.UpdateContactAsync(contactDto);

                return _mapper.Map<ContactDto>(contact);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ContactService -> UpdateContactAsync: {ex.Message}");
            }
        }

        public async Task<ContactDto> DeleteContactByIdAsync(int contactId)
        {
            try
            {
                var category = await _unitOfWork.ContactRepository.DeleteContactByIdAsync(contactId);

                return _mapper.Map<ContactDto>(category);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ContactService -> DeleteContactByIdAsync: {ex.Message}");
            }
        }
    }
}