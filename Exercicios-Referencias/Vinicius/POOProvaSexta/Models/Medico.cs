namespace ProvaSexta.Models;

public class Medico
{
    public Medico(string numeroRegistro, string nome, string especialidadeMedico)
    {
        Id = Guid.NewGuid();
        NumeroRegistro = numeroRegistro;
        Nome = nome;
        EspecialidadeMedico = especialidadeMedico;
    }

    public Guid Id { get; }
    public string NumeroRegistro { get; private set; }
    public string Nome { get; private set; }
    public string EspecialidadeMedico { get; private set; }

    public void AtualizarNumeroRegistro(string novoNumeroRegistro)
    {
        NumeroRegistro = novoNumeroRegistro;
    }

    public void AtualizarNome(string novoNome)
    {
        Nome = novoNome;
    }

    public void AtualizarEspecialidade(string novaEspecialidade)
    {
        EspecialidadeMedico = novaEspecialidade;
    }
}
