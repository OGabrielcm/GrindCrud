using ClinicaVida.Models;

List<Medico> medicos = [];
List<Paciente> pacientes = [];
List<Consulta> consultas = [];
List<Agendamento> agendamentos = [];

SeedDados();

void SeedDados()
{
    Medico medico1 = new("João Silva", "Cardiologia");
    Medico medico2 = new("Maria Souza", "Pediatria");
    Medico medico3 = new("Carlos Lima", "Ortopedia");
    Medico medico4 = new("Fernanda Rocha", "Neurologia");
    Medico medico5 = new("Roberto Alves", "Dermatologia");
    Medico medico6 = new("Juliana Martins", "Ginecologia");
    medicos.AddRange([medico1, medico2, medico3, medico4, medico5, medico6]);

    Paciente paciente1 = new("Ana Pereira", new DateTime(1990, 5, 12), "11122233344", "CART001");
    Paciente paciente2 = new("Pedro Santos", new DateTime(1985, 8, 23), "22233344455", "CART002");
    Paciente paciente3 = new("Beatriz Costa", new DateTime(2000, 1, 30), "33344455566", "CART003");
    Paciente paciente4 = new("Lucas Ferreira", new DateTime(1978, 3, 15), "44455566677", "CART004");
    Paciente paciente5 = new("Mariana Oliveira", new DateTime(1995, 11, 20), "55566677788", "CART005");
    Paciente paciente6 = new("Thiago Mendes", new DateTime(1982, 7, 8), "66677788899", "CART006");
    Paciente paciente7 = new("Camila Rodrigues", new DateTime(2003, 2, 14), "77788899900", "CART007");
    Paciente paciente8 = new("Rafael Gomes", new DateTime(1970, 9, 3), "88899900011", "CART008");
    pacientes.AddRange([paciente1, paciente2, paciente3, paciente4, paciente5, paciente6, paciente7, paciente8]);

    Consulta consulta1 = new("Clínica Vida - Sala 1", DateTime.Now.AddDays(1), medico1);
    Consulta consulta2 = new("Clínica Vida - Sala 2", DateTime.Now.AddDays(2), medico2);
    Consulta consulta3 = new("Clínica Vida - Sala 3", DateTime.Now.AddDays(3), medico3);
    Consulta consulta4 = new("Clínica Vida - Sala 4", DateTime.Now.AddDays(5), medico4);
    Consulta consulta5 = new("Hospital Central - Sala A", DateTime.Now.AddDays(7), medico5);
    Consulta consulta6 = new("Hospital Central - Sala B", DateTime.Now.AddDays(10), medico6);
    consultas.AddRange([consulta1, consulta2, consulta3, consulta4, consulta5, consulta6]);

    // consulta3 sem agendamentos — ProcedimentoComplexo fica sem pacientes em todas as consultas
    Agendamento agendamento1 = new(paciente1, consulta1, TipoAtendimentoEnum.Presencial, 150m);
    Agendamento agendamento2 = new(paciente4, consulta1, TipoAtendimentoEnum.Presencial, 150m);
    Agendamento agendamento3 = new(paciente5, consulta1, TipoAtendimentoEnum.Telemedicina, 120m);
    Agendamento agendamento4 = new(paciente2, consulta2, TipoAtendimentoEnum.Telemedicina, 100m);
    Agendamento agendamento5 = new(paciente6, consulta2, TipoAtendimentoEnum.Telemedicina, 100m);
    Agendamento agendamento6 = new(paciente7, consulta2, TipoAtendimentoEnum.Presencial, 130m);
    Agendamento agendamento7 = new(paciente3, consulta4, TipoAtendimentoEnum.Presencial, 200m);
    Agendamento agendamento8 = new(paciente8, consulta4, TipoAtendimentoEnum.Presencial, 200m);
    Agendamento agendamento9 = new(paciente1, consulta5, TipoAtendimentoEnum.Telemedicina, 90m);
    Agendamento agendamento10 = new(paciente2, consulta6, TipoAtendimentoEnum.Presencial, 180m);
    agendamentos.AddRange([agendamento1, agendamento2, agendamento3, agendamento4, agendamento5,
                           agendamento6, agendamento7, agendamento8, agendamento9, agendamento10]);
}

while (true)
{
    Console.Clear();
    Console.WriteLine("============ MED CONSULTAS ================");
    Console.WriteLine("1 - Menu Médico");
    Console.WriteLine("2 - Menu Paciente");
    Console.WriteLine("3 - Menu Consulta");
    Console.WriteLine("4 - Menu Agendamentos");
    Console.WriteLine("5 - Ranking Agendamentos");
    Console.WriteLine("6 - Histórico paciente");
    Console.WriteLine("7 - Consulta por tipo de atendimento");
    Console.WriteLine("0 - Sair");

    Console.Write("Escolha uma opção: ");
    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            MenuMedico();
            break;

        case "2":
            MenuPaciente();
            break;

        case "3":
            MenuConsulta();
            break;

        case "4":
            MenuAgendamentos();
            break;

        case "5":
            RankingAgendamentos();
            break;

        case "6":
            HistoricoPaciente();
            break;

        case "7":
            ConsultaTipoAtendimento();
            break;

        case "0":
            Console.WriteLine("Saindo...");
            return;

        default:
            Console.WriteLine("Opção inválida! Tente novamente...");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;
    }
}

void MenuMedico()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("============ MENU MÉDICO ================");
        Console.WriteLine("1 - Cadastrar Médico");
        Console.WriteLine("2 - Listar Médicos");
        Console.WriteLine("3 - Editar Médico");
        Console.WriteLine("4 - Excluir Médico");
        Console.WriteLine("0 - Menu principal");

        Console.Write("Escolha uma opção: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                CadastrarMedico();
                break;

            case "2":
                ListarMedicos();
                break;

            case "3":
                EditarMedico();
                break;

            case "4":
                ExcluirMedico();
                break;

            case "0":
                Console.WriteLine("Voltando ao menu principal...");
                return;

            default:
                Console.WriteLine("Opção inválida! Tente novamente...");
                break;
        }

        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}

void CadastrarMedico()
{
    Console.Write("Digite o nome do médico: ");
    string nome = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(nome))
    {
        Console.WriteLine("Nome inválido. Digite apenas nome e sobrenome (ex: João Silva):");
        nome = Console.ReadLine();
    }

    Console.Write("\nDigite a especialidade do médico: ");
    string especialidade = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(especialidade))
    {
        Console.WriteLine("especialidade não pode ser vazia");
        especialidade = Console.ReadLine();
    }

    Medico medico = new Medico(nome, especialidade);
    medicos.Add(medico);
    Console.WriteLine("\nMédico cadastrado com sucesso: ");
    Console.WriteLine($"{medico}");
}

void ListarMedicos()
{
    if (medicos.Count == 0)
    {
        Console.WriteLine("Não existem médicos cadastrados");
        return;
    }

    medicos.ForEach(m => Console.WriteLine(m + "\n"));
}

void EditarMedico()
{
    if (medicos.Count == 0)
    {
        Console.WriteLine("Não existem médicos cadastrados");
        return;
    }

    ListarMedicos();

    Console.WriteLine("\nEscolha o CRM do médico que deseja alterar os dados: ");
    string crm = Console.ReadLine();

    var medicofiltrado = medicos.FirstOrDefault(m => m.CRM == crm);

    if (medicofiltrado == null)
    {
        Console.WriteLine("Médico não encontrado");
        return;
    }

    Console.Write("\nDigite o novo nome do médico ou (Enter) pra manter o nome: ");
    string nome = Console.ReadLine();

    Console.Write("\nDigite a nova especialidade do médico ou (Enter) pra manter: ");
    string especialidade = Console.ReadLine();

    medicofiltrado.AlterarDadosMedico(
        string.IsNullOrWhiteSpace(nome) ? null : nome,
        string.IsNullOrWhiteSpace(especialidade) ? null : especialidade
    );

    Console.WriteLine($"\nDados do médico de CRM {medicofiltrado.CRM} alterados com sucesso!");
}

void ExcluirMedico()
{
    if (medicos.Count == 0)
    {
        Console.WriteLine("Não existem médicos cadastrados");
        return;
    }

    ListarMedicos();

    Console.WriteLine("\nEscolha o CRM do médico que excluir: ");
    string crm = Console.ReadLine();

    var medicofiltrado = medicos.FirstOrDefault(m => m.CRM == crm);

    if (medicofiltrado == null)
    {
        Console.WriteLine("Médico não encontrado");
        return;
    }

    medicos.Remove(medicofiltrado);
    Console.WriteLine($"\nMédico {medicofiltrado.Nome} excluído com sucesso!");
}

void MenuPaciente()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("============ MENU PACIENTE ================");
        Console.WriteLine("1 - Cadastrar Paciente");
        Console.WriteLine("2 - Listar Pacientes");
        Console.WriteLine("3 - Editar Paciente");
        Console.WriteLine("4 - Excluir Paciente");
        Console.WriteLine("0 - Menu principal");

        Console.Write("Escolha uma opção: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                CadastrarPaciente();
                break;

            case "2":
                ListarPacientes();
                break;

            case "3":
                EditarPaciente();
                break;

            case "4":
                ExcluirPaciente();
                break;

            case "0":
                Console.WriteLine("Voltando ao menu principal...");
                return;

            default:
                Console.WriteLine("Opção inválida! Tente novamente...");
                break;
        }

        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}

void CadastrarPaciente()
{
    Console.Write("Digite o nome completo do paciente: ");
    string nomeCompleto = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(nomeCompleto))
    {
        Console.WriteLine("Nome não pode ser vazio. Digite o nome completo:");
        nomeCompleto = Console.ReadLine();
    }

    Console.Write("\nDigite a data de nascimento (dd/MM/yyyy): ");
    DateTime dataNascimento;
    while (!DateTime.TryParse(Console.ReadLine(), out dataNascimento) || dataNascimento > DateTime.Now)
        Console.WriteLine("Data de nascimento inválida");

    Console.Write("\nDigite o CPF do paciente (somente números): ");
    string cpf = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11 || pacientes.Any(p => p.CPF == cpf))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(cpf)
            ? "CPF não pode ser vazio"
            : cpf.Length != 11
            ? "CPF deve conter 11 dígitos"
            : "CPF já existe");
        cpf = Console.ReadLine();
    }

    Console.Write("\nDigite o número da carteirinha do plano de saúde: ");
    string carteirinha = Console.ReadLine();
    while (string.IsNullOrWhiteSpace(carteirinha) || pacientes.Any(p => p.NumeroCarteirinha == carteirinha))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(carteirinha)
            ? "Número da carteirinha não pode ser vazio"
            : "Número da carteirinha já existe");

        carteirinha = Console.ReadLine();
    }

    Paciente paciente = new(nomeCompleto, dataNascimento, cpf, carteirinha);
    pacientes.Add(paciente);
    Console.WriteLine("\nPaciente cadastrado com sucesso:");
    Console.WriteLine(paciente);
}

void ListarPacientes()
{
    if (pacientes.Count == 0)
    {
        Console.WriteLine("Não existem pacientes cadastrados");
        return;
    }

    pacientes.ForEach(p => Console.WriteLine(p + "\n"));
}

void EditarPaciente()
{
    if (pacientes.Count == 0)
    {
        Console.WriteLine("Não existem pacientes cadastrados");
        return;
    }

    ListarPacientes();

    Console.Write("\nDigite o CPF do paciente que deseja editar: ");
    string cpf = Console.ReadLine();

    var paciente = pacientes.FirstOrDefault(p => p.CPF == cpf);

    if (paciente == null)
    {
        Console.WriteLine("Paciente não encontrado");
        return;
    }

    Console.Write("\nDigite o novo nome completo ou (Enter) para manter: ");
    string nomeCompleto = Console.ReadLine();

    Console.Write("\nDigite a nova data de nascimento (dd/MM/yyyy) ou (Enter) para manter: ");
    string inputData = Console.ReadLine();

    DateTime? dataParaAlterar = null;

    DateTime dataNascimento;
    if (DateTime.TryParse(inputData, out dataNascimento))
        dataParaAlterar = dataNascimento;

    Console.Write("\nDigite o novo CPF ou (Enter) para manter: ");
    string novoCpf = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(novoCpf) && pacientes.Any(p => p.CPF == novoCpf && p.Id != paciente.Id))
    {
        Console.WriteLine("CPF já cadastrado para outro paciente. CPF não será alterado.");
        novoCpf = null;
    }

    Console.Write("\nDigite o novo número de carteirinha ou (Enter) para manter: ");
    string novaCarteirinha = Console.ReadLine();
    if (!string.IsNullOrWhiteSpace(novaCarteirinha) && pacientes.Any(p => p.NumeroCarteirinha == novaCarteirinha && p.Id != paciente.Id))
    {
        Console.WriteLine("Carteirinha já cadastrada para outro paciente. Carteirinha não será alterada.");
        novaCarteirinha = null;
    }

    paciente.AlterarDadosPaciente(nomeCompleto, dataParaAlterar, novoCpf, novaCarteirinha);

    Console.WriteLine($"\nDados do paciente {paciente.NomeCompleto} alterados com sucesso!");
}

