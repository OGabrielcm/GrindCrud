namespace Atividade_MedConsulta.Models;

public class Medico
{

    public Medico(string crm, string nome, string especialidade)
    {
        Crm = crm;
        Nome = nome;
        Especialidade = especialidade;
    }

    public string Crm { get; private set; } 
    public string Nome { get; private set; }
    public string Especialidade { get; private set; }
    
    public void Atualizar(string nome, string especialidade)
    {
        Nome = nome;
        Especialidade = especialidade;
    }

    public override string ToString()
    {
        return $"CRM: {Crm} | Nome: {Nome} | Especialidade: {Especialidade}";
    }
}

