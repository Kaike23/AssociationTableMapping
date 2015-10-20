using System;
using System.Data.SqlClient;
using Model;

namespace Repository
{
	public class EmployeeMapper : Mapper<Employee>
	{
		protected override string FindStatement
		{
			get { return "SELECT Id, FirstName, LastName FROM Employees WHERE Id = @Id"; }
		}

		protected override string UpdateStatement
		{
			get { return "UPDATE Employees SET FirstName = @FirstName, LastName = @LastName WHERE Id = @Id"; }
		}

		protected override Employee DoLoad(Guid id, SqlDataReader reader)
		{
			var firstName = reader.GetString(1);
			var lastName = reader.GetString(2);
			var employee = new Employee(id, firstName, lastName, null);
			return employee;
		}

		protected override void DoUpdate(Employee entity, SqlCommand updateCommand)
		{
			updateCommand.Parameters.AddWithValue("@FirstName", entity.FirstName);
			updateCommand.Parameters.AddWithValue("@LastName", entity.LastName);
		}
	}
}
