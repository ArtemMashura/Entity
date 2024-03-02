using Entity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private EntityStartContext _context;
        public ValuesController(EntityStartContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<user> users = await _context.users.ToListAsync();
            if (users == null)
            {
                NotFound();
            }

            return Ok(users);
        }
    }
}
