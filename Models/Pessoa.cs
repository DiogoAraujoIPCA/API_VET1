
public partial class Pessoa
{

    public string Nome { get; set; }
    public string Morada { get; set; }
    public int NumeroTelemovel { get; set; }

    public bool Veterinario { get; set; }

    public List<Animal> Animais { get; set; }


    public Pessoa(string nome, string morada, int numeroTelemovel)
    {
        Nome = nome;
        Morada = morada;
        NumeroTelemovel = numeroTelemovel;
        Animais = new List<Animal>();
    }

}






