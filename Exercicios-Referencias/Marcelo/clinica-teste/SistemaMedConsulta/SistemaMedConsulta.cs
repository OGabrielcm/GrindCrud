using clinica_teste.Enums;
using MedConsulta.Enums;
using MedConsulta.Models;

namespace MedConsulta.SistemaMedConsulta;

public class SistemaMedConsulta
{
    private readonly List<Medico> _medicos = [];
    private readonly List<Paciente> _pacientes = [];
    private readonly List<Consulta> _consultas = [];
    private readonly List<Agendamento> _agendamentos = [];
    private readonly List<string> _erros = [];

    public Medico BuscarMedicoPorId(Guid id) => _medicos.FirstOrDefault(m => m.Id == id);
    public Medico BuscarMedicoPorCrm(string crm) => _medicos.FirstOrDefault(m => m.Crm == crm?.Trim().ToUpper());
    public Paciente BuscarPacientePorId(Guid id) => _pacientes.FirstOrDefault(p => p.Id == id);
    public Paciente BuscarPacientePorCpf(string cpf) => _pacientes.FirstOrDefault(p => p.Cpf == cpf?.Trim());
    public Consulta BuscarConsultaPorId(Guid id) => _consultas.FirstOrDefault(c => c.Id == id);
    public Consulta BuscarConsultaPorCodigo(string codigo) => _consultas.FirstOrDefault(c => c.Codigo == codigo?.Trim().ToUpper());
    public Agendamento BuscarAgendamentoPorId(Guid id) => _agendamentos.FirstOrDefault(a => a.Id == id);

    public string CadastrarMedico(string nome, string crm, string especialidade)
    {
        _erros.Clear();

        if (!string.IsNullOrWhiteSpace(crm))
            crm = crm.Trim().ToUpper();

        if (string.IsNullOrWhiteSpace(nome) || nome.Trim().Length < 2)
            _erros.Add("Erro: nome inválido (mín. 2 caracteres)");

        if (string.IsNullOrWhiteSpace(crm) || crm.Length < 4 || crm.Length > 20)
            _erros.Add("Erro: CRM inválido (4 a 20 caracteres)");

        if (string.IsNullOrWhiteSpace(especialidade) || especialidade.Trim().Length < 3)
            _erros.Add("Erro: especialidade inválida (mín. 3 caracteres)");

        if (!string.IsNullOrWhiteSpace(crm) && _medicos.Any(m => m.Crm == crm))
            _erros.Add("Erro: já existe um médico com esse CRM");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        var medico = new Medico(nome, crm, especialidade);

        if (medico == null)
            _erros.Add("Erro: médico inválido");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        _medicos.Add(medico);
        return "Sucesso: médico cadastrado";
    }

    public string ListarMedicos()
    {
        if (_medicos.Count == 0)
            return "Erro: lista vazia";

        return string.Join("\n", _medicos);
    }

    public string EditarMedico(Guid id, string nome, string especialidade)
    {
        _erros.Clear();

        var medico = BuscarMedicoPorId(id);

        if (medico == null)
            _erros.Add("Erro: médico não encontrado");

        if (!string.IsNullOrWhiteSpace(nome) && nome.Trim().Length < 2)
            _erros.Add("Erro: nome inválido (mín. 2 caracteres)");

        if (!string.IsNullOrWhiteSpace(especialidade) && especialidade.Trim().Length < 3)
            _erros.Add("Erro: especialidade inválida (mín. 3 caracteres)");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        medico.Editar(
            string.IsNullOrWhiteSpace(nome) ? null : nome,
            string.IsNullOrWhiteSpace(especialidade) ? null : especialidade);

        return "Sucesso: médico editado";
    }

    public string ExcluirMedico(Guid id)
    {
        _erros.Clear();

        var medico = BuscarMedicoPorId(id);

        if (medico == null)
            _erros.Add("Erro: médico não encontrado");

        if (_consultas.Any(c => c.MedicoId == id))
            _erros.Add("Erro: médico possui consultas vinculadas");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        _medicos.Remove(medico);
        return "Sucesso: médico excluído";
    }

    public string CadastrarPaciente(string nomeCompleto, DateTime dataNascimento, string cpf, string carteirinha)
    {
        _erros.Clear();

        if (!string.IsNullOrWhiteSpace(cpf))
            cpf = cpf.Trim();

        if (!string.IsNullOrWhiteSpace(carteirinha))
            carteirinha = carteirinha.Trim().ToUpper();

        if (string.IsNullOrWhiteSpace(nomeCompleto) || nomeCompleto.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Length < 2)
            _erros.Add("Erro: nome completo inválido (informe nome e sobrenome)");

        if (dataNascimento > DateTime.Today)
            _erros.Add("Erro: data de nascimento não pode ser futura");

        if (dataNascimento < DateTime.Today.AddYears(-120))
            _erros.Add("Erro: data de nascimento inválida (máx. 120 anos)");

        if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || !cpf.All(char.IsDigit))
            _erros.Add("Erro: CPF inválido (11 dígitos numéricos)");

        if (string.IsNullOrWhiteSpace(carteirinha) || carteirinha.Length < 4)
            _erros.Add("Erro: carteirinha inválida (mín. 4 caracteres)");

        if (!string.IsNullOrWhiteSpace(cpf) && cpf.Length == 11 && _pacientes.Any(p => p.Cpf == cpf))
            _erros.Add("Erro: já existe um paciente com esse CPF");

        if (!string.IsNullOrWhiteSpace(carteirinha) && _pacientes.Any(p => p.Carteirinha == carteirinha))
            _erros.Add("Erro: já existe um paciente com essa carteirinha");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        var paciente = new Paciente(nomeCompleto, dataNascimento, cpf, carteirinha);

        if (paciente == null)
            _erros.Add("Erro: paciente inválido");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        _pacientes.Add(paciente);
        return "Sucesso: paciente cadastrado";
    }

    public string ListarPacientes()
    {
        if (_pacientes.Count == 0)
            return "Erro: lista vazia";

        return string.Join("\n", _pacientes);
    }

    public string EditarPaciente(Guid id, string nomeCompleto, DateTime? dataNascimento, string carteirinha)
    {
        _erros.Clear();

        var paciente = BuscarPacientePorId(id);

        if (paciente == null)
            _erros.Add("Erro: paciente não encontrado");

        if (!string.IsNullOrWhiteSpace(carteirinha))
            carteirinha = carteirinha.Trim().ToUpper();

        if (!string.IsNullOrWhiteSpace(nomeCompleto) && nomeCompleto.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Length < 2)
            _erros.Add("Erro: nome completo inválido (informe nome e sobrenome)");

        if (dataNascimento != null)
        {
            if (dataNascimento.Value > DateTime.Today)
                _erros.Add("Erro: data de nascimento não pode ser futura");

            if (dataNascimento.Value < DateTime.Today.AddYears(-120))
                _erros.Add("Erro: data de nascimento inválida (máx. 120 anos)");
        }

        if (!string.IsNullOrWhiteSpace(carteirinha) && carteirinha.Length < 4)
            _erros.Add("Erro: carteirinha inválida (mín. 4 caracteres)");

        if (carteirinha != null && _pacientes.Any(p => p.Carteirinha == carteirinha && p.Id != id))
            _erros.Add("Erro: já existe um paciente com essa carteirinha");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        paciente.Editar(
            string.IsNullOrWhiteSpace(nomeCompleto) ? null : nomeCompleto,
            dataNascimento,
            string.IsNullOrWhiteSpace(carteirinha) ? null : carteirinha);

        return "Sucesso: paciente editado";
    }

    public string ExcluirPaciente(Guid id)
    {
        _erros.Clear();

        var paciente = BuscarPacientePorId(id);

        if (paciente == null)
            _erros.Add("Erro: paciente não encontrado");

        if (_agendamentos.Any(a => a.PacienteId == id))
            _erros.Add("Erro: paciente possui agendamentos vinculados");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        _pacientes.Remove(paciente);
        return "Sucesso: paciente excluído";
    }

    public string CadastrarConsulta(string codigo, string local, DateTime dataHoraPrevista, int duracaoMinutos, Guid medicoId)
    {
        _erros.Clear();

        if (!string.IsNullOrWhiteSpace(codigo))
            codigo = codigo.Trim().ToUpper();

        if (string.IsNullOrWhiteSpace(codigo) || codigo.Length < 3)
            _erros.Add("Erro: código inválido (mín. 3 caracteres)");

        if (string.IsNullOrWhiteSpace(local) || local.Trim().Length < 2)
            _erros.Add("Erro: local inválido (mín. 2 caracteres)");

        if (dataHoraPrevista < DateTime.Now)
            _erros.Add("Erro: data/hora prevista deve ser futura");

        if (duracaoMinutos < 10 || duracaoMinutos > 480)
            _erros.Add("Erro: duração inválida (10 a 480 minutos)");

        if (BuscarMedicoPorId(medicoId) == null)
            _erros.Add("Erro: médico não encontrado");

        if (!string.IsNullOrWhiteSpace(codigo) && _consultas.Any(c => c.Codigo == codigo))
            _erros.Add("Erro: já existe uma consulta com esse código");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        var consulta = new Consulta(codigo, local, dataHoraPrevista, duracaoMinutos, medicoId);

        if (consulta == null)
            _erros.Add("Erro: consulta inválida");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        _consultas.Add(consulta);
        return "Sucesso: consulta cadastrada";
    }

    public string ListarConsultas()
    {
        if (_consultas.Count == 0)
            return "Erro: lista vazia";

        return string.Join("\n", _consultas);
    }

    public string EditarConsulta(Guid id, string local, DateTime? dataHoraPrevista, int? duracaoMinutos)
    {
        _erros.Clear();

        var consulta = BuscarConsultaPorId(id);

        if (consulta == null)
            _erros.Add("Erro: consulta não encontrada");

        if (!string.IsNullOrWhiteSpace(local) && local.Trim().Length < 2)
            _erros.Add("Erro: local inválido (mín. 2 caracteres)");

        if (dataHoraPrevista != null && dataHoraPrevista.Value < DateTime.Now)
            _erros.Add("Erro: data/hora prevista deve ser futura");

        if (duracaoMinutos != null && (duracaoMinutos.Value < 10 || duracaoMinutos.Value > 480))
            _erros.Add("Erro: duração inválida (10 a 480 minutos)");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        consulta.Editar(
            string.IsNullOrWhiteSpace(local) ? null : local,
            dataHoraPrevista,
            duracaoMinutos);

        return "Sucesso: consulta editada";
    }

    public string ExcluirConsulta(Guid id)
    {
        _erros.Clear();

        var consulta = BuscarConsultaPorId(id);

        if (consulta == null)
            _erros.Add("Erro: consulta não encontrada");

        if (_agendamentos.Any(a => a.ConsultaId == id))
            _erros.Add("Erro: consulta possui agendamentos vinculados");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        _consultas.Remove(consulta);
        return "Sucesso: consulta excluída";
    }

    public string AlterarStatusConsulta(string codigo, StatusConsultaEnum novoStatus)
    {
        _erros.Clear();

        var consulta = BuscarConsultaPorCodigo(codigo);

        if (consulta == null)
            _erros.Add("Erro: consulta não encontrada");
        else
        {
            if (consulta.Status == StatusConsultaEnum.Realizada || consulta.Status == StatusConsultaEnum.Cancelada)
                _erros.Add("Erro: consulta finalizada não pode mudar de status");

            if (consulta.Status == novoStatus)
                _erros.Add("Erro: consulta já está nesse status");
        }

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        consulta.AlterarStatus(novoStatus);
        return $"Sucesso: status alterado para {consulta.Status}";
    }

    public string CadastrarAgendamento(Guid pacienteId, Guid consultaId, TipoAtendimentoEnum tipoAtendimento, decimal valorCobrado)
    {
        _erros.Clear();

        if (BuscarPacientePorId(pacienteId) == null)
            _erros.Add("Erro: paciente não encontrado");

        if (BuscarConsultaPorId(consultaId) == null)
            _erros.Add("Erro: consulta não encontrada");

        if (valorCobrado <= 0)
            _erros.Add("Erro: valor cobrado deve ser maior que zero");

        if (_agendamentos.Any(a => a.PacienteId == pacienteId && a.ConsultaId == consultaId))
            _erros.Add("Erro: paciente já possui agendamento nesta consulta");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        var agendamento = new Agendamento(pacienteId, consultaId, tipoAtendimento, valorCobrado);

        if (agendamento == null)
            _erros.Add("Erro: agendamento inválido");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        _agendamentos.Add(agendamento);
        return "Sucesso: agendamento registrado";
    }

    public string ListarAgendamentos()
    {
        if (_agendamentos.Count == 0)
            return "Erro: lista vazia";

        return string.Join("\n", _agendamentos);
    }

    public string EditarAgendamento(Guid id, TipoAtendimentoEnum? tipoAtendimento, decimal? valorCobrado)
    {
        _erros.Clear();

        var agendamento = BuscarAgendamentoPorId(id);

        if (agendamento == null)
            _erros.Add("Erro: agendamento não encontrado");

        if (valorCobrado != null && valorCobrado.Value <= 0)
            _erros.Add("Erro: valor cobrado deve ser maior que zero");

        if (_erros.Count > 0)
            return string.Join("\n", _erros);

        agendamento.Editar(
            tipoAtendimento,
            valorCobrado);

        return "Sucesso: agendamento editado";
    }

    public string ExcluirAgendamento(Guid id)
    {
        var agendamento = BuscarAgendamentoPorId(id);

        if (agendamento == null)
            return "Erro: agendamento não encontrado";

        _agendamentos.Remove(agendamento);
        return "Sucesso: agendamento excluído";
    }

    public string BuscarPacientesPorNome(string termo)
    {
        var resultado = _pacientes
            .Where(p => p.NomeCompleto.Contains(termo, StringComparison.OrdinalIgnoreCase))
            .ToList();

        if (resultado.Count == 0)
            return "Erro: nenhum paciente encontrado";

        return string.Join("\n", resultado);
    }

    public string RankingAgendamentosPorConsulta(string codigoConsulta)
    {
        var consulta = BuscarConsultaPorCodigo(codigoConsulta);

        if (consulta == null)
            return "Erro: consulta não encontrada";

        var agendamentosDaConsulta = _agendamentos.Where(a => a.ConsultaId == consulta.Id).ToList();

        if (agendamentosDaConsulta.Count == 0)
            return "Erro: nenhum agendamento registrado para esta consulta";

        var grupos = agendamentosDaConsulta
            .GroupBy(a => a.TipoAtendimento)
            .Select(g => new { Tipo = g.Key, Quantidade = g.Count() })
            .OrderByDescending(x => x.Quantidade)
            .ToList();

        var linhas = grupos.Select(g => $"  {g.Tipo}: {g.Quantidade} paciente(s)");

        return $"Consulta: {consulta.Codigo} | Total: {agendamentosDaConsulta.Count} paciente(s)\n" + string.Join("\n", linhas);
    }

    public string HistoricoConsultasPorPaciente(string cpf)
    {
        var paciente = BuscarPacientePorCpf(cpf);

        if (paciente == null)
            return "Erro: paciente não encontrado";

        var historico = _agendamentos
            .Where(a => a.PacienteId == paciente.Id)
            .Select(a => new { Agendamento = a, Consulta = BuscarConsultaPorId(a.ConsultaId) })
            .Where(x => x.Consulta != null)
            .OrderBy(x => x.Consulta.DataHoraPrevista)
            .ToList();

        if (historico.Count == 0)
            return "Erro: nenhuma consulta encontrada para este paciente";

        var linhas = historico.Select(x =>
        {
            var medico = BuscarMedicoPorId(x.Consulta.MedicoId);
            string nomeMedico = medico != null ? medico.Nome : "—";
            return $"Consulta: {x.Consulta.Codigo} | Médico: {nomeMedico} | Prevista: {x.Consulta.DataHoraPrevista:dd/MM/yyyy HH:mm} | Tipo: {x.Agendamento.TipoAtendimento} | Status: {x.Consulta.Status}";
        });

        return string.Join("\n", linhas);
    }

    public string FiltrarPacientesConsultaPorTipo(string codigoConsulta, TipoAtendimentoEnum tipoAtendimento)
    {
        var consulta = BuscarConsultaPorCodigo(codigoConsulta);

        if (consulta == null)
            return "Erro: consulta não encontrada";

        var resultado = _agendamentos
            .Where(a => a.ConsultaId == consulta.Id && a.TipoAtendimento == tipoAtendimento)
            .Select(a => BuscarPacientePorId(a.PacienteId))
            .Where(p => p != null)
            .OrderBy(p => p.NomeCompleto)
            .ToList();

        if (resultado.Count == 0)
            return "Erro: nenhum paciente encontrado para esse tipo nesta consulta";

        return string.Join("\n", resultado);
    }
}
