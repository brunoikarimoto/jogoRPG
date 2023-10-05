using System.ComponentModel.DataAnnotations;

namespace API_JogoRPG.Models;

public class Player
{
    [Key]
    public string Nome {get; set;}
    public string Classe {get; set;}
    public int Nivel {get; set;}
    public int? Forca {get; set;}
    public int? Velocidade {get; set;}
    public int? Inteligencia {get; set;}
    public int? Resistencia {get; set;}
    public int? Vida {get; set;}
    public int? qntBoss {get; set;}
}