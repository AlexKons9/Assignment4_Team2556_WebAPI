using Assignment4_Team2556_WebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment4_Team2556_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BufferedFileUploadController : ControllerBase
    {
       
      
            readonly IBufferedFileUploadService _bufferedFileUploadService;

            public BufferedFileUploadController(IBufferedFileUploadService bufferedFileUploadService)
            {
                _bufferedFileUploadService = bufferedFileUploadService;
            }
            //[HttpGet]
            //public IActionResult Index()
            //{
            //    return Ok();
            //}

            [HttpPost]
            public async Task<ActionResult> Index(IFormFile file)
            {
                try
                {
                    if (await _bufferedFileUploadService.UploadFile(file))
                    {
                    return Ok("File Upload Successful");
                    }
                    else
                    {
                    return BadRequest("File Upload Failed");
                    }
                }
                catch (Exception ex)
                {
                //Log ex
                return BadRequest("File Upload Failed");
                }
            }
        }
    }

