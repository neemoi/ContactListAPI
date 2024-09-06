using Application.UnitOfWork;
using Domain.Models;
using Persistance.Repository;

namespace Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        public IContactRepository ContactRepository { get; }

        private readonly ContactListContext _contactListContext;

        public UnitOfWork(ContactListContext contactListContext, IContactRepository contactRepository)
        {
            _contactListContext = contactListContext;
            ContactRepository = contactRepository; 
        }

        public async Task SaveChangesAsync()
        {
            await _contactListContext.SaveChangesAsync();
        }
    }
}