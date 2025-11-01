using Nusuk.Core.Entities;

namespace Nusuk.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
    
        IUserRepository UsersRepository { get; }



        int Complete();

    }
}
