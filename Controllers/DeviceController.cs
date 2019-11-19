using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AwesomeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AwesomeAPI.Controllers
{
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private ApplicationDbContext _context;

        public DeviceController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("Get all devices")]
        public async Task<IActionResult> Get()
        {
            return Ok(_context.devices);
        }


        [HttpGet("Get device by id")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok(_context.devices.Where(x => x.Id == id).FirstOrDefault());
        }


        [HttpPost("Add new device")]
        public async Task<IActionResult> Post([FromBody] Device value)
        {
            _context.devices.Add(value);
            _context.SaveChanges();
            return Ok(value);
        }


        [HttpPut("Update device")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Device value)
        {
            Device found = _context.devices.Where(x => x.Id == id).FirstOrDefault();
            if(found == null)
            {
                return BadRequest();
            }

            _context.devices.Update(value);
            _context.SaveChanges();

            return Ok(value);
        }


        [HttpDelete("Delete device")]
        public async Task<IActionResult> Delete(Guid id)
        {
            Device found = _context.devices.Where(x => x.Id == id).FirstOrDefault();
            if (found == null)
            {
                return BadRequest();
            }

            _context.devices.Remove(found);
            _context.SaveChanges();

            return Ok(found);

        }
    }
}
