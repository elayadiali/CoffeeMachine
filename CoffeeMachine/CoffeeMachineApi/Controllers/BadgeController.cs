using CoffeeApiMachine.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeApiMachine.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BadgeController : ControllerBase
    {
        private readonly IBadgeService badgeService;

        public BadgeController(IBadgeService badgeService)
        {
            this.badgeService = badgeService;
        }


        [HttpGet("GetOnwer/{badgeNumber}")]
        public string GetOnwer(string badgeNumber)
        {
            var owner = badgeService.GetOwner(badgeNumber);

            return owner;
        }
    }
}
