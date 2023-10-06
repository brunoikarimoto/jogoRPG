using Microsoft.AspNetCore.Mvc;
using API_JogoRPG.Models;
using API_JogoRPG.Data;
using Microsoft.EntityFrameworkCore;

namespace API_JogoRPG.Controllers;

[ApiController]
[Route("[controller]")]
public class BossController : ControllerBase{

    private JogoRPGDbContext _context;

    public BossController(JogoRPGDbContext context)
    {
        _context = context;
    }


    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Boss>>> ListarBoss()
    {
        if(_context is null) return NotFound();
        if(_context.Boss is null) return NotFound();

        return await _context.Boss.ToListAsync();
    }

    [HttpPost]
    [Route("novoBoss")]

    public async Task<ActionResult> NovoBoss(Boss boss)
    {
        if(_context is null) return NotFound();
        if(_context.Boss is null) return NotFound();

        await _context.AddAsync(boss);
        await _context.SaveChangesAsync();

        return Created("", boss);
    }

    [HttpDelete]
    [Route("deletar/{nome}")]
    public async Task<ActionResult> ExcluirBoss(string nome)
    {
        if(_context is null) return NotFound();
        if(_context.Boss is null) return NotFound();

        var bossTemp = await _context.Boss.FindAsync(nome);

        if(bossTemp is null) return NotFound();

        _context.Remove(bossTemp);
        await _context.SaveChangesAsync();

        return Ok(bossTemp);
    }




    
    [HttpPatch]
    [Route("atualizar/{nome}")]
    public async Task<ActionResult> AtualizarBoss(string nome, [FromForm] string dificuldade = null, [FromForm] string recompensa = null, [FromForm] int vida = 0, [FromForm] int nivel = 0)
    {
        if(_context is null) return NotFound();
        if(_context.Boss is null) return NotFound();

        var bossTemp = await _context.Boss.FindAsync(nome);

        if(bossTemp is null) return NotFound();


        if(dificuldade is not null) bossTemp.Dificuldade = dificuldade;
        if(recompensa is not null) bossTemp.Recompensa = recompensa;
        if(vida >= 0) bossTemp.Vida = vida;
        if(nivel >= 0) bossTemp.Nivel = nivel;

        
    

        await _context.SaveChangesAsync();

        return Ok(bossTemp);
    }













}


