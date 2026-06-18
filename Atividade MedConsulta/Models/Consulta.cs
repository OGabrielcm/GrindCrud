using Atividade_MedConsulta.Enums;
namespace Atividade_MedConsulta.Models;

public class Consulta
{
    public Consulta(string codigoUnico, string localAtendimento, DateTime dataHoraPrevista, int duracaoEstimada, Medico medicoResponsavel)
    {
        CodigoUnico = codigoUnico;
        LocalAtendimento = localAtendimento;
        DataHoraPrevista = dataHoraPrevista;
        DuracaoEstimada = duracaoEstimada;
        MedicoResponsavel = medicoResponsavel;
        StatusConsulta = StatusConsultaEnum.Pendente;
    }
    public string CodigoUnico { get; private set; } // por exemplo, "CONS0512"
    public string LocalAtendimento { get; private set; }
    public DateTime DataHoraPrevista { get; private set; }
    public int DuracaoEstimada { get; private set; } // Em minutos 
    public Medico MedicoResponsavel { get; private set; }
    public StatusConsultaEnum StatusConsulta { get; private set; }

    public void Atualizar( string localAtendimento, DateTime dataHoraPrevista, int duracaoEstimada, Medico medicoResponsavel)
    {
        LocalAtendimento = localAtendimento;
        DataHoraPrevista = dataHoraPrevista;
        DuracaoEstimada = duracaoEstimada;
        MedicoResponsavel = medicoResponsavel;
    }

    public void AlterarStatus(StatusConsultaEnum novoStatus)
    {
        StatusConsulta = novoStatus;
    }

    public override string ToString()
    {
        return $"Codigo: {CodigoUnico} | Local: {LocalAtendimento} | Data: {DataHoraPrevista} | Duracao: {DuracaoEstimada}min | Medico: {MedicoResponsavel.Nome} | Status: {StatusConsulta}";
    }
}
