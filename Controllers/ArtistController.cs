using Microsoft.AspNetCore.Mvc;

namespace wemusic.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ArtistController : ControllerBase
    {

        private WeMusicDbContext _wemusicDbContext;

        public ArtistController(WeMusicDbContext context)
        {
            _wemusicDbContext = context;
        }



        [HttpGet]
        public IActionResult GetDepartment()
        {
            var department = _wemusicDbContext.Artists.ToList();
            if (department == null)
            {
                return NotFound($"Department with id  is not found");
            }
            return Ok(department);
        }


    }
}
