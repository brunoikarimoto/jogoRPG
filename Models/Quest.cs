using System.ComponentModel.DataAnnotations;

namespace API_JogoRPG.Models;

public class Quest
{
    [Key]
    public string Nome {get; set;}
    public string Raridade {get; set;}
    public int MinimoNivel {get; set;}
    public string Recompensa {get; set;}
    public string Objetivo {get; set;}
}