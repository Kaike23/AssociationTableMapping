using System;
using System.Collections;

namespace Model
{
	public class Employee : Entity
	{
		private string firstName;
		private string lastName;
		private IList skillsData = new ArrayList();

		public Employee() { }
		public Employee(Guid id, string firstName, string lastName, IList skills)
			: base(id)
		{
			this.firstName = firstName;
			this.lastName = lastName;
			this.skillsData = skills;
		}

		public string FirstName
		{
			get { return firstName; }
			set { firstName = value; }
		}
		public string LastName
		{
			get { return lastName; }
			set { lastName = value; }
		}
		public IList Skills
		{
			get { return ArrayList.ReadOnly(skillsData); }
			set { skillsData = new ArrayList(value); }
		}
		public void AddSkill(Skill arg)
		{
			skillsData.Add(arg);
		}
		public void RemoveSkill(Skill arg)
		{
			skillsData.Remove(arg);
		}
	}
}
