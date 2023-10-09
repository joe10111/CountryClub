using CountryClubAPI.DataAccess;
using CountryClubAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CountryClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {

        private readonly CountryClubContext _context;

        public BookingsController(CountryClubContext context)
        {
            _context = context;
        }

        public IActionResult AllBookings()
        {
            var bookings = _context.Bookings;

            return new JsonResult(bookings);
        }

        [HttpPost]
        public ActionResult CreateBooking(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            Response.StatusCode = 200;

            return new JsonResult(booking);
        }
    }
}
