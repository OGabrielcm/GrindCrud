using MedConsulta.Enums;

namespace MedConsulta.Models;

public class Consulta(Medico medico, string codigoUnico, string localAtendimento, DateTime dataHoraPrevista, int duracao, StatusConsultaEnum statusConsulta)
{
    public Guid Id { get; } = Guid.NewGuid();
    public string CodigoUnico { get; private set; } = codigoUnico;
    public Medico Medico { get; private set; } = medico;
    public string LocalAtendimento { get; private set; } = localAtendimento;
    public DateTime DataHoraPrevista { get; private set; } = dataHoraPrevista;
    public int Duracao { get; private set; } = duracao;
    public StatusConsultaEnum StatusConsulta { get; private set; } = statusConsulta;

    public void AlterarCodigoUnico(string codigoUnico) => CodigoUnico = codigoUnico;

    public void AlterarDados(Medico medico, string localAtendimento, DateTime dataHoraPrevista, int duracao, StatusConsultaEnum statusConsulta)
    {
        Medico = medico;
        LocalAtendimento = localAtendimento;
        DataHoraPrevista = dataHoraPrevista;
        Duracao = duracao;
        StatusConsulta = statusConsulta;
    }

    public override string ToString() => $"Id: {Id} | Código Consulta: {CodigoUnico} | Local de Atendimento: {LocalAtendimento} | Data e Hora Previstas: {DataHoraPrevista:g} | Duração: {Duracao} minutos | Status da Consulta: {StatusConsulta} | Médico: {Medico.Nome}";
}
