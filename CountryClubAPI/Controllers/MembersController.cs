using CountryClubAPI.DataAccess;
using CountryClubAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CountryClubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        private readonly CountryClubContext _context;

        public MembersController(CountryClubContext context)
        {
            _context = context;
        }

        public IActionResult AllMembers()
        {
            var members = _context.Members;

            return new JsonResult(members);
        }

        [HttpGet("{memberId}")]
        public IActionResult MemberFromId(int memberId)
        {
            // Pull out member using id
            var member = _context.Members.Find(memberId);

            if (member == null) return NotFound();

            Response.StatusCode = 200;

            return new JsonResult(member);
        }

        [HttpPost]
        public ActionResult CreateMember(Member member)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _context.Members.Add(member);
            _context.SaveChanges();

            Response.StatusCode = 200;

            return new JsonResult(member);
        }

        [HttpPut("{memberId}")]
        public ActionResult UpdateMember(int memberId, Member member)
        {
            var memberToUpdate = _context.Members.Find(memberId);
            if (member == null) return NotFound();

            memberToUpdate = member;

            _context.Members.Update(memberToUpdate);
            _context.SaveChanges();

            Response.StatusCode = 204;

            return new JsonResult(memberToUpdate);
        }

        [HttpDelete("{memberId}")]
        public ActionResult DeleteMember(int memberId)
        {
            var memberToDelete = _context.Members.Find(memberId);
            if (memberToDelete == null) return NotFound();

            _context.Members.Remove(memberToDelete);
            _context.SaveChanges();

            Response.StatusCode = 204;

            return new JsonResult(memberToDelete);
        }
    }
}
