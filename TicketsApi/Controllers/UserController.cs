using Microsoft.AspNetCore.Mvc;
using TicketsApi.Models;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TicketsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;
    private readonly DataContext _context;

    private bool UserExists(long id)
    {
        return _context.Users.Any(e => e.UserId == id);
    }


    public UserController(ILogger<UserController> logger, DataContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<User>> GetAll()
    {
        List<User> users = await _context.Users.ToListAsync();
        return users;

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(long id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    [HttpPost]
    public async Task<ActionResult<User>> PostUser([FromBody] User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetUser), new { id = user.UserId }, user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(long id)
    {
        var todoItem = await _context.Users.FindAsync(id);
        if (todoItem == null)
        {
            return NotFound();
        }

        _context.Users.Remove(todoItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(long id, User user)
    {
        if (id != user.UserId)
        {
            return BadRequest();
        }

        var updatedUser = await _context.Users.FindAsync(id);
        if (updatedUser == null)
        {
            return NotFound();
        }

        updatedUser.FirstName = user.FirstName;
        updatedUser.LastName = user.LastName;

        return NoContent();

        }

    }
