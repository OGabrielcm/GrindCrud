using Atividade_MedConsulta.Models;
using Atividade_MedConsulta.Helpers;
using Atividade_MedConsulta.Enums;

List<Medico> medicos = [];
List<Paciente> pacientes = [];
List<Consulta> consultas = [];
List<Agendamento> agendamentos = [];

while (true)
{
    Console.WriteLine($"\n=== MedConsulta ===");
    Console.WriteLine($"1. Medicos");
    Console.WriteLine($"2. Pacientes");
    Console.WriteLine($"3. Consultas");
    Console.WriteLine($"4. Agendamentos");
    Console.WriteLine($"5. Relatorios");
    Console.WriteLine($"0. Sair");
    Console.Write($"Escolha: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            MenuMedicos();
            break;
        case "2":
            MenuPacientes();
            break;
        case "3":
            MenuConsultas();
            break;
        case "4":
            MenuAgendamentos();
            break;
        case "5":
            MenuRelatorios();
            break;
        case "0":
            return;
        default:
            Console.WriteLine("Opcao Invalida.");
            break;
    }
}

// ============================ MENUS ============================

void MenuMedicos()
{
    while (true)
    {
        Console.WriteLine("\n=== Medicos ===");
        Console.WriteLine($"1. Cadastrar");
        Console.WriteLine($"2. Listar");
        Console.WriteLine($"3. Editar");
        Console.WriteLine($"4. Excluir");
        Console.WriteLine($"0. Voltar");
        Console.Write("Escolha: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                CadastrarMedico();
                break;
            case "2":
                ListarMedico();
                break;
            case "3":
                EditarMedico();
                break;
            case "4":
                ExcluirMedico();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Opcao Invalida");
                break;
        }
    }
}

void MenuPacientes()
{
    while (true)
    {
        Console.WriteLine($"\n=== Pacientes ===");
        Console.WriteLine($"1. Cadastrar");
        Console.WriteLine($"2. Listar");
        Console.WriteLine($"3. Editar");
        Console.WriteLine($"4. Excluir");
        Console.WriteLine($"0. Voltar");
        Console.Write("Escolha: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                CadastrarPaciente();
                break;
            case "2":
                ListarPaciente();
                break;
            case "3":
                EditarPaciente();
                break;
            case "4":
                ExcluirPaciente();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Opcao Invalida. Tente novamente");
                break;
        }
    }
}

void MenuConsultas()
{
    while (true)
    {
        Console.WriteLine($"\n=== Consultas ===");
        Console.WriteLine($"1. Cadastrar");
        Console.WriteLine($"2. Listar");
        Console.WriteLine($"3. Editar");
        Console.WriteLine($"4. Excluir");
        Console.WriteLine($"5. Alterar Status");
        Console.WriteLine($"0. Voltar");
        Console.Write($"Escolha: ");
        string? opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                CadastrarConsulta();
                break;
            case "2":
                ListarConsulta();
                break;
            case "3":
                EditarConsulta();
                break;
            case "4":
                ExcluirConsulta();
                break;
            case "5":
                AlterarStatusConsulta();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Opcao Invalida. Tente Novamente");
                break;
        }
    }
}

void MenuAgendamentos()
{
    while (true)
    {
        Console.WriteLine("=== Agendamentos ===");
        Console.WriteLine($"1. Cadastrar");
        Console.WriteLine($"2. Listar");
        Console.WriteLine($"3. Editar");
        Console.WriteLine($"4. Excluir");
        Console.WriteLine($"0. Sair");
        Console.Write($"Escolha: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                CadastrarAgendamento();
                break;
            case "2":
                ListarAgendamento();
                break;
            case "3":
                EditarAgendamento();
                break;
            case "4":
                ExcluirAgendamento();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Opcao Invalida.");
                break;
        }
    }
}

void MenuRelatorios()
{
    while (true)
    {
        Console.WriteLine($"\n=== Relatorios ===");
        Console.WriteLine($"1. Buscar Paciente por Nome");
        Console.WriteLine($"2. Ranking de Agendamentos por Consulta");
        Console.WriteLine($"3. Historico de Consultas por Paciente");
        Console.WriteLine($"4. Filtrar Pacientes por Tipo de Atendimento");
        Console.WriteLine($"0. Voltar");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                BuscarPacientePorNome();
                break;
            case "2":
                RankingAgendamentosConsulta();
                break;
            case "3":
                HistoricoConsultasPaciente();
                break;
            case "4":
                FiltrarPacientesPorTipoAtendimento();
                break;
            case "0":
                return;
            default:
                Console.WriteLine("Opcao Invalida");
                break;
        }
    }
}

// ============================ MEDICOS ============================

void CadastrarMedico()
{
    Console.WriteLine("\n=== Cadastrar Medico ===");

    string crm = Validador.ValidarCrm("CRM: ");
    while (medicos.Any(m => m.Crm == crm))
    {
        Console.WriteLine("[ERRO] CRM ja cadastrado.");
        crm = Validador.ValidarCrm("CRM: ");
    }

    string nome = Validador.ValidarTexto("Nome: ");
    string especialidade = Validador.ValidarTexto("Especialidade: ");

    medicos.Add(new Medico(crm, nome, especialidade));
    Console.WriteLine("[OK] Medico cadastrado com sucesso");
}

void ListarMedico()
{
    if (medicos.Count == 0)
    {
        Console.WriteLine("Nenhum medico registrado encontrado");
        return;
    }

    medicos.ForEach(m => Console.WriteLine(m));
}

void EditarMedico()
{
    if (medicos.Count == 0)
    {
        Console.WriteLine("Nenhum medico cadastrado");
        return;
    }

    ListarMedico();

    string crm = Validador.ValidarCrm("CRM do medico a editar: ");

    Medico? medico = medicos.FirstOrDefault(m => m.Crm == crm);
    if (medico is null)
    {
        Console.WriteLine("[ERRO] Medico nao encontrado.");
        return;
    }

    string nome = Validador.ValidarTexto("Novo Nome: ");
    string especialidade = Validador.ValidarTexto("Nova Especialidade: ");

    medico.Atualizar(nome, especialidade);
    Console.WriteLine("[OK] Medico atualizado com sucesso");
}

void ExcluirMedico()
{
    if (medicos.Count == 0)
    {
        Console.WriteLine("Nenhum medico cadastrado");
        return;
    }

    ListarMedico();

    string crm = Validador.ValidarCrm("CRM do medico a excluir: ");

    Medico? medico = medicos.FirstOrDefault(m => m.Crm == crm);

    if (medico is null)
    {
        Console.WriteLine("[ERRO] Medico nao encontrado");
        return;
    }

    bool temConsultas = consultas.Any(c => c.MedicoResponsavel == medico);
    if (temConsultas)
    {
        Console.WriteLine("[ERRO] Nao e possivel excluir: medico possui consulta");
        return;
    }

    medicos.Remove(medico);
    Console.WriteLine("[OK] Medico removido com sucesso");
}

// ============================ PACIENTES ============================

void CadastrarPaciente()
{
    Console.WriteLine($"\n=== Cadastro de Paciente===");

    string nome = Validador.ValidarTexto("Nome do Paciente: ");

    string cpf = Validador.ValidarCpf("Cpf: ");
    while (pacientes.Any(p => p.Cpf == cpf))
    {
        Console.Write("[ERRO] Cpf ja cadastrado");
        cpf = Validador.ValidarCpf("Cpf: ");
    }

    string numeroPlano = Validador.ValidarTexto("Numero do Plano: ").ToUpper();
    while (pacientes.Any(p => p.NumeroPlano == numeroPlano))
    {
        Console.Write("[ERRO] Numero do Plano ja cadastrado");
        numeroPlano = Validador.ValidarTexto("Numero do Plano: ").ToUpper();
    }

    DateTime dataNascimento = Validador.ValidarDataPassada("Digite a Data de Nascimento(dd/MM/yyyy): ");

    pacientes.Add(new Paciente(nome, cpf, numeroPlano, dataNascimento));
    Console.WriteLine("[OK] Paciente cadastrado com sucesso");
}

void ListarPaciente()
{
    if (pacientes.Count == 0)
    {
        Console.WriteLine("[ERRO] Nenhum paciente cadastrado");
        return;
    }

    pacientes.ForEach(p => Console.WriteLine(p));
}

void EditarPaciente()
{
    if (pacientes.Count == 0)
    {
        Console.WriteLine("[ERRO] Nenhum paciente cadastrado");
        return;
    }

    ListarPaciente();

    string cpf = Validador.ValidarCpf("CPF do paciente a editar: ");

    Paciente? paciente = pacientes.FirstOrDefault(p => p.Cpf == cpf);
    if (paciente is null)
    {
        Console.WriteLine("[ERRO] Paciente nao encontrado");
        return;
    }

    string nome = Validador.ValidarTexto("Novo Nome: ");
    string numeroPlano = Validador.ValidarTexto("Novo Numero do Plano: ").ToUpper();
    while (pacientes.Any(p => p != paciente && p.NumeroPlano == numeroPlano))
    {
        Console.WriteLine("[ERRO] Ja possui um paciente com esse numero de plano");
        numeroPlano = Validador.ValidarTexto("Novo Numero do Plano: ").ToUpper();
    }

    DateTime dataNascimento = Validador.ValidarDataPassada("Nova Data de Nascimento (dd/MM/yyyy): ");

    paciente.Atualizar(nome, numeroPlano, dataNascimento);
    Console.WriteLine("[OK] Paciente atualizado com sucesso");
}

void ExcluirPaciente()
{
    if (pacientes.Count == 0)
    {
        Console.WriteLine("[Erro] Nenhum paciente Cadastrado");
        return;
    }

    ListarPaciente();

    string cpf = Validador.ValidarCpf("CPF do Paciente a excluir: ");

    Paciente? paciente = pacientes.FirstOrDefault(p => p.Cpf == cpf);
    if (paciente is null)
    {
        Console.WriteLine("[ERRO] Paciente nao encontrado");
        return;
    }

    bool temAgendamentos = agendamentos.Any(a => a.Paciente == paciente);
    if (temAgendamentos)
    {
        Console.WriteLine("[ERRO] Paciente tem agendamentos pendentes");
        return;
    }

    pacientes.Remove(paciente);
    Console.WriteLine("[OK] Paciente Removido com sucesso");
}

// ============================ CONSULTAS ============================

void CadastrarConsulta()
{
    Console.WriteLine("\n=== Cadastrar Consulta ===");

    if (medicos.Count == 0)
    {
        Console.WriteLine("[Erro] Cadastre um medico antes de criar uma consulta");
        return;
    }

    string codigo = Validador.ValidarTexto("Codigo da Consulta: ");
    while (consultas.Any(c => c.CodigoUnico == codigo))
    {
        Console.WriteLine("[ERRO] Codigo ja cadastrado");
        codigo = Validador.ValidarTexto("Codigo da Consulta: ");
    }

    ListarMedico();

    string crm = Validador.ValidarCrm("CRM do medico responsavel: ");
    Medico? medico = medicos.FirstOrDefault(m => m.Crm == crm);
    if(medico is null)
    {
        Console.WriteLine("[ERRO] Medico nao encontrado");
        return;
    }

    string local = Validador.ValidarTexto("Local de Atendimento: ");
    DateTime dataHora = Validador.ValidarDataFutura("Data e Hora Prevista (dd/MM/yyyy HH:mm)");
    int duracao = Validador.ValidarInt("Duracao Estimada(minutos): ");

    consultas.Add(new Consulta(codigo,local, dataHora, duracao, medico));
    Console.WriteLine("[OK] Consulta cadastrada com sucesso");
}

void ListarConsulta()
{
    if(consultas.Count == 0)
    {
        Console.WriteLine("[ERRO] Nenhuma consulta cadastrada");
        return;
    }

    consultas.ForEach(c => Console.WriteLine(c));
}

void EditarConsulta()
{
    if (consultas.Count == 0)
    {
        Console.WriteLine("[ERRO] Nenhuma consulta cadastrada");
        return;
    }

    ListarConsulta();
    string codigo = Validador.ValidarTexto("Codigo da consulta a editar: ");
    Consulta? consulta = consultas.FirstOrDefault(c => c.CodigoUnico == codigo);
    if(consulta is null)
    {
        Console.WriteLine("[ERRO] Consulta nao encontrada");
        return;
    }

    string local = Validador.ValidarTexto("Novo local de atendimento: ");
    DateTime dataHora = Validador.ValidarDataFutura("Nova data e hora prevista (dd/MM/yyyy HH:mm)");
    int duracao = Validador.ValidarInt("Nova duracao estimada (minutos): ");

    ListarMedico();
    string crm = Validador.ValidarCrm("CRM do medico responsavel: ");
    Medico? medico = medicos.FirstOrDefault(m => m.Crm == crm);
    if (medico is null)
    {
        Console.WriteLine("[ERRO] Medico nao encontrado");
        return;
    }

    consulta.Atualizar(local, dataHora, duracao, medico);
    Console.WriteLine("[OK] Consulta atualizada com sucesso");
}

void ExcluirConsulta()
{
    if(consultas.Count == 0)
    {
        Console.WriteLine("[ERRO] Nenhuma consulta cadastrada");
        return;
    }

    ListarConsulta();
    string codigo = Validador.ValidarTexto("Codigo da consulta a excluir: ");
    Consulta? consulta = consultas.FirstOrDefault(c => c.CodigoUnico == codigo);
    if(consulta is null)
    {
        Console.WriteLine("[ERRO] Consulta nao encontrada");
        return;
    }

    if(agendamentos.Any(a => a.Consulta == consulta))
    {
        Console.WriteLine("[ERRO] Nao e possivel excluir - ha agendamentos vinculados");
        return;
    }

    consultas.Remove(consulta);
    Console.WriteLine("[OK] Consulta removida com sucesso");
}

void AlterarStatusConsulta()
{
    if(consultas.Count == 0)
    {
        Console.WriteLine("[ERRO] nenhuma consulta cadastrada");
        return;
    }

    ListarConsulta();
    string codigo = Validador.ValidarTexto("Codigo da Consulta: ");
    Consulta? consulta = consultas.FirstOrDefault(c => c.CodigoUnico == codigo);
    if(consulta is null)
    {
        Console.WriteLine("[ERRO] consulta nao encontrada");
        return;
    }

    StatusConsultaEnum novoStatus = Validador.ValidarOpcaoEnum<StatusConsultaEnum>("Novo Status: ");
    consulta.AlterarStatus(novoStatus);
    Console.WriteLine("[OK] Status alterado com sucesso");
}

// ============================ AGENDAMENTOS ============================

void CadastrarAgendamento()
{
    Console.WriteLine("\n=== Cadastro Agendamento===");

    if(pacientes.Count == 0 || consultas.Count == 0)
    {
        Console.WriteLine("[ERRO] Cadastre ao menos um paciente e uma consulta antes");
        return;
    }

    ListarPaciente();
    string cpf = Validador.ValidarCpf("CPF do paciente: ");
    Paciente? paciente = pacientes.FirstOrDefault(p => p.Cpf == cpf);
    if(paciente is null)
    {
        Console.WriteLine("[ERRO] Paciente nao encontrado");
        return;
    }

    ListarConsulta();
    string codigo = Validador.ValidarTexto("Codigo da consulta: ");
    Consulta? consulta = consultas.FirstOrDefault(c => c.CodigoUnico == codigo);
    if(consulta is null)
    {
        Console.WriteLine("[ERRO] Consulta nao encontrada");
        return;
    }

    if(agendamentos.Any(a => a.Paciente == paciente && a.Consulta == consulta))
    {
        Console.WriteLine("[ERRO] Este paciente ja tem agendamento nesta consulta");
        return;
    }

    TipoAtendimentoEnum tipo = Validador.ValidarOpcaoEnum<TipoAtendimentoEnum>("Tipo de atendimento: ");
    decimal valor = Validador.ValidarDecimal("Valor cobrado: R$");
    DateTime dataConfirmada = Validador.ValidarDataPassada("Data de confirmacao (dd/MM/yyyy): ");

    agendamentos.Add(new Agendamento(tipo, valor, dataConfirmada, paciente, consulta));
    Console.WriteLine("[OK] Agendamento cadastrado com sucesso");
}

void ListarAgendamento()
{
    if (agendamentos.Count == 0)
    {
        Console.WriteLine("[ERRO] Nenhum agendamento cadastrado");
        return;
    }

    agendamentos.ForEach(a => Console.WriteLine(a));
}

void EditarAgendamento()
{
    if (agendamentos.Count == 0)
    {
        Console.WriteLine("Nenhum agendamento cadastrado");
        return;
    }

    ListarAgendamento();

    string cpf = Validador.ValidarCpf("CPF do paciente: ");
    string codigo = Validador.ValidarTexto("Codigo da consulta: ");

    Agendamento? agendamento = agendamentos.FirstOrDefault(a => a.Paciente.Cpf == cpf && a.Consulta.CodigoUnico == codigo);
    if (agendamento is null)
    {
        Console.WriteLine("[ERRO] Agendamento nao encontrado");
        return;
    }

    TipoAtendimentoEnum tipo = Validador.ValidarOpcaoEnum<TipoAtendimentoEnum>("Novo tipo de atendimento: ");
    decimal valor = Validador.ValidarDecimal("Novo valor cobrado: R$");

    agendamento.Atualizar(tipo, valor);
    Console.WriteLine("[OK] Agendamento atualizado com sucesso");
}

void ExcluirAgendamento()
{
    if (agendamentos.Count == 0)
    {
        Console.WriteLine("Nenhum agendamento cadastrado");
        return;
    }

    ListarAgendamento();

    string cpf = Validador.ValidarCpf("CPF do paciente: ");
    string codigo = Validador.ValidarTexto("Codigo da consulta: ");

    Agendamento? agendamento = agendamentos.FirstOrDefault(a => a.Paciente.Cpf == cpf && a.Consulta.CodigoUnico == codigo);
    if (agendamento is null)
    {
        Console.WriteLine("[ERRO] Agendamento nao encontrado");
        return;
    }

    agendamentos.Remove(agendamento);
    Console.WriteLine("[OK] Agendamento removido com sucesso");
}

// ============================ RELATORIOS ============================

void BuscarPacientePorNome()
{
    if (pacientes.Count == 0)
    {
        Console.WriteLine("Nenhum paciente cadastrado");
        return;
    }

    string termo = Validador.ValidarTexto("Nome (ou parte) a buscar: ");

    List<Paciente> encontrados = pacientes
        .Where(p => p.NomeCompleto.Contains(termo, StringComparison.OrdinalIgnoreCase))
        .ToList();

    if (encontrados.Count == 0)
    {
        Console.WriteLine("[ERRO] Nenhum paciente encontrado com esse nome");
        return;
    }

    encontrados.ForEach(p => Console.WriteLine(p));
}

void RankingAgendamentosConsulta()
{
    if (consultas.Count == 0)
    {
        Console.WriteLine("Nenhuma consulta cadastrada");
        return;
    }

    ListarConsulta();
    string codigo = Validador.ValidarTexto("Codigo da consulta: ");

    Consulta? consulta = consultas.FirstOrDefault(c => c.CodigoUnico == codigo);
    if (consulta is null)
    {
        Console.WriteLine("[ERRO] Consulta nao encontrada");
        return;
    }

    var ranking = agendamentos
        .Where(a => a.Consulta == consulta)
        .GroupBy(a => a.TipoAtendimento)
        .Select(g => new {
                            Tipo = g.Key, 
                            Total = g.Count() 
                         })
        .OrderByDescending(x => x.Total);

    if (!ranking.Any())
    {
        Console.WriteLine("Nenhum agendamento nesta consulta");
        return;
    }

    Console.WriteLine($"\n=== Ranking da consulta {consulta.CodigoUnico} ===");
    foreach (var item in ranking)
        Console.WriteLine($"{item.Tipo}: {item.Total}");
}

void HistoricoConsultasPaciente()
{
    if (pacientes.Count == 0)
    {
        Console.WriteLine("Nenhum paciente cadastrado");
        return;
    }

    ListarPaciente();
    string cpf = Validador.ValidarCpf("CPF do paciente: ");

    Paciente? paciente = pacientes.FirstOrDefault(p => p.Cpf == cpf);
    if (paciente is null)
    {
        Console.WriteLine("[ERRO] Paciente nao encontrado");
        return;
    }

    List<Agendamento> historico = agendamentos
        .Where(a => a.Paciente == paciente)
        .OrderBy(a => a.Consulta.DataHoraPrevista)
        .ToList();

    if (historico.Count == 0)
    {
        Console.WriteLine("Este paciente nao tem agendamentos");
        return;
    }

    Console.WriteLine($"\n=== Historico de {paciente.NomeCompleto} ===");
    historico.ForEach(a => Console.WriteLine(a.Consulta));
}

void FiltrarPacientesPorTipoAtendimento()
{
    if (consultas.Count == 0)
    {
        Console.WriteLine("Nenhuma consulta cadastrada");
        return;
    }

    ListarConsulta();
    string codigo = Validador.ValidarTexto("Codigo da consulta: ");

    Consulta? consulta = consultas.FirstOrDefault(c => c.CodigoUnico == codigo);
    if (consulta is null)
    {
        Console.WriteLine("[ERRO] Consulta nao encontrada");
        return;
    }

    TipoAtendimentoEnum tipo = Validador.ValidarOpcaoEnum<TipoAtendimentoEnum>("Tipo de atendimento: ");

    List<Paciente> filtrados = agendamentos
        .Where(a => a.Consulta == consulta && a.TipoAtendimento == tipo)
        .Select(a => a.Paciente)
        .OrderBy(p => p.NomeCompleto)
        .ToList();

    if (filtrados.Count == 0)
    {
        Console.WriteLine("Nenhum paciente com esse tipo de atendimento nesta consulta");
        return;
    }

    filtrados.ForEach(p => Console.WriteLine(p));
}
