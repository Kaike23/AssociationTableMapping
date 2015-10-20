using System;

namespace Repository.Repositories
{
	using Model;

	public class Repository<T> : IRepository<T>
		where T : Entity
	{
		private IMapper mapper;

		public Repository(IMapper mapper)
		{
			this.mapper = mapper;
		}

		public T Find(Guid id)
		{
			return mapper.Find(id) as T;
		}

		public Guid Insert(T entity)
		{
			return mapper.Insert(entity);
		}

		public void Update(T entity)
		{
			mapper.Update(entity);
		}

		public void Delete(T entity)
		{
			mapper.Delete(entity);
		}

		public IMapper Mapper { get { return mapper; } }
	}
}
