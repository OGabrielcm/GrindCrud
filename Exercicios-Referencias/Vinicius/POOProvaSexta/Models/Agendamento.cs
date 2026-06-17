using ProvaSexta.Enums;

namespace ProvaSexta.Models;

public class Agendamento
{
    public Agendamento(Consulta consulta, Paciente paciente, Decimal valorCobrado, DateTime dataConfirmacao, TipoAtendimentoEnum tipoAtendimento)
    {
        Id = Guid.NewGuid();
        Consulta = consulta;
        Paciente = paciente;
        ValorCobrado = valorCobrado;
        DataConfirmacao = dataConfirmacao;
        TipoAtendimento = tipoAtendimento;
    }

    public Guid Id { get; }
    public Consulta Consulta { get; }
    public Paciente Paciente { get; }
    public decimal ValorCobrado { get; private set; }
    public DateTime DataConfirmacao { get; }
    public TipoAtendimentoEnum TipoAtendimento { get; private set; }

    public void AtualizarTipoAtendimento(TipoAtendimentoEnum novoTipo)
    {
        TipoAtendimento = novoTipo;
    }

    public void AtualizarValorCobrado(decimal novoValor)
    {
        if (novoValor >= 0)
            ValorCobrado = novoValor;
    }
}
