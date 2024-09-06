using Persistance.Repository;

namespace Application.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IContactRepository ContactRepository { get; }

        Task SaveChangesAsync();
    }
}