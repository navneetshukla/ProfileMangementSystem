using HelperLibrary;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProfileManagement.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
		public ActionResult GetUsers()
		{
			List<UserDetailsBO> users = null;

			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Constants.ProfileApiUrl);
				//HTTP GET
				var responseTask = client.GetAsync("profiles/users");
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsStringAsync();
					users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDetailsBO>>(readTask.Result);

					//readTask.Wait();

					       //users = readTask.Result;
				}
				return View(users);
			}
			
		}
		[HttpGet]
		public ActionResult Create()
		{
			return View("AddUsers");
		}
		[HttpPost]
		public ActionResult Create(CRUDUserRequest user)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Constants.ProfileApiUrl);
				//HTTP Post
				
				var responseTask = client.PostAsJsonAsync("profiles/saveUser", user);
				responseTask.Wait();
				var result = responseTask.Result;
			}
			return RedirectToAction("GetUsers");
		}
		[HttpGet]
		public ActionResult Edit(int userId)
		{
			List<UserDetailsBO> users = new List<UserDetailsBO>();
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Constants.ProfileApiUrl);
				//HTTP GET
				var responseTask = client.GetAsync($"profiles/users?userId={userId}");
				responseTask.Wait();

				var result = responseTask.Result;
				if (result.IsSuccessStatusCode)
				{
					var readTask = result.Content.ReadAsStringAsync();
					 users = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UserDetailsBO>>(readTask.Result);

					//readTask.Wait();

					//users = readTask.Result;
				}
				
			}
			return View("UpdateUser", users.FirstOrDefault());
		}
		[HttpPost]
		public ActionResult UpdateUserDetails(UserDetailsBO user)
		{
			CRUDUserRequest userResponse = new CRUDUserRequest
			{
				EmailId = user.EmailId,
				FirstName = user.FirstName,
				LastName = user.LastName,
				PhoneNumber = user.PhoneNumber,
				Status = user.Status,
				UserId = user.UserId
			};
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Constants.ProfileApiUrl);
				//HTTP Post

				var responseTask = client.PostAsJsonAsync("profiles/saveUser", userResponse);
				responseTask.Wait();
				var result = responseTask.Result;
			}
			return RedirectToAction("GetUsers");
		}
		[HttpGet]
		public ActionResult DeleteUser(int userId)
		{
			using (var client = new HttpClient())
			{
				client.BaseAddress = new Uri(Constants.ProfileApiUrl);
				//HTTP Post

				var responseTask = client.DeleteAsync($"profiles/deleteUser?userId={userId}");
				responseTask.Wait();
				var result = responseTask.Result;
			}
			return RedirectToAction("GetUsers");
		}
	}
}