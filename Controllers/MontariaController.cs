using Microsoft.AspNetCore.Mvc;
using API_JogoRPG.Models;
using API_JogoRPG.Data;
using Microsoft.EntityFrameworkCore;

namespace API_JogoRPG.Controllers;

[ApiController]
[Route("[controller]")]
public class MontariaController : ControllerBase
{
    private JogoRPGDbContext _context;

    public MontariaController(JogoRPGDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Montaria>>> ListarMontaria()
    {
        if(_context is null) return NotFound();
        if(_context.Montaria is null) return NotFound();

        return await _context.Montaria.ToListAsync();
    }

    [HttpPost]
    [Route("novaMontaria")]
    public async Task<ActionResult> NovaMontaria(Montaria montaria)
    {
        if(_context is null) return NotFound();
        if(_context.Montaria is null) return NotFound();

        await _context.AddAsync(montaria);
        await _context.SaveChangesAsync();

        return Created("", montaria);
    }

    [HttpDelete]
    [Route("deletar/{nome}")]
    public async Task<ActionResult> ExcluirMontaria(string nome)
    {
        if(_context is null) return NotFound();
        if(_context.Montaria is null) return NotFound();

        var montariaTemp = await _context.Montaria.FindAsync(nome);

        if(montariaTemp is null) return NotFound();

        _context.Remove(montariaTemp);
        await _context.SaveChangesAsync();

        return Ok(montariaTemp);
    }

    [HttpPatch]
    [Route("atualizar/{nome}")]
    public async Task<ActionResult> AtualizarMontaria(string nome, [FromForm] string raridade = null, [FromForm] int velocidade = 0, [FromForm] string tipo = null)
    {
        if(_context is null) return NotFound();
        if(_context.Montaria is null) return NotFound();

        var montariaTemp = await _context.Montaria.FindAsync(nome);

        if(montariaTemp is null) return NotFound();

        if(raridade is not null) montariaTemp.raridade = raridade;
        if(velocidade >= 0) montariaTemp.velocidade = velocidade;
        if(tipo is not null) montariaTemp.tipo = tipo;

        await _context.SaveChangesAsync();

        return Ok(montariaTemp);
    }
}
