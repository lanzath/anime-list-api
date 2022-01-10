using System.Linq;
using AnimeList.Data;
using AnimeList.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnimeList.Controllers;

[ApiController]
[Route("/animes")]
public class AnimeController : ControllerBase
{
    [HttpGet]
    public IActionResult ListAnimes([FromServices] AppDbContext context)
        => Ok(context.Animes.AsNoTracking().ToList());

    [HttpPost]
    public IActionResult StoreAnime(
        [FromBody] Anime anime,
        [FromServices] AppDbContext context)
    {
        context.Animes.Add(anime);
        context.SaveChanges();

        return Created($"/{anime.Id}", anime);
    }

    [HttpGet("{id:int}")]
    public IActionResult ShowAnime([FromRoute] int id, [FromServices] AppDbContext context)
    {
        var anime = context.Animes.AsNoTracking().FirstOrDefault(x => x.Id == id);
        if (anime == null)
            return NotFound();

        return Ok(anime);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnime(
        [FromRoute] int id,
        [FromBody] Anime anime,
        [FromServices] AppDbContext context)
    {
        var model = context.Animes.FirstOrDefault(x => x.Id == id);
        if (model == null)
            return NotFound();

        model.Title = anime.Title;
        model.Completed = anime.Completed;

        context.Animes.Update(model);
        context.SaveChanges();

        return Ok(model);
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnime([FromRoute] int id, [FromServices] AppDbContext context)
    {
        var model = context.Animes.FirstOrDefault(x => x.Id == id);
        if (model == null)
            return NotFound();
        context.Animes.Remove(model);
        context.SaveChanges();

        return NoContent();
    }
}
