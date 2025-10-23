using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using shift_management.Data;
using shift_management.Models;

namespace shift_management.Controllers
{
    [ApiController]
    [Route ("api/[controller]")]

    public class TurnController : ControllerBase
    {


        private readonly AppDbContext _context;



        public TurnController(AppDbContext context) 
        {
            _context = context;
        }

        // get 
        [HttpGet]
        public IActionResult GetAll()
        {
            var turns = _context.Turns.ToList();
            return Ok(turns);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Turn turn)
        {
            if (turn == null)
            {
                return BadRequest();
            }

            _context.Turns.Add(turn);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAll), new { id = turn.Id }, turn);

        }
    }
}
