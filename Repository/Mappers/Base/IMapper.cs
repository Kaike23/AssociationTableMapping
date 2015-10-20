using System;

namespace Repository
{
	using Model;

	public interface IMapper
	{
		Entity Find(Guid id);

		Guid Insert(Entity entity);
		void Update(Entity entity);
		void Delete(Entity entity);
	}
}
