using EduTrack.Application.Repositories;
using EduTrack.Domain.Common;

namespace EduTrack.Application.Repositories
{
    public interface IWriteRepository<T, TId> : IRepository<T, TId> where T : EntityBase<TId>
    {
        void Add(T entity);
        void Delete(TId id);
        void SaveChanges();
    }
}
