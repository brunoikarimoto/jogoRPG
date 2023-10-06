using Microsoft.AspNetCore.Mvc;
using API_JogoRPG.Models;
using API_JogoRPG.Data;
using Microsoft.EntityFrameworkCore;

namespace API_JogoRPG.Controllers;

[ApiController]
[Route("[controller]")]
public class RaidController : ControllerBase{

 private JogoRPGDbContext _context;

    public RaidController(JogoRPGDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Raid>>> ListarRaid()
    {
        if(_context is null) return NotFound();
        if(_context.Raid is null) return NotFound();

        return await _context.Raid.ToListAsync();
    }


     [HttpPost]
    [Route("novoRaid")]
    public async Task<ActionResult> NovoRaid(Raid raid)
    {
        if(_context is null) return NotFound();
        if(_context.Raid is null) return NotFound();

        await _context.AddAsync(raid);
        await _context.SaveChangesAsync();

        return Created("", raid);
    }



    [HttpDelete]
    [Route("deletar/{nome}")]
    public async Task<ActionResult> ExcluirRaid(string nome)
    {
        if(_context is null) return NotFound();
        if(_context.Raid is null) return NotFound();

        var raidTemp = await _context.Map.FindAsync(nome);

        if(raidTemp is null) return NotFound();

        _context.Remove(raidTemp);
        await _context.SaveChangesAsync();

        return Ok(raidTemp);
    }





    [HttpPatch]
    [Route("atualizar/{nome}")]
    public async Task<ActionResult> Atualizarraid(string bossnome, [FromForm] int duracao = 0, [FromForm] int qtnplayers = 0  )
    {
        if(_context is null) return NotFound();
        if(_context.Raid is null) return NotFound();

        var raidTemp = await _context.Raid.FindAsync(bossnome);

        if(raidTemp is null) return NotFound();

        if(bossnome is not null) raidTemp.bossNome = bossnome;

        if(duracao >= 0) raidTemp.Duracao = duracao;

        if(qtnplayers >= 0) raidTemp.qtnPlayers = qtnplayers;

       
    

        await _context.SaveChangesAsync();

        return Ok(raidTemp);
    }









}