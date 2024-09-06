using Application.DtoModels;
using AutoMapper;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Persistance.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ContactListContext _context;
        private readonly IMapper _mapper;

        public ContactRepository(ContactListContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<Contact>> GetAllContactAsync()
        {
            try
            {
                var contacts = await _context.Contacts.ToListAsync()
                    ?? throw new InvalidOperationException("No contacts found");

                return _mapper.Map<List<Contact>>(contacts);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ContactRepository -> GetAllContactAsync: {ex.Message}");
            }
        }

        public async Task<Contact> GetContactByIdAsync(int contactId)
        {
            try
            {
                var contact = await _context.Contacts.FirstOrDefaultAsync(c => c.Id == contactId)
                    ?? throw new KeyNotFoundException($"Contact with ID {contactId} not found");

                return _mapper.Map<Contact>(contact);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ContactRepository -> GetContactByIdAsync: {ex.Message}");
            }
        }

        public async Task<Contact> AddContactAsync(ContactDto contactDto)
        {
            try
            {
                var emailExists = await _context.Contacts
                    .AnyAsync(c => c.Email == contactDto.Email);

                var phoneExists = await _context.Contacts
                    .AnyAsync(c => c.PhoneNumber == contactDto.PhoneNumber);

                if (emailExists)
                {
                    throw new InvalidOperationException("A contact with this email already exists.");
                }

                if (phoneExists)
                {
                    throw new InvalidOperationException("A contact with this phone number already exists.");
                }

                var contact = _mapper.Map<Contact>(contactDto);

                _context.Contacts.Add(contact);

                await _context.SaveChangesAsync();

                return contact;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ContactRepository -> AddContactAsync: {ex.Message}", ex);
            }
        }

        public async Task<Contact> UpdateContactAsync(ContactDto contactDto)
        {
            try
            {
                var contact = await _context.Contacts.FindAsync(contactDto.Id)
                    ?? throw new KeyNotFoundException($"Contact with ID {contactDto.Id} not found");

                var emailExists = await _context.Contacts
                   .AnyAsync(c => c.Email == contactDto.Email);

                var phoneExists = await _context.Contacts
                    .AnyAsync(c => c.PhoneNumber == contactDto.PhoneNumber);

                if (emailExists)
                {
                    throw new InvalidOperationException("A contact with this email already exists.");
                }

                if (phoneExists)
                {
                    throw new InvalidOperationException("A contact with this phone number already exists.");
                }

                _mapper.Map(contactDto, contact);

                await _context.SaveChangesAsync();

                return contact;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ContactRepository -> UpdateContactAsync: {ex.Message}", ex);
            }
        }

        public async Task<Contact> DeleteContactByIdAsync(int contactId)
        {
            try
            {
                var contact = await _context.Contacts.FindAsync(contactId)
                    ?? throw new KeyNotFoundException($"Contact with ID {contactId} not found");

                _context.Contacts.Remove(contact);

                await _context.SaveChangesAsync();

                return contact;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in ContactRepository -> DeleteContactByIdAsync: {ex.Message}");
            }
        }
    }
}