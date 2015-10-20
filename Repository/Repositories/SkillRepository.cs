using Model;
using Repository.Repositories;

namespace Repository
{
	public class SkillRepository : Repository<Skill>, ISkillRepository
	{
		public SkillRepository()
			: base(MapperRegistry.Skills) { }
	}
}
