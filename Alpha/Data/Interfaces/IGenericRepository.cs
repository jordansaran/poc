namespace Data.Interfaces;

public interface IGenericRepository<T> where T : class
{
    Task<T?> GetById(int id);
    Task<List<T>> GetAll();
    Task Add(T entity);
    void Delete(T entity);
    void Update(T entity);
    Task<int> Save();
}