using Businnes.Repositories.Interfaces;
using Bussines.Services.Interfaces;

namespace Bussines.Services
{
    public class UnitOfWorkService(IUnitOfWorkRepository unitOfWorkRepository) : IUnitOfWorkService
    {
        private readonly IUnitOfWorkRepository _unitOfWorkRepository = unitOfWorkRepository;

        public async Task Roolback()
        {
            await _unitOfWorkRepository.Roolback();
        }

        public async Task CommitAsync()
        {
            await _unitOfWorkRepository.CommitAsync();
        }
    }
}
