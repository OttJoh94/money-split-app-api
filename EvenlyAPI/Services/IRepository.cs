namespace EvenlyAPI.Services
{
	public interface IRepository<T> where T : class
	{
		IEnumerable<T> GetAll();
		T? GetById(int id);
		IEnumerable<T> Add(T entity);
		T? Update(int id, T entity);
		void Delete(int id);
	}
}
