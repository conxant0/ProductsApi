using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Data;
using ProductsApi.Dtos;
using ProductsApi.Models;

namespace ProductsApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly AppDbContext _context;

    public GamesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/games
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var games = await _context.Games.ToListAsync();

        var response = games.Select(g => new GameResponseDto
        {
            Id = g.Id,
            GameName = g.GameName,
            Price = g.Price,
            HoursSpent = g.HoursSpent
        });

        return Ok(response);
    }

    // GET: api/games/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null) return NotFound();

        var response = new GameResponseDto
        {
            Id = game.Id,
            GameName = game.GameName,
            Price = game.Price,
            HoursSpent = game.HoursSpent
        };

        return Ok(response);
    }

    // POST: api/games
    // Accepts CreateGameDto, client cannot supply an Id.
    // We map it to a Game entity before saving.
    [HttpPost]
    public async Task<IActionResult> Create(CreateGameDto dto)
    {
        var game = new Game
        {
            GameName = dto.GameName,
            Price = dto.Price,
            HoursSpent = dto.HoursSpent
        };

        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        var response = new GameResponseDto
        {
            Id = game.Id,
            GameName = game.GameName,
            Price = game.Price,
            HoursSpent = game.HoursSpent
        };

        return CreatedAtAction(nameof(GetById), new { id = game.Id }, response);
    }

    // PUT: api/games/5
    // Accepts UpdateGameDto, Id comes from the URL, not the body.
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateGameDto dto)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null) return NotFound();

        // EF detects these changes and saves them on SaveChangesAsync.
        game.GameName = dto.GameName;
        game.Price = dto.Price;
        game.HoursSpent = dto.HoursSpent;

        await _context.SaveChangesAsync();

        var response = new GameResponseDto
        {
            Id = game.Id,
            GameName = game.GameName,
            Price = game.Price,
            HoursSpent = game.HoursSpent
        };

        return Ok(response);
    }

    // DELETE: api/games/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var game = await _context.Games.FindAsync(id);
        if (game == null) return NotFound();

        _context.Games.Remove(game);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
