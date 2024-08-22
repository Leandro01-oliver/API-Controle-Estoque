namespace Businnes.Repositories.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        Task CommitAsync();
        Task Roolback();
    }
}
