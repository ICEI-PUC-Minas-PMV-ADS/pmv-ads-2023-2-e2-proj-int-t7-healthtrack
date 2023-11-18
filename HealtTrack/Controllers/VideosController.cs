using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealtTrack.Models;
using Microsoft.AspNetCore.Authorization;

namespace HealtTrack.Controllers
{
    [Authorize]
    public class VideosController : Controller
    {
        private readonly AppDbContext _context;

        public VideosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Videos.ToListAsync());
        }
    }
}
