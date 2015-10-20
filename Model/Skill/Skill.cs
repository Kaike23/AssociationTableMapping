using System;

namespace Model
{
	public class Skill : Entity
	{
		private string name;

		public Skill() { }
		public Skill(Guid id, string name)
			: base(id)
		{
			this.name = name;
		}
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
	}
}
