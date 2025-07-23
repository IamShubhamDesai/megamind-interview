using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MegaMinds_Practical.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        public DataController( IWebHostEnvironment env) 
        {
            _env = env;
        }

       
        [HttpPost("save-data")]
        public IActionResult SaveData([FromBody] object updatedData)
        {
            string filePath = Path.Combine(_env.WebRootPath, "assets", "data.json");

            try
            {
                System.IO.File.WriteAllText(filePath, updatedData.ToString());
                return Ok(new { status = "success", message = "Data saved." });
            }
            catch (Exception ex)
            {   
                return StatusCode(500, new { status = "error", message = ex.Message });
            }
        }

    }
}
