using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Models;
using TodoApi.Models;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoPersonsController : ControllerBase
    {
        private readonly TodoContext _context;

        public ToDoPersonsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/ToDoPersons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoPersonDTO>>> GetToDoPersons()
        {
            return await _context.ToDoPersons
                .Select(x => PersonToDTO(x))
                .ToListAsync();
        }

        [HttpGet("{ID}")]
        public async Task<ActionResult<ToDoPersonDTO>> GetToDoPerson(long ID)
        {
            var ToDoPerson = await _context.ToDoPersons.FindAsync(ID);

            if (ToDoPerson == null)
            {
                return NotFound();
            }

            return PersonToDTO(ToDoPerson);
        }

        [HttpPut("{ID}")]
        public async Task<IActionResult> UpdateToDoPerson(long ID, ToDoPersonDTO ToDoPersonDTO)
        {
            if (ID != ToDoPersonDTO.ID)
            {
                return BadRequest();
            }

            var ToDoPerson = await _context.ToDoPersons.FindAsync(ID);
            if (ToDoPerson == null)
            {
                return NotFound();
            }

            ToDoPerson.Name = ToDoPersonDTO.Name;
            ToDoPerson.IsAvailable = ToDoPersonDTO.IsAvailable;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!ToDoPersonExists(ID))
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<ToDoPersonDTO>> CreateToDoPerson(ToDoPersonDTO ToDoPersonDTO)
        {
            var ToDoPerson = new ToDoPerson
            {
                IsAvailable = ToDoPersonDTO.IsAvailable,
                Name = ToDoPersonDTO.Name
            };

            _context.ToDoPersons.Add(ToDoPerson);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetToDoPerson),
                new { ID = ToDoPerson.ID },
                PersonToDTO(ToDoPerson));
        }

        [HttpDelete("{ID}")]
        public async Task<IActionResult> DeleteToDoPerson(long ID)
        {
            var ToDoPerson = await _context.ToDoPersons.FindAsync(ID);

            if (ToDoPerson == null)
            {
                return NotFound();
            }

            _context.ToDoPersons.Remove(ToDoPerson);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ToDoPersonExists(long ID) =>
             _context.ToDoPersons.Any(e => e.ID == ID);
        private static ToDoPersonDTO PersonToDTO(ToDoPerson toDoPerson) =>
            new ToDoPersonDTO
            {
                ID = toDoPerson.ID,
                Name = toDoPerson.Name,
                IsAvailable = toDoPerson.IsAvailable
            };
    }
}
