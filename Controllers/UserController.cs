using kotkangrilli.Data;
using kotkangrilli.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace kotkangrilli.Controllers;

[ApiController]
[Route("users")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(_context.Users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        return Ok(_context.Set<User>().Find(id));
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _context.Set<User>().Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        _context.Entry(user).State = EntityState.Modified;
        user.UpdatedAt = DateTime.Now;
        
        await _context.SaveChangesAsync();
        return Ok(user);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            // fetch user
            var user = await _context.Users.FindAsync(id);
            
            // check if user exists
            if (user == null)
            {
                return NotFound();
            }
            
            // remove user
            _context.Users.Remove(user);
            
            // save changes
            await _context.SaveChangesAsync();
            
            return Ok();
            
        } catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}