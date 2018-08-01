using ProfileDAL.Source.DalMangerService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfileDAL.Source
{
	public class DalManager : IDalManager
	{
		readonly IDalDbContext _dalDbContext;

		public DalManager(IDalDbContext dalDbContext)
		{
			_dalDbContext = dalDbContext;
		}

		public SqlConnection GetSqlDbContext(string connectionString)
		{
			return new SqlConnection(connectionString);
		}
	}
}
