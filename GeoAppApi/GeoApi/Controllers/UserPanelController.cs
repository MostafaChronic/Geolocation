
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CoreDomain.Models;
using GeoApi.ViewModel;
using Infrastructure.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace GeoApi.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    public class UserPanelController : Controller
    {
        private readonly ClaimsPrincipal _caller;
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<AppUser> _userManager;

        public UserPanelController(UserManager<AppUser> userManager, AppDbContext appDbContext, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _appDbContext = appDbContext;
            _userManager = userManager;
        }

        // GET api/UserPanel/home
        [HttpGet]
        public async Task<IActionResult> Home()
        {

            var userId = _caller.Claims.Single(c => c.Type == "id");
            var customer = await _userManager.Users.Include(p => p.GeoLocations).SingleOrDefaultAsync(p => p.Id == userId.Value);

            if (customer == null) return NotFound();
            //customer.GeoLocations.ToArray()
            var list = new List<UserDistanceViewModel>();
            foreach (var item in customer.GeoLocations)
            {
                var ent = new UserDistanceViewModel();
                ent.Username = customer.UserName;
                ent.lat1 = item.FirstLat;
                ent.lat2 = item.SecLat;
                ent.long1 = item.FirstLong;
                ent.long2 = item.SecLong;
                ent.distance = item.FinalDistance;
                list.Add(ent);
            }
            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Distance([FromBody]DistanceCalculateViewModel viewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var userId = _caller.Claims.Single(c => c.Type == "id");

            var dist = new Helpers.Distance();
            var Distance_KM = dist.GetDistance(viewModel.FirstLat, viewModel.FirstLong, viewModel.SecLat, viewModel.SecLong);

            await _appDbContext.GeoLocations.AddAsync(new GeoLocation()
            {
                FirstLat = viewModel.FirstLat,
                FirstLong = viewModel.FirstLong,
                UserId = userId.Value,
                RequestDate = DateTime.Now,
                SecLat = viewModel.SecLat,
                SecLong = viewModel.SecLong,
                FinalDistance = Distance_KM
            });

            await _appDbContext.SaveChangesAsync();

            return new OkObjectResult(new { Message = "Distance between Two Location : " + Distance_KM + " Km", });
        }


    }
}
