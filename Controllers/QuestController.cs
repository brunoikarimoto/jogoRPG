using Microsoft.AspNetCore.Mvc;
using API_JogoRPG.Models;
using API_JogoRPG.Data;
using Microsoft.EntityFrameworkCore;

namespace API_JogoRPG.Controllers;

[ApiController]
[Route("[controller]")]
public class QuestController : ControllerBase
{
    private JogoRPGDbContext _context;

    public QuestController(JogoRPGDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Quest>>> ListarQuest()
    {
        if(_context is null) return NotFound();
        if(_context.Quest is null) return NotFound();

        return await _context.Quest.ToListAsync();
    }

    [HttpPost]
    [Route("novaQuest")]
    public async Task<ActionResult> NovaQuest(Quest quest)
    {
        if(_context is null) return NotFound();
        if(_context.Quest is null) return NotFound();

        if(quest.MinimoNivel < 0) quest.MinimoNivel = 0;

        await _context.AddAsync(quest);
        await _context.SaveChangesAsync();

        return Created("", quest);
    }

    [HttpDelete]
    [Route("deletar/{nome}")]
    public async Task<ActionResult> ExcluirQuest(string nome)
    {
        if(_context is null) return NotFound();
        if(_context.Quest is null) return NotFound();

        var questTemp = await _context.Quest.FindAsync(nome);

        if(questTemp is null) return NotFound();

        _context.Remove(questTemp);
        await _context.SaveChangesAsync();

        return Ok(questTemp);
    }

    [HttpPatch]
    [Route("atualizar/{nome}")]
    public async Task<ActionResult> AtualizarQuest(string nome, [FromForm] string raridade = null, [FromForm] int nivel = -1, [FromForm] string recompensa = null, [FromForm] string objetivo = null)
    {
        if(_context is null) return NotFound();
        if(_context.Quest is null) return NotFound();

        var questTemp = await _context.Quest.FindAsync(nome);

        if(questTemp is null) return NotFound();

        if(raridade is not null) questTemp.Raridade = raridade;
        if(nivel >= 0) questTemp.MinimoNivel = nivel;
        if(recompensa is not null) questTemp.Recompensa = recompensa;
        if(objetivo is not null) questTemp.Objetivo = objetivo;

        await _context.SaveChangesAsync();

        return Ok(questTemp);
    }
}
