using Microsoft.EntityFrameworkCore;
using EduTrack.Domain.Common;

namespace EduTrack.Application.Repositories
{
    public interface IRepository<T, TId> where T : EntityBase<TId>
    {
        DbSet<T> Table { get; }
    }
}