void ExcluirPaciente()
{
    if (pacientes.Count == 0)
    {
        Console.WriteLine("Não existem pacientes cadastrados");
        return;
    }

    ListarPacientes();

    Console.Write("\nDigite o CPF do paciente que deseja excluir: ");
    string cpf = Console.ReadLine();

    var paciente = pacientes.FirstOrDefault(p => p.CPF == cpf);

    if (paciente == null)
    {
        Console.WriteLine("Paciente não encontrado");
        return;
    }

    pacientes.Remove(paciente);
    Console.WriteLine($"\nPaciente {paciente.NomeCompleto} excluído com sucesso!");
}

void MenuConsulta()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("============ MENU CONSULTAS ================");
        Console.WriteLine("1 - Cadastrar Consultas");
        Console.WriteLine("2 - Listar Consultas");
        Console.WriteLine("3 - Editar Consultas");
        Console.WriteLine("4 - Atualizar status das Consultas");
        Console.WriteLine("5 - Excluir Consultas");
        Console.WriteLine("0 - Menu principal");

        Console.Write("Escolha uma opção: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                CadastrarConsulta();
                break;

            case "2":
                ListarConsultas();
                break;

            case "3":
                EditarConsulta();
                break;

            case "4":
                AtualizarStatusConsulta();
                break;

            case "5":
                ExcluirConsulta();
                break;

            case "0":
                Console.WriteLine("Voltando ao menu principal...");
                return;

            default:
                Console.WriteLine("Opção inválida! Tente novamente...");
                break;
        }

        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}

void CadastrarConsulta()
{
    if (medicos.Count == 0)
    {
        Console.WriteLine("Cadastre um médico primeiro");
        return;
    }

    Console.Write("\nDigite o local da consulta: ");
    string local = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(local))
    {
        Console.WriteLine("Local é obrigatório");
        local = Console.ReadLine();
    }

    Console.Write("\nDigite data e hora da consulta (dd/MM/yyyy 00:00): ");
    DateTime dataHoraConsulta;

    while (!DateTime.TryParse(Console.ReadLine(), out dataHoraConsulta) || dataHoraConsulta < DateTime.Now)
    {
        Console.WriteLine(dataHoraConsulta < DateTime.Now
            ? "Data da consulta deve ser pelo menos hoje"
            : "Data e hora inválidas");
    }

    ListarMedicos();

    Console.WriteLine("\nDigite o CRM do médico da consulta: ");
    string crmMedico = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(crmMedico) || !medicos.Any(m => m.CRM == crmMedico))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(crmMedico)
            ? "CRM é obrigatório"
            : "Médico não encontrado. Digite um CRM válido");
        crmMedico = Console.ReadLine();
    }

    Medico medicoConsulta = medicos.FirstOrDefault(m => m.CRM == crmMedico);
    Consulta consulta = new Consulta(local, dataHoraConsulta, medicoConsulta);
    consultas.Add(consulta);
    Console.WriteLine("\nConsulta cadastrada com sucesso!");
    Console.WriteLine($"{consulta}");
}

void ListarConsultas()
{
    if (consultas.Count == 0)
    {
        Console.WriteLine("Não existe consultas cadastradas");
        return;
    }

    consultas.ForEach(m => Console.WriteLine(m + "\n"));
}

void EditarConsulta()
{
    if (consultas.Count == 0)
    {
        Console.WriteLine("Não existe consultas cadastradas");
        return;
    }

    ListarConsultas();

    Console.WriteLine("\nEscolha o código da consulta que deseja alterar:  ");
    string codigoConsulta = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(codigoConsulta) || !consultas.Any(c => c.Codigo == codigoConsulta))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(codigoConsulta)
            ? "Código é obrigatório"
            : "Consulta não encontrada");

        codigoConsulta = Console.ReadLine();
    }

    var consulta = consultas.FirstOrDefault(c => c.Codigo == codigoConsulta);

    Console.Write("\nDigite o local da consulta: ");
    string local = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(local))
    {
        Console.WriteLine("Local é obrigatório");
        local = Console.ReadLine();
    }

    Console.Write("\nDigite data e hora da consulta (dd/MM/yyyy 00:00): ");
    DateTime dataHoraConsulta;

    while (!DateTime.TryParse(Console.ReadLine(), out dataHoraConsulta) || dataHoraConsulta < DateTime.Now)
    {
        Console.WriteLine(dataHoraConsulta < DateTime.Now
            ? "Data da consulta deve ser pelo menos hoje"
            : "Data e hora inválidas");
    }

    ListarMedicos();

    Console.WriteLine("\nDigite o CRM do médico da consulta: ");
    string crmMedico = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(crmMedico) || !medicos.Any(m => m.CRM == crmMedico))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(crmMedico)
            ? "CRM é obrigatório"
            : "Médico não encontrado. Digite um CRM válido");
        crmMedico = Console.ReadLine();
    }

    var novoMedico = medicos.FirstOrDefault(m => m.CRM == crmMedico);

    consulta.AlterarDadosConsulta(local, dataHoraConsulta, novoMedico);
    Console.WriteLine($"\nDados da Consulta {consulta.Codigo} alterados com sucesso!");
}

void AtualizarStatusConsulta()
{
    if (consultas.Count == 0)
    {
        Console.WriteLine("Não existe consultas cadastradas");
        return;
    }

    ListarConsultas();

    Console.WriteLine("\nEscolha o código da consulta que deseja alterar:  ");
    string codigoConsulta = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(codigoConsulta) || !consultas.Any(c => c.Codigo == codigoConsulta))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(codigoConsulta)
            ? "Código é obrigatório"
            : "Consulta não encontrada");

        codigoConsulta = Console.ReadLine();
    }

    var consulta = consultas.FirstOrDefault(c => c.Codigo == codigoConsulta);

    Console.WriteLine("===== STATUS ======");
    Console.WriteLine("1 - Pendente");
    Console.WriteLine("2 - Confirmada");
    Console.WriteLine("3 - Realizada");
    Console.WriteLine("4 - Cancelada");

    Console.Write("Escolha um status para alterar: ");
    int opcaoEscolhida;
    while (!int.TryParse(Console.ReadLine(), out opcaoEscolhida) || opcaoEscolhida < 1 || opcaoEscolhida > 4)
        Console.WriteLine("Digite uma opção entre 1 e 4");

    if (opcaoEscolhida < ((int)consulta.Status))
    {
        Console.WriteLine("Status não pode regredir");
        return;
    }

    if (opcaoEscolhida == ((int)consulta.Status))
    {
        Console.WriteLine("Consulta já possui esse status");
        return;
    }

    var statusAtualizado = (StatusConsultaEnum)opcaoEscolhida;
    consulta.AlterarStatusConsulta(statusAtualizado);
    Console.WriteLine($"\nStatus da Consulta {consulta.Codigo} alterado para {consulta.Status} com sucesso!");
}

void ExcluirConsulta()
{
    if (consultas.Count == 0)
    {
        Console.WriteLine("Não existe consultas cadastradas");
        return;
    }

    ListarConsultas();

    Console.WriteLine("\nEscolha o código da consulta que deseja Excluir: ");
    string codigoConsulta = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(codigoConsulta) || !consultas.Any(c => c.Codigo == codigoConsulta))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(codigoConsulta)
            ? "Código é obrigatório"
            : "Consulta não encontrada");

        codigoConsulta = Console.ReadLine();
    }

    var consulta = consultas.FirstOrDefault(c => c.Codigo == codigoConsulta);

    consultas.Remove(consulta);
    Console.WriteLine($"\nConsulta {consulta.Codigo} excluída com sucesso!");
}

void MenuAgendamentos()
{
    while (true)
    {
        Console.Clear();
        Console.WriteLine("============ MENU AGENDAMENTOS ================");
        Console.WriteLine("1 - Cadastrar Agendamento");
        Console.WriteLine("2 - Listar Agendamentos");
        Console.WriteLine("3 - Editar Agendamento");
        Console.WriteLine("4 - Excluir Agendamento");
        Console.WriteLine("0 - Menu principal");

        Console.Write("Escolha uma opção: ");
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                CadastrarAgendamento();
                break;

            case "2":
                ListarAgendamentos();
                break;

            case "3":
                EditarAgendamento();
                break;

            case "4":
                ExcluirAgendamento();
                break;

            case "0":
                Console.WriteLine("Voltando ao menu principal...");
                return;

            default:
                Console.WriteLine("Opção inválida! Tente novamente...");
                break;
        }

        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
    }
}

void CadastrarAgendamento()
{
    if (pacientes.Count == 0)
    {
        Console.WriteLine("Cadastre primeiro um paciente");
        return;
    }

    if (medicos.Count == 0)
    {
        Console.WriteLine("Cadastre primeiro um médico");
        return;
    }

    ListarPacientes();

    Console.WriteLine("\nDigite o Id do paciente que deseja agendar: ");
    Guid idPaciente;

    while (!Guid.TryParse(Console.ReadLine(), out idPaciente) || !pacientes.Any(p => p.Id == idPaciente))
        Console.WriteLine("Paciente não encontrado");

    var pacienteFiltrado = pacientes.FirstOrDefault(p => p.Id == idPaciente);

    ListarConsultas();

    Console.WriteLine("\nEscolha o código da Consulta: ");
    string codigoConsulta = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(codigoConsulta) || !consultas.Any(c => c.Codigo == codigoConsulta))
    {
        Console.WriteLine("Consulta não encontrada");
        codigoConsulta = Console.ReadLine();
    }

    var consultaFiltrada = consultas.FirstOrDefault(c => c.Codigo == codigoConsulta);

    bool jaAgendado = agendamentos.Any(a => a.Paciente.Id == pacienteFiltrado.Id
                                     && a.Consulta.Codigo == consultaFiltrada.Codigo);
    if (jaAgendado)
    {
        Console.WriteLine("Este paciente já possui agendamento nesta consulta.");
        return;
    }

    Console.WriteLine("===== TIPO ATENDIMENTO =====");
    Console.WriteLine("1 - Presencial");
    Console.WriteLine("2 - TeleMedicina");
    Console.WriteLine("3 - Procedimento Complexo");

    Console.WriteLine("\nEscolha o Tipo de atendimento desejado: ");
    int tipoEscolhido;

    while (!int.TryParse(Console.ReadLine(), out tipoEscolhido) || tipoEscolhido < 1 || tipoEscolhido > 3)
        Console.WriteLine("Digite uma opção entre 1 e 3");

    var tipoAtendimento = (TipoAtendimentoEnum)tipoEscolhido;

    Console.WriteLine("\nDigite o valor da consulta: ");
    decimal valorConsulta;

    while (!decimal.TryParse(Console.ReadLine(), out valorConsulta) || valorConsulta < 0)
        Console.WriteLine("Valor da consulta não pode ser negativo");

    Agendamento agendamento = new Agendamento(pacienteFiltrado, consultaFiltrada, tipoAtendimento, valorConsulta);
    agendamentos.Add(agendamento);
    Console.WriteLine($"\nAgendamento da paciente {pacienteFiltrado.NomeCompleto} realizado com sucesso: ");
    Console.WriteLine($"{agendamento}");
}

void ListarAgendamentos()
{
    if (agendamentos.Count == 0)
    {
        Console.WriteLine("Agenda vazia");
        return;
    }

    agendamentos.ForEach(a => Console.WriteLine(a + "\n"));
}

void EditarAgendamento()
{
    if (agendamentos.Count == 0)
    {
        Console.WriteLine("Agenda vazia");
        return;
    }

    ListarAgendamentos();

    Console.WriteLine("\nDigite o Id do agendamento que deseja alterar: ");
    Guid idAgendamento;

    while (!Guid.TryParse(Console.ReadLine(), out idAgendamento) || !agendamentos.Any(p => p.Id == idAgendamento))
        Console.WriteLine("Agendamento não encontrado");

    var agendamentoFiltrado = agendamentos.FirstOrDefault(a => a.Id == idAgendamento);

    ListarPacientes();

    Console.WriteLine("\nDigite o Id do paciente que deseja alterar: ");
    Guid idPaciente;

    while (!Guid.TryParse(Console.ReadLine(), out idPaciente) || !pacientes.Any(p => p.Id == idPaciente))
        Console.WriteLine("Paciente não encontrado");

    var pacienteFiltrado = pacientes.FirstOrDefault(p => p.Id == idPaciente);

    ListarConsultas();

    Console.WriteLine("\nEscolha o código da Consulta que deseja alterar: ");
    string codigoConsulta = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(codigoConsulta) || !consultas.Any(c => c.Codigo == codigoConsulta))
    {
        Console.WriteLine("Consulta não encontrada");
        codigoConsulta = Console.ReadLine();
    }

    var consultaFiltrada = consultas.FirstOrDefault(c => c.Codigo == codigoConsulta);

    Console.WriteLine("===== TIPO ATENDIMENTO =====");
    Console.WriteLine("1 - Presencial");
    Console.WriteLine("2 - TeleMedicina");
    Console.WriteLine("3 - Procedimento Complexo");

    Console.WriteLine("\nEscolha o Tipo de atendimento desejado: ");
    int tipoEscolhido;

    while (!int.TryParse(Console.ReadLine(), out tipoEscolhido) || tipoEscolhido < 1 || tipoEscolhido > 3)
        Console.WriteLine("Digite uma opção entre 1 e 3");

    var tipoAtendimento = (TipoAtendimentoEnum)tipoEscolhido;

    Console.WriteLine("\nDigite o novo valor da consulta: ");
    decimal valorConsulta;

    while (!decimal.TryParse(Console.ReadLine(), out valorConsulta) || valorConsulta < 0)
        Console.WriteLine("Valor da consulta não pode ser negativo");

    agendamentoFiltrado.AlterarAgendamento(pacienteFiltrado, consultaFiltrada, tipoAtendimento, valorConsulta);
    Console.WriteLine($"\nAgendamento {agendamentoFiltrado.Id} alterado com sucesso!");
}

void ExcluirAgendamento()
{
    if (agendamentos.Count == 0)
    {
        Console.WriteLine("Agenda vazia");
        return;
    }

    ListarAgendamentos();

    Console.WriteLine("\nDigite o Id do agendamento que deseja alterar: ");
    Guid idAgendamento;

    while (!Guid.TryParse(Console.ReadLine(), out idAgendamento) || !agendamentos.Any(p => p.Id == idAgendamento))
        Console.WriteLine("Agendamento não encontrado");

    var agendamentoFiltrado = agendamentos.FirstOrDefault(a => a.Id == idAgendamento);

    agendamentos.Remove(agendamentoFiltrado);
    Console.WriteLine($"\nAgendamento{agendamentoFiltrado.Id} escluido com sucesso!");
}

void RankingAgendamentos()
{
    if (agendamentos.Count == 0)
    {
        Console.WriteLine("Agenda vazia");
        return;
    }

    ListarConsultas();

    Console.WriteLine("\nEscolha o código da consulta:  ");
    string codigoConsulta = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(codigoConsulta) || !consultas.Any(c => c.Codigo == codigoConsulta))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(codigoConsulta)
            ? "Código é obrigatório"
            : "Consulta não encontrada");

        codigoConsulta = Console.ReadLine();
    }

    var ranking = agendamentos
                    .Where(a => a.Consulta.Codigo == codigoConsulta)
                    .GroupBy(g => g.Tipo)
                    .Select(s => new { TipoAtendimento = s.Key, Pacientes = s.Count() })
                    .OrderByDescending(s => s.Pacientes)
                    .ToList();

    if (ranking.Count == 0)
    {
        Console.WriteLine("Nenhum agendamento encontrado para esta consulta.");
        Console.WriteLine("\nPressione qualquer tecla para continuar...");
        Console.ReadKey();
        return;
    }

    Console.WriteLine($"===== RANKING CONSULTA: {codigoConsulta} =====");
    Console.WriteLine($"Total de pacientes agendados: {ranking.Sum(r => r.Pacientes)}\n");

    foreach (var item in ranking)
        Console.WriteLine($"Tipo Atendimento: {item.TipoAtendimento}\n" +
                          $"Quantidade Pacientes: {item.Pacientes}\n");

    Console.WriteLine("\nPressione qualquer tecla para continuar...");
    Console.ReadKey();
}

void HistoricoPaciente()
{
    if (agendamentos.Count == 0)
    {
        Console.WriteLine("Agenda vazia");
        return;
    }

    ListarPacientes();

    Console.WriteLine("Digite o cpf do paciente que deseja ver o histórico: ");
    string cpf = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(cpf) || !pacientes.Any(p => p.CPF == cpf))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(cpf)
            ? "CPF não pode ser vazio"
            : "Paciente não encontrado");

        cpf = Console.ReadLine();
    }

    var historico = agendamentos
        .Where(a => a.Paciente.CPF == cpf)
        .OrderBy(a => a.Consulta.DataHora)
        .ToList();

    if (historico.Count == 0)
    {
        Console.WriteLine("Nenhum agendamento encontrado para este paciente.");
        Console.WriteLine("Pressione qualquer tecla");
        Console.ReadKey();
        return;
    }

    Console.WriteLine($"===== HISTÓRICO PACIENTE: {cpf} =====");
    foreach (var a in historico)
    {
        Console.WriteLine($"\nConsulta: {a.Consulta.Codigo}\n" +
                          $"Médico Responsável: {a.Consulta.Medico.Nome}\n" +
                          $"Data: {a.Consulta.DataHora}\n" +
                          $"Tipo de Atendimento: {a.Tipo}\n" +
                          $"Status: {a.Consulta.Status}");
    }

    Console.WriteLine("Pressione qualquer tecla");
    Console.ReadKey();
}


void ConsultaTipoAtendimento()
{
    if (consultas.Count == 0)
    {
        Console.WriteLine("Não existem consultas");
        return;
    }

    ListarConsultas();

    Console.WriteLine("\nEscolha o código da consulta:  ");
    string codigoConsulta = Console.ReadLine();

    while (string.IsNullOrWhiteSpace(codigoConsulta) || !consultas.Any(c => c.Codigo == codigoConsulta))
    {
        Console.WriteLine(string.IsNullOrWhiteSpace(codigoConsulta)
            ? "Código é obrigatório"
            : "Consulta não encontrada");

        codigoConsulta = Console.ReadLine();
    }

    Console.WriteLine("===== TIPO ATENDIMENTO =====");
    Console.WriteLine("1 - Presencial");
    Console.WriteLine("2 - TeleMedicina");
    Console.WriteLine("3 - Procedimento Complexo");

    Console.WriteLine("\nEscolha o Tipo de atendimento desejado: ");
    int tipoEscolhido;

    while (!int.TryParse(Console.ReadLine(), out tipoEscolhido) || tipoEscolhido < 1 || tipoEscolhido > 3)
        Console.WriteLine("Digite uma opção entre 1 e 3");

    var tipoAtendimento = (TipoAtendimentoEnum)tipoEscolhido;

    var tipoAtendimentoFiltrado = agendamentos.Where(a => a.Consulta.Codigo == codigoConsulta && a.Tipo == tipoAtendimento)
        .OrderBy(a => a.Paciente.NomeCompleto)
        .ToList();

    if (tipoAtendimentoFiltrado.Count == 0)
    {
        Console.WriteLine("Nenhum Paciente encontrado para esse atendimento");
        Console.WriteLine("Pressione qualquer tecla");
        Console.ReadKey();
        return;
    }

    Console.WriteLine($"==== CONSULTA: {codigoConsulta} | Tipo Atendimento: {tipoAtendimento} ====");
    foreach (var p in tipoAtendimentoFiltrado)
        Console.WriteLine($"{p.Paciente.NomeCompleto}");

    Console.WriteLine("\nPressione qualquer tecla");
    Console.ReadKey();
}
