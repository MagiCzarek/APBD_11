using System.Linq;
using APBD_11.Models;
using Microsoft.AspNetCore.Mvc;

namespace APBD_11.Controllers
{
    [Route("api/[doctor]")]
    [ApiController]
    public class DoctorsController : Controller
    {
        private readonly PrescDbContext _context;
            public DoctorsController(PrescDbContext context)
            {
                _context = context;
            }
        
            [HttpPost]
            public IActionResult AddDoctor(Doctor doctor)

            {
                _context.Doctors.Add(doctor);
                _context.SaveChanges();
                return Ok(doctor);
            }
            [HttpPut]
            public IActionResult ModifyDoctor(Doctor doctor)
            {
                _context.Doctors.Update(doctor);
                _context.SaveChanges();
                return Ok(doctor);
            }
            [HttpDelete("{id}")]
            public IActionResult DeleteDoctor(int id)
            {
                _context.Doctors.Remove(_context.Doctors.First(d => d.Id == id));
                _context.SaveChanges();
                return NoContent();
            }

        [HttpGet("{id}")]
        public IActionResult GetDoctor(int id)
        {
            //nie wiem dlaczego nie dziala
            var item = _context.Doctors.Select(x => x.Id == id).FirstOrDefault();

            if (item != null)
            {
                return Ok(item);
            }

            return Ok();
        }
    }
}