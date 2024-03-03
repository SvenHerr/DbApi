using DiskSpaceApi.Models;
using DiskSpaceApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace DiskSpaceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DiskSpaceController : ControllerBase
    {
        private readonly ILogger<DiskSpaceController> _logger;
        private readonly IDiskSpaceService _diskSpaceService;

        public DiskSpaceController(ILogger<DiskSpaceController> logger, IDiskSpaceService diskSpaceService)
        {
            _logger = logger;
            _diskSpaceService = diskSpaceService;
        }

        [HttpGet("/test",Name = "Test")]
        public IActionResult Get()
        {
            _logger.LogInformation("Test called. Info");
            _logger.LogWarning("Test called. Warning");
            _logger.Log(LogLevel.Information, "test");
            _logger.LogError("test");
        
            return Ok("Alles ok");
        }

        [HttpPost("/diskspace")]
        public IActionResult AddDiskSpace([FromBody] DiskSpace data)
        {
            data.Timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            _diskSpaceService.AddDiskSpace(data);

            return new ObjectResult(new { message = "Disk space information added successfully" }) { StatusCode = 201 };
        }

        [HttpGet("/diskspace")]
        public IEnumerable<DiskSpace> GetDiskSpace()
        {
            return _diskSpaceService.GetAllDiskSpaces();
        }
    }
}
