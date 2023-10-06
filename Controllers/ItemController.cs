using Microsoft.AspNetCore.Mvc;
using API_JogoRPG.Models;
using API_JogoRPG.Data;
using Microsoft.EntityFrameworkCore;

namespace API_JogoRPG.Controllers;

[ApiController]
[Route("[controller]")]
public class ItemController : ControllerBase
{
    private JogoRPGDbContext _context;

    public ItemController(JogoRPGDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    [Route("listar")]
    public async Task<ActionResult<IEnumerable<Item>>> ListarItem()
    {
        if(_context is null) return NotFound();
        if(_context.Item is null) return NotFound();

        return await _context.Item.ToListAsync();
    }

    [HttpPost]
    [Route("novoItem")]
    public async Task<ActionResult> NovoItem(Item item)
    {
        if(_context is null) return NotFound();
        if(_context.Item is null) return NotFound();

        await _context.AddAsync(item);
        await _context.SaveChangesAsync();

        return Created("", item);
    }

    [HttpDelete]
    [Route("deletar/{nome}")]
    public async Task<ActionResult> ExcluirItem(string nome)
    {
        if(_context is null) return NotFound();
        if(_context.Item is null) return NotFound();

        var itemTemp = await _context.Item.FindAsync(nome);

        if(itemtTemp is null) return NotFound();

        _context.Remove(itemTemp);
        await _context.SaveChangesAsync();

        return Ok(itemTemp);
    }

    [HttpPatch]
    [Route("atualizar/{nome}")]
    public async Task<ActionResult> AtualizarItem(string nome, [FromForm] string raridade = null, [FromForm] int quantidade = -1, [FromForm] string tipo = null, [FromForm])
    {
        if(_context is null) return NotFound();
        if(_context.Item is null) return NotFound();

        var itemTemp = await _context.Item.FindAsync(nome);

        if(itemTemp is null) return NotFound();

        if(raridade is not null) itemTemp.Raridade = raridade;
        if(quantidade >= 0) itemTemp.MinimoQuantidade = quantidade;
        if(tipo is not null) itemTemp.Tipo = tipo;

        await _context.SaveChangesAsync();

        return Ok(itemTemp);
    }
}
