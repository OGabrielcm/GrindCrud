namespace ClinicaVida.Models;

public class Consulta
{
    public Consulta(string local, DateTime dataHora, Medico medico)
    {
        Id = Guid.NewGuid();
        Codigo = "CONS" + _contador.ToString("D5");
        Local = local;
        DataHora = dataHora;
        Medico = medico;
        Status = StatusConsultaEnum.Pendente;
        _contador++;
    }
    public Guid Id { get; }
    private static int _contador = 1;
    public string Codigo { get; }
    public string Local { get; private set; }
    public DateTime DataHora { get; private set; }
    public Medico Medico { get; private set; }
    public StatusConsultaEnum Status { get; private set; }

    public void AlterarDadosConsulta(string local, DateTime dataHora, Medico medico)
    {
        Local = local;
        DataHora = dataHora;
        Medico = medico;
    }

    public void AlterarStatusConsulta(StatusConsultaEnum novoStatus)
    {
        if (Status == novoStatus)
        {
            Console.WriteLine("A consulta já tem esse status");
            return;
        }

        Status = novoStatus;
    }

    public override string ToString() =>
        $"Consulta: {Codigo}\n" +
        $"Local: {Local}\n" +
        $"Data: {DataHora} dd/MM/yyyy 00:00\n" +
        $"Médico: {Medico.Nome} | {Medico.CRM} | {Medico.Especialidade}\n" +
        $"Status: {Status}";
}
