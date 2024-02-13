namespace EvenlyAPI.Services
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> AddAsync(T entity);
        Task<T?> UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
