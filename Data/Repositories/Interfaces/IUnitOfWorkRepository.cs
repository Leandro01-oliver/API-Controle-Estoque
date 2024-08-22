namespace Data.Repositories.Interfaces
{
    public interface IUnitOfWorkRepository
    {
        Task CommitAsync();
        Task Roolback();
    }
}
