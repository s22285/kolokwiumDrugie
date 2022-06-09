using kolos2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolos2.Services
{
    public interface IMusicDbService
    {
        public Task<IActionResult> GetTracks();
    }
    public class MusicDbService : IMusicDbService
    {
        private MainDbContext _context;
        public MusicDbService(IMusicDbContext context)
        {
            _context = (MainDbContext)context;
        }
        public async Task<IActionResult> GetTracks()
        {
            return new OkObjectResult(await _context.Track.ToListAsync());
        }
    }

}
