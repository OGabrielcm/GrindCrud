using MedConsulta.Enums;

namespace MedConsulta.Models;

public class Agendamento(Guid pacienteId, Guid consultaId, TipoAtendimentoEnum tipoAtendimento, decimal valorCobrado)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Guid PacienteId { get; private set; } = pacienteId;
    public Guid ConsultaId { get; private set; } = consultaId;
    public TipoAtendimentoEnum TipoAtendimento { get; private set; } = tipoAtendimento;
    public decimal ValorCobrado { get; private set; } = valorCobrado;
    public DateTime DataConfirmacao { get; init; } = DateTime.Today;

    public void Editar(TipoAtendimentoEnum? tipoAtendimento, decimal? valorCobrado)
    {
        if (tipoAtendimento != null)
            TipoAtendimento = tipoAtendimento.Value;

        if (valorCobrado != null)
            ValorCobrado = valorCobrado.Value;
    }

    public override string ToString() => $"Id: {Id} | Paciente: {PacienteId} | Consulta: {ConsultaId} | Tipo: {TipoAtendimento} | Valor: R$ {ValorCobrado:N2} | Confirmação: {DataConfirmacao:dd/MM/yyyy}";
}
