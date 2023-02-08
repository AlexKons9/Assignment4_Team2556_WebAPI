namespace Assignment4_Team2556_WebAPI.Services
{
    public interface IGenericService<T> where T : class
    {
        Task<T> AddOrUpdateAsync(T entity);
        Task<T?> GetAsync(int? id);
        Task<IList<T>> GetAllAsync();
        Task<bool> RemoveAsync(T entity);
    }
}
