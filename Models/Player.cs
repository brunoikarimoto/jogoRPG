using System.ComponentModel.DataAnnotations;

namespace API_JogoRPG.Models;

public class Player
{
    [Key]
    public string Nome {get; set;}
    public string Classe {get; set;}
    public int Nivel {get; set;} = 0;
    public int Forca {get; set;} = 0;
    public int Velocidade {get; set;} = 0;
    public int Inteligencia {get; set;} = 0;
    public int Resistencia {get; set;} = 0;
    public int Vida {get; set;} = 0;
    public int qntBoss {get; set;} = 0;
}