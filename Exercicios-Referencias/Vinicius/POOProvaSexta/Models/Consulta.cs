using ProvaSexta.Enums;

namespace ProvaSexta.Models;

public class Consulta
{
    public Consulta(Medico medico, string codigo, string localAtendimento, DateTime dataHora, int duracaoEstimadaMinutos)
    {
        Id = Guid.NewGuid();
        Medico = medico;
        Codigo = codigo;
        LocalAtendimento = localAtendimento;
        DataHora = dataHora;
        DuracaoEstimadaMinutos = duracaoEstimadaMinutos;
        Status = ConsultaStatus.Pendente;
    }

    public Guid Id { get; }
    public Medico Medico { get; }
    public string Codigo { get; private set; }
    public string LocalAtendimento { get; private set; }
    public DateTime DataHora { get; private set; }
    public int DuracaoEstimadaMinutos { get; private set; }
    public ConsultaStatus Status { get; private set; }

    public void AtualizarCodigo(string novoCodigo)
    {
        if (!string.IsNullOrWhiteSpace(novoCodigo))
            Codigo = novoCodigo;
    }

    public void AtualizarLocal(string novoLocal)
    {
        if (!string.IsNullOrWhiteSpace(novoLocal))
            LocalAtendimento = novoLocal;
    }

    public void AtualizarDataHora(DateTime novaDataHora)
    {
        DataHora = novaDataHora;
    }

    public void AtualizarDuracao(int novaDuracao)
    {
        if (novaDuracao > 0)
            DuracaoEstimadaMinutos = novaDuracao;
    }

    public void AtualizarStatus(ConsultaStatus novoStatus)
    {
        Status = novoStatus;
    }
}
