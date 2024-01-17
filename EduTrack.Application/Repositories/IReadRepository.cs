using EduTrack.Domain.Common;

namespace EduTrack.Application.Repositories
{
    public interface IReadRepository<T, TId> : IRepository<T, TId> where T : EntityBase<TId>
    {
        List<T> GetAll();
        T GetById(TId id);
    }
}
