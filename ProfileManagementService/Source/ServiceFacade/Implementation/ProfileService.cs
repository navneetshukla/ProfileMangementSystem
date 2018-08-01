using ProfileManagementService.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfileManagementService.Source
{
	public class ProfileService :IProfileService
	{
		readonly IProfileOperations _profileOperations;

		public ProfileService(IProfileOperations profileOperations)
		{
			_profileOperations = profileOperations;
		}

		public string Test()
		{
			return string.Empty;
		}
	}
}