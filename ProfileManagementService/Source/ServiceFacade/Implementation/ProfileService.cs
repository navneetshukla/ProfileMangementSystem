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

		public List<UserDetailsBO> GetUserDetails(int userId)
		{
			return _profileOperations.GetUserDetails(userId);
		}

		public void SaveUserDetails(UserDetailsBO userDetails)
		{
			 _profileOperations.SaveUserDetails(userDetails);
		}

		public void DeleteUserDetails(int userId)
		{
			 _profileOperations.DeleteUserDetails(userId);
		}
	}
}