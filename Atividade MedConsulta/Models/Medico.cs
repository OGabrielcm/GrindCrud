namespace Atividade_MedConsulta.Models;

public class Medico
{

    public Medico(string crm, string nome, string especialidade)
    {
        Crm = crm;
        Nome = nome;
        Especialidade = especialidade;
    }

    public string Crm { get; private set; } // como "CRM12345"
    public string Nome { get; private set; }
    public string Especialidade { get; private set; }
}

