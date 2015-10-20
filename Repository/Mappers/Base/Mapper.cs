using System;
using System.Data.SqlClient;
using Model;

namespace Repository
{
	public abstract class Mapper<T> : IMapper
		where T : Entity, new()
	{
		protected static readonly string SQL_CONNECTION = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=D:\GitHub\AssociationTableMapping\Repository\TestData\TestDB.mdf;Integrated Security=True;Connect Timeout=30";

		private static IdentityMap loadedMap = new IdentityMap();

		#region IMapper implementation

		public Entity Find(Guid id)
		{
			var result = loadedMap.Get(id);
			if (result != null) return result;

			var sqlConnection = new SqlConnection(SQL_CONNECTION);
			sqlConnection.Open();
			try
			{
				using (var sqlCommand = new SqlCommand(FindStatement, sqlConnection))
				{
					sqlCommand.Parameters.AddWithValue("@Id", id);
					var reader = sqlCommand.ExecuteReader();
					result = Load(reader);
					reader.Close();
				}
				return result;
			}
			catch (SqlException e)
			{
				throw new ApplicationException(e.Message, e);
			}
			finally
			{
				sqlConnection.Close();
			}
		}

		public Guid Insert(Entity entity)
		{
			throw new NotImplementedException();
		}
		public void Update(Entity entity)
		{
			var connection = new SqlConnection(SQL_CONNECTION);
			connection.Open();
			using (var trans = connection.BeginTransaction())
			{
				try
				{
					var updateCommand = new SqlCommand(UpdateStatement, connection, trans);
					updateCommand.Parameters.AddWithValue("@Id", entity.Id);
					DoUpdate(entity as T, updateCommand);
					var rowCount = updateCommand.ExecuteNonQuery();
				}
				catch (SqlException e)
				{
					throw new ApplicationException(e.Message, e);
				}
				finally
				{
					connection.Close();
				}
			}
		}
		public void Delete(Entity entity)
		{
			throw new NotImplementedException();
		}

		#endregion

		protected Entity Load(SqlDataReader reader)
		{
			if (!reader.HasRows || !reader.Read()) return default(T);
			var id = reader.GetGuid(0);
			if (loadedMap.Contains(id)) return loadedMap.Get(id);
			var result = DoLoad(id, reader);
			DoRegister(id, result);
			return result;
		}

		public void DoRegister(Guid id, Entity result)
		{
			loadedMap.Add(id, result);
		}

		protected abstract string FindStatement { get; }
		protected abstract string UpdateStatement { get; }
		protected abstract T DoLoad(Guid id, SqlDataReader reader);
		protected abstract void DoUpdate(T entity, SqlCommand updateCommand);
	}
}
