using clinica_teste.Enums;

namespace MedConsulta.Models;

public class Consulta(string codigo, string local, DateTime dataHoraPrevista, int duracaoMinutos, Guid medicoId)
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Codigo { get; private set; } = codigo;
    public string Local { get; private set; } = local;
    public DateTime DataHoraPrevista { get; private set; } = dataHoraPrevista;
    public int DuracaoMinutos { get; private set; } = duracaoMinutos;
    public Guid MedicoId { get; private set; } = medicoId;
    public StatusConsultaEnum Status { get; private set; } = StatusConsultaEnum.Pendente;

    public void Editar(string local, DateTime? dataHoraPrevista, int? duracaoMinutos)
    {
        if (local != null)
            Local = local;

        if (dataHoraPrevista != null)
            DataHoraPrevista = dataHoraPrevista.Value;

        if (duracaoMinutos != null)
            DuracaoMinutos = duracaoMinutos.Value;
    }

    public void AlterarStatus(StatusConsultaEnum novoStatus)
    {
        Status = novoStatus;
    }

    public override string ToString() => $"Id: {Id} | Código: {Codigo} | Local: {Local} | Prevista: {DataHoraPrevista:dd/MM/yyyy HH:mm} | Duração: {DuracaoMinutos} min | Médico: {MedicoId} | Status: {Status}";
}
