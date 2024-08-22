namespace Bussines.Services.Interfaces
{
    public interface IUnitOfWorkService
    {
        Task CommitAsync();
        Task Roolback();
    }
}
