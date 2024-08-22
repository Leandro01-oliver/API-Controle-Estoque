
using Businnes.Repositories.Interfaces;
using Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private readonly DataContext _db;

        public UnitOfWorkRepository(DataContext db) 
        {
            _db = db;
        }

        public async Task CommitAsync()
        {
            await _db.SaveChangesAsync();
        }

        public async Task Roolback()
        {
            _db.ChangeTracker.Entries().ToList().ForEach(entry => entry.State = EntityState.Detached);
            _db.Dispose();
        }

    }
}
