namespace Assignment4_Team2556_WebAPI.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> AddOrUpdateAsync(T entity);
        Task<T?> GetAsync(int? id);
        Task<IList<T>> GetAllAsync();
        Task<bool> RemoveAsync(T entity);
    }
}
