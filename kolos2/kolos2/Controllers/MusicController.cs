using kolos2.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace kolos2.Controllers
{
    [Route("api/")]
    [ApiController]
    public class MusicController : ControllerBase
    {
        private readonly IMusicDbService _dbService;
        public MusicController(IMusicDbService MusicDbService)
        {
            _dbService = MusicDbService;
        }
        [HttpGet("doctor")]
        public async Task<IActionResult> GetDoctor()
        {
            return await _dbService.GetTracks();
        }
      

    }
}
