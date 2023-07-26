namespace CashRegister.Api.Persistence.Repositories;

public interface IUnitOfWork
{
    public IUserRepository UserRepository { get; }
}

public class UnitOfWork : IUnitOfWork
{
    public UnitOfWork(IUserRepository userRepository)
    {
        UserRepository = userRepository;
    }

    public IUserRepository UserRepository { get; }
}