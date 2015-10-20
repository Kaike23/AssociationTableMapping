using Model;
using Repository.Repositories;

namespace Repository
{
	class EmployeeRepository : Repository<Employee>, IEmployeeRepository
	{
		public EmployeeRepository()
			: base(MapperRegistry.Employees)
		{ }
	}
}
