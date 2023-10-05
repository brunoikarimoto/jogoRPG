using Microsoft.AspNetCore.Mvc;
using API_JogoRPG.Models;
using API_JogoRPG.Data;
using Microsoft.EntityFrameworkCore;

namespace API_JogoRPG.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private JogoRPGDbContext _context;

    public PlayerController(JogoRPGDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Player>>> Listar()
    {
        if(_context is null) return NotFound();
        if(_context.Player is null) return NotFound();

        return await _context.Player.ToListAsync();
    }

    [HttpPost]
    [Route("cadastrar")]
    public async Task<ActionResult> Cadastrar(Player player)
    {
        if(_context is null) return NotFound();
        if(_context.Player is null) return NotFound();

        if(player.Nivel <= 0) player.Nivel = 0;
        if(player.Forca <= 0) player.Forca = 0;
        if(player.Velocidade <= 0) player.Velocidade = 0;
        if(player.Inteligencia <= 0) player.Inteligencia = 0;
        if(player.Resistencia <= 0) player.Resistencia = 0;
        if(player.qntBoss <= 0) player.qntBoss = 0;
        if(player.Vida <= 0) player.Vida = 0;

        await _context.AddAsync(player);
        await _context.SaveChangesAsync();

        return Created("", player);
    }

    [HttpDelete]
    [Route("deletar/{nome}")]
    public async Task<ActionResult> Excluir(string nome)
    {
        if(_context is null) return NotFound();
        if(_context.Player is null) return NotFound();

        var playerTemp = await _context.Player.FindAsync(nome);

        if(playerTemp is null) return NotFound();

        _context.Remove(playerTemp);
        await _context.SaveChangesAsync();

        return Ok(playerTemp);
    }

    [HttpPatch]
    [Route("atualizarAtributos/{nome}")]
    public async Task<ActionResult> AtualizarAtributos(string nome, [FromForm] int nivel = -1, [FromForm] int vida = -1, [FromForm] int forca = -1, [FromForm] int inteligencia = -1, [FromForm] int resistencia = -1, [FromForm] int qntBoss = -1, [FromForm] int velocidade = -1)
    {
        if(_context is null) return NotFound();
        if(_context.Player is null) return NotFound();

        var playerTemp = await _context.Player.FindAsync(nome);

        if(playerTemp is null) return NotFound();

        if(nivel >= 0) playerTemp.Nivel = nivel;
        if(forca >= 0) playerTemp.Forca = forca;
        if(velocidade >= 0) playerTemp.Velocidade = velocidade;
        if(inteligencia >= 0) playerTemp.Inteligencia = inteligencia;
        if(resistencia >= 0) playerTemp.Resistencia = resistencia;
        if(qntBoss >= 0) playerTemp.qntBoss = qntBoss;
        if(vida >= 0) playerTemp.Vida = vida;

        await _context.SaveChangesAsync();

        return Ok(playerTemp);
    }
}
