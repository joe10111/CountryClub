using CountryClubAPI.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace CountryClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : Controller
    {
        private readonly CountryClubContext _context;

        public FacilitiesController(CountryClubContext context)
        {
            _context = context;
        }

        public IActionResult AllFacilities()
        {
            var facilities = _context.Facilities;
            return new JsonResult(facilities);
        }
    }
}
