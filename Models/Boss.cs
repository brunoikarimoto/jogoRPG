using System.ComponentModel.DataAnnotations;

namespace API_JogoRPG;

public class Boss {

    public string Nome {get; set;}

    public string Dificuldade {get; set;}

    public string Recompensa {get; set;}

    public int Vida {get; set;}

    public int Nivel {get; set;}



}