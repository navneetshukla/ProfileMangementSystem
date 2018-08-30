using ProfileDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProfileManagementService.Source
{
	public class ProfileOperations : IProfileOperations
	{
		public List<UserDetailsBO> GetUserDetails(int userId)
		{
			List<UserDetailsBO> userDetails=new List<UserDetailsBO>();
			using (var db = new UCM_MAINEntities())
			{
				if(userId==0)
				{
				    userDetails = db.UserDetails.Select(p => new UserDetailsBO
					{
						EmailId = p.EmailId,
						FirstName = p.FirstName,
						LastName = p.LastName,
						PhoneNumber = p.PhoneNumber,
						Status = p.Status,
						UserId = p.UserId
					}).ToList();
				}
				else
				{
					userDetails = db.UserDetails.Where(id=>id.UserId==userId).Select(p => new UserDetailsBO
					{
						EmailId = p.EmailId,
						FirstName = p.FirstName,
						LastName = p.LastName,
						PhoneNumber = p.PhoneNumber,
						Status = p.Status,
						UserId = p.UserId
					}).ToList();
				}
				


				 return userDetails;
			}
		}

		public void SaveUserDetails(UserDetailsBO userDetails)
		{
			using (var db = new UCM_MAINEntities())
			{
				var user = db.UserDetails.Where(p => p.UserId == userDetails.UserId).FirstOrDefault();
				if(null!=user)
				{//Update scenario
					user.FirstName = userDetails.FirstName;
					user.EmailId = userDetails.EmailId;
					user.LastName = userDetails.LastName;
					user.Status = userDetails.Status;
					user.PhoneNumber = userDetails.PhoneNumber;
				}
				else
				{//Add new record
					db.UserDetails.Add(new UserDetail
					{
						EmailId = userDetails.EmailId,
						FirstName = userDetails.FirstName,
						LastName = userDetails.LastName,
						PhoneNumber = userDetails.PhoneNumber,
						Status = userDetails.Status,
						UserId = userDetails.UserId
					});
				}
				db.SaveChanges();

			}
		}

		

		public void DeleteUserDetails(int userId)
		{
			using (var db = new UCM_MAINEntities())
			{
				var user = db.UserDetails.Where(p => p.UserId == userId).FirstOrDefault();
				db.UserDetails.Remove(user);
				db.SaveChanges();
			}
		}

	}
}