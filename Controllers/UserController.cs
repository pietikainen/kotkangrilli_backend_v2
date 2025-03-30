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

    // Get all users
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        return Ok(_context.Users);
    }

    // Get user by user_id
    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        return Ok(_context.Set<User>().Find(id));
    }

    // Create new user
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

    // Update user
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

    // Delete user
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
    
    // Get user role by user_id
    [HttpGet("role/{id}")]
    public async Task<IActionResult> GetUserRole(int id)
    {
        try
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            
            return Ok(user.Level);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    
}