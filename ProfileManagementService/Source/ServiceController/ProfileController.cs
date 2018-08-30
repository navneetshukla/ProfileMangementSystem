using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProfileManagementService.Source.ServiceController
{
    public class ProfileController : ApiController
    {
		readonly IProfileService _profileService ;

		public ProfileController(IProfileService profileService)
		{
			_profileService= profileService;
		}


		[Route("profiles/users")]
		[HttpGet]
		///<summary>
		public IHttpActionResult GetUserDetails(int userId=0)
		{
			try
			{
				List<UserDetailResponse> userDetailResponses = new List<UserDetailResponse>();
				var users = _profileService.GetUserDetails(userId);
				foreach (var user in users)
				{
					UserDetailResponse response = new UserDetailResponse
					{
						EmailId = user.EmailId,
						FirstName = user.FirstName,
						LastName = user.LastName,
						PhoneNumber = user.PhoneNumber,
						Status = user.Status,
						UserId = user.UserId
					};
					userDetailResponses.Add(response);
				}
				return Ok(userDetailResponses);
			}
			catch (Exception ex)
			{

				return InternalServerError();
			}
			
			
		}
		[Route("profiles/saveUser")]
		[HttpPost]
		public IHttpActionResult SaveUserDetails([FromBody]CRUDUserRequest request)

		{
			try
			{
				UserDetailsBO userBO = new UserDetailsBO
				{
					EmailId = request.EmailId,
					FirstName = request.FirstName,
					LastName = request.LastName,
					PhoneNumber = request.PhoneNumber,
					Status = request.Status,
					UserId = request.UserId
				};
				_profileService.SaveUserDetails(userBO);
			}
			catch (Exception ex)
			{

				return InternalServerError();
			}
			
			
			return Ok();
		}
		[Route("profiles/deleteUser")]
		[HttpDelete]
		public IHttpActionResult DeleteUserDetails(int userId )
		{
			try
			{
				List<UserDetailResponse> userDetailResponses = new List<UserDetailResponse>();
				_profileService.DeleteUserDetails(userId);
				return Ok(userDetailResponses);
			}
			catch (Exception)
			{
				return InternalServerError(); 
			}

		}




	}
}
