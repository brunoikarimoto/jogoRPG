using Microsoft.AspNetCore.Mvc;
using API_JogoRPG.Models;
using API_JogoRPG.Data;
using Microsoft.EntityFrameworkCore;

namespace API_JogoRPG.Controllers;

[ApiController]
[Route("[controller]")]
public class ClasseController : ControllerBase
{
    private JogoRPGDbContext _context;

    public ClasseController(JogoRPGDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Classe>>> ListarClasse()
    {
        if(_context is null) return NotFound();
        if(_context.Classe is null) return NotFound();

        return await _context.Classe.ToListAsync();
    }

    [HttpPost]
    [Route("novaClasse")]
    public async Task<ActionResult> NovaClasse(Classe classe)
    {
        if(_context is null) return NotFound();
        if(_context.Classe is null) return NotFound();

        await _context.AddAsync(classe);
        await _context.SaveChangesAsync();

        return Created("", classe);
    }

    [HttpDelete]
    [Route("deletar/{nome}")]
    public async Task<ActionResult> ExcluirClasse(string nome)
    {
        if(_context is null) return NotFound();
        if(_context.Classe is null) return NotFound();

        var classeTemp = await _context.Classe.FindAsync(nome);

        if(classeTemp is null) return NotFound();

        _context.Remove(classeTemp);
        await _context.SaveChangesAsync();

        return Ok(classeTemp);
    }

    [HttpPatch]
    [Route("atualizar/{nome}")]
    public async Task<ActionResult> AtualizarClasse(string nome, [FromForm] string descricao = null)
    {
        if(_context is null) return NotFound();
        if(_context.Classe is null) return NotFound();

        var classeTemp = await _context.Classe.FindAsync(nome);

        if(classeTemp is null) return NotFound();

        if(descricao is not null) classeTemp.descricao = descricao;
    

        await _context.SaveChangesAsync();

        return Ok(classeTemp);
    }
}
