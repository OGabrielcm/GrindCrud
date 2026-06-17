namespace MedConsulta.Models;

public class Medico(string crm, string nome, string especialidade)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string Crm { get; private set; } = crm;
    public string Nome { get; private set; } = nome;
    public string Especialidade { get; private set; } = especialidade;

    public void AtulizarDados(string nome, string especialidade)
    {
        Nome = nome;
        Especialidade = especialidade;
    }

    public void AtulizarCrm(string crm) => Crm = crm;

    public override string ToString() => $"Id: {Id} | Médico: {Nome} | CRM: {Crm} | Especialidade: {Especialidade}";
}
