namespace MedConsulta.Models;

public class Medico
{
    public Medico(string crm, string nome, string especialidade)
    {
        Crm = crm;
        Nome = nome;
        Especialidade = especialidade;
    }

    public string Crm { get; }
    public string Nome { get; private set; }
    public string Especialidade { get; private set; }

    public void AlterarNome(string nome) => Nome = nome;
    public void AlterarEspecialidade(string especialidade) => Especialidade = especialidade;

    public override string ToString()
    {
        return $"Médico: {Nome} | CRM: {Crm} | Especialidade: {Especialidade}";
    }
}
