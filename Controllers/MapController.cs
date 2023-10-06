using Microsoft.AspNetCore.Mvc;
using API_JogoRPG.Models;
using API_JogoRPG.Data;
using Microsoft.EntityFrameworkCore;

namespace API_JogoRPG.Controllers;

[ApiController]
[Route("[controller]")]
public class MapController : ControllerBase
{
    private JogoRPGDbContext _context;

    public MapController(JogoRPGDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Map>>> ListarMap()
    {
        if(_context is null) return NotFound();
        if(_context.Map is null) return NotFound();

        return await _context.Map.ToListAsync();
    }

    [HttpPost]
    [Route("novoMap")]
    public async Task<ActionResult> NovoMap(Map map)
    {
        if(_context is null) return NotFound();
        if(_context.Map is null) return NotFound();

        await _context.AddAsync(map);
        await _context.SaveChangesAsync();

        return Created("", map);
    }

    [HttpDelete]
    [Route("deletar/{nome}")]
    public async Task<ActionResult> ExcluirMap(string nome)
    {
        if(_context is null) return NotFound();
        if(_context.Map is null) return NotFound();

        var mapTemp = await _context.Map.FindAsync(nome);

        if(mapTemp is null) return NotFound();

        _context.Remove(mapTemp);
        await _context.SaveChangesAsync();

        return Ok(mapTemp);
    }

    [HttpPatch]
    [Route("atualizar/{nome}")]
    public async Task<ActionResult> AtualizarMap(string nome, [FromForm] string clima = null, [FromForm] string bioma = null)
    {
        if(_context is null) return NotFound();
        if(_context.Map is null) return NotFound();

        var mapTemp = await _context.Map.FindAsync(nome);

        if(mapTemp is null) return NotFound();

        if(clima is not null) mapTemp.Clima = clima;
        if(bioma is not null) mapTemp.Bioma = bioma;
    

        await _context.SaveChangesAsync();

        return Ok(mapTemp);
    }
}
