using PlanningPoker.Core.Entities;

namespace PlanningPoker.Api.Repository
{
    public interface IRepositoryBase<T> where T : EntityBase
    {
        Task<List<T>> GetAllAsync();
        Task<T?> GetOneAsync(Guid id);
        Task<T> CreateAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task DeleteAsync(Guid id);
    }
}
