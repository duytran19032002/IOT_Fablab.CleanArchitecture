using System.Linq.Expressions;

namespace IOT.Application.Contract.Persistence
{
	public interface IRepository<T, Key> where T : class
	{
		Task<T> GetByIdAsync(Key id);
		Task<IEnumerable<T>> GetAllAsync();
		IEnumerable<T> Find(Expression<Func<T, bool>> expression);
		IQueryable<T> FindAll(bool trackChanges = false);
		IQueryable<T> FindAll(bool trackChanges = false, params Expression<Func<T, object>>[] includeProperties);
		IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false);
		IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges = false,
			params Expression<Func<T, object>>[] includeProperties);

		//Task<T?> GetByIdAsync(Key id);
		void Update(T entity);
		void Add(T entity);
		void AddSyn(T entity);
		//(synchronous
		void AddRange(IEnumerable<T> entities);
		void Remove(T entity);
		void RemoveRange(IEnumerable<T> entities);
	}
}
