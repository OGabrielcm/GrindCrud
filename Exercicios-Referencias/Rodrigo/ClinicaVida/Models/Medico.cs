namespace ClinicaVida.Models;

public class Medico
{
    public Medico(string nome, string especialidade)
    {
        Id = Guid.NewGuid();
        Nome = nome;
        CRM = "CRM" + _contador.ToString("D6");
        Especialidade = especialidade;
        _contador++;
    }
    public Guid Id { get; }
    private static int _contador = 1;
    public string Nome { get; private set; }
    public string CRM { get; private set; }
    public string Especialidade { get; private set; }

    public void AlterarDadosMedico(string nome, string especialidade)
    {
        if(nome != null)
            Nome = nome;

        if(especialidade != null)
            Especialidade = especialidade;
    }
    public override string ToString() =>
        $"Médico: {Nome}\n" +
        $"CRM: {CRM}\n" +
        $"Especialidade: {Especialidade}";
}
