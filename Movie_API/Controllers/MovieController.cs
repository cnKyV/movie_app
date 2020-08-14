using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Movie_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {

        private readonly MovieDbContext _movieDbContext;

        private readonly ILogger<MovieController> _logger;

        public MovieController(ILogger<MovieController> logger, MovieDbContext movieDbContext)
        {
            _logger = logger;
            _movieDbContext = movieDbContext; //dependency injection
        }

        [HttpGet]
        public IActionResult Get()
        {
            return BadRequest(new {test = "Test" });
        }
    }
}
