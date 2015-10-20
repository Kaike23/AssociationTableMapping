namespace Repository
{
	public static class MapperRegistry
	{
		static MapperRegistry()
		{
			Employees = new EmployeeMapper();
			Skills = new SkillMapper();
		}

		public static EmployeeMapper Employees { get; set; }
		public static SkillMapper Skills { get; set; }
	}
}
