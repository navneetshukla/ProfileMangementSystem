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
		[Route("profiles/contacts")]
		[HttpGet]
		public IHttpActionResult GetContacts()
		{
			_profileService.Test();
			return Ok();
		}



    }
}
