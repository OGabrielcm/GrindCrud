namespace MedConsulta.Models;

public class Medico(string nome, string crm, string especialidade)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Nome { get; private set; } = nome;
    public string Crm { get; private set; } = crm;
    public string Especialidade { get; private set; } = especialidade;

    public void Editar(string nome, string especialidade)
    {
        if (nome != null)
            Nome = nome;

        if (especialidade != null)
            Especialidade = especialidade;
    }

    public override string ToString() => $"Id: {Id} | Nome: {Nome} | CRM: {Crm} | Especialidade: {Especialidade}";
}
