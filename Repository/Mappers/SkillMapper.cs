using System;
using System.Data.SqlClient;
using Model;

namespace Repository
{
	public class SkillMapper : Mapper<Skill>
	{
		protected override string FindStatement
		{
			get { return "SELECT Id, Name FROM Skills WHERE Id = @Id"; }
		}

		protected override string UpdateStatement
		{
			get { return "UPDATE Skills SET Name = @Name WHERE Id = @Id"; }
		}

		protected override Skill DoLoad(Guid id, SqlDataReader reader)
		{
			var name = reader.GetString(1);
			var skill = new Skill(id, name);
			return skill;
		}

		protected override void DoUpdate(Skill entity, SqlCommand updateCommand)
		{
			updateCommand.Parameters.AddWithValue("@Name", entity.Name);
		}
	}
}
