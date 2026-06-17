using ProvaSexta.Models;
using ProvaSexta.Enums;

List<Agendamento> Agendamentos = [];
List<Consulta> Consultas = [];
List<Medico> Medicos = [];
List<Paciente> Pacientes = [];

int opcaoMenu;

while(true)
{
    Console.WriteLine("==================== Paciente ====================");
    Console.WriteLine("1 - Cadastrar Paciente");
    Console.WriteLine("2 - Mostrar Paciente");
    Console.WriteLine("3 - Atualizar Paciente");
    Console.WriteLine("4 - Deletar Paciente");
    Console.WriteLine("==================== Medico ====================");
    Console.WriteLine("5 - Cadastrar Medico");
    Console.WriteLine("6 - Mostrar Medico");
    Console.WriteLine("7 - Atualizar Medico");
    Console.WriteLine("8 - Deletar Medico");
    Console.WriteLine("==================== Consulta ====================");
    Console.WriteLine("9 - Cadastrar Consulta");
    Console.WriteLine("10 - Mostrar Consulta");
    Console.WriteLine("11 - Atualizar Consulta");
    Console.WriteLine("12 - Deletar Consulta");
    Console.WriteLine("==================== Agendamento ====================");
    Console.WriteLine("13 - Cadastrar Agendamento");
    Console.WriteLine("14 - Mostrar Agendamento");
    Console.WriteLine("15 - Atualizar Agendamento");
    Console.WriteLine("16 - Deletar Agendamento");
    Console.WriteLine("==================== Sistema ====================");
    Console.WriteLine("0 - Sair");

    Console.WriteLine("Digite a opcao que deseja: ");
    while(!int.TryParse(Console.ReadLine(), out opcaoMenu) || opcaoMenu < 0 || opcaoMenu > 16)
        Console.Write("o indice digitado é invalido, tente novamente");

    switch(opcaoMenu)
    {
        case 0:
            Environment.Exit(0);
        break;

        case 1:
            CadastrarPaciente();
        break;

        case 2:
            MostrarPaciente();
        break;

        case 3:
            AtualizarPaciente();
        break;

        case 4:
            DeletarPaciente();
        break;

        case 5:
            CadastrarMedico();
        break;

        case 6:
            MostrarMedico();
        break;

        case 7:
            AtualizarMedico();
        break;

        case 8:
            DeletarMedico();
        break;

        case 9:
            CadastrarConsulta();
        break;

        case 10:
            MostrarConsulta();
        break;

        case 11:
            AtualizarConsulta();
        break;

        case 12:
            DeletarConsulta();
        break;

        case 13:
            CadastrarAgendamento();
        break;

        case 14:
            MostrarAgendamento();
        break;

        case 15:
            AtualizarAgendamento();
        break;

        case 16:
            DeletarAgendamento();
        break;
    }

    void CadastrarPaciente()
    {
        string Nome;
        DateTime DataNascimento;
        string CPF;
        int NumeroCarteira;

        Console.WriteLine("Digite o nome do paciente: ");
        Nome = Console.ReadLine();
        while(string.IsNullOrWhiteSpace(Nome))
        {
            Console.WriteLine("nome invalido, tente novamente");
            Nome = Console.ReadLine();
        }

        Console.WriteLine("Digite a data de nascimento: ");
        while(!DateTime.TryParse(Console.ReadLine(), out DataNascimento) || DataNascimento > DateTime.Now)
            Console.WriteLine("data invalida, tente novamente");

        Console.WriteLine("Digite o CPF do paciente: ");
        CPF = Console.ReadLine();
        while(string.IsNullOrWhiteSpace(CPF) || CPF.Length != 11 || Pacientes.Any(p => p.CPF == CPF))
        {
            Console.WriteLine("CPF invalido, tente novamente");
            CPF = Console.ReadLine();
        }

        Console.WriteLine("Digite o numero da carteira: ");
        while(!int.TryParse(Console.ReadLine(), out NumeroCarteira) || NumeroCarteira <= 0)
            Console.WriteLine("numero invalido, tente novamente");

        Paciente paciente = new Paciente(Nome, DataNascimento, CPF, NumeroCarteira);
        Pacientes.Add(paciente);
    }

    void MostrarPaciente()
    {
        if(Pacientes.Count == 0)
        {
            Console.WriteLine("lista de pacientes vazia");
            return;
        }

        int indicePaciente = 1;

        foreach(var paciente in Pacientes)
        {
            Console.WriteLine($"Indice: {indicePaciente} | Nome: {paciente.Nome} | Data Nascimento {paciente.DataNascimento} | CPF: {paciente.CPF} | NumeroCarteira: {paciente.NumeroCarteira}");
            indicePaciente++;
        }
    }

    void AtualizarPaciente()
    {
        int indicePaciente;

        MostrarPaciente();

        Console.WriteLine("Digite o indice do paciente que deseja alterar: ");
        while(!int.TryParse(Console.ReadLine(), out indicePaciente) || indicePaciente <= 0 || indicePaciente > Pacientes.Count())
            Console.WriteLine("indice invalido, tente novamente");

        Paciente paciente = Pacientes[indicePaciente-1];

        string novoNome;
        int novoNumeroCarteira;

        Console.WriteLine("novo nome (Enter para manter): ");
        novoNome = Console.ReadLine();

        Console.WriteLine("novo numero da carteira (Enter para manter): ");
        while(!int.TryParse(Console.ReadLine(), out novoNumeroCarteira) || novoNumeroCarteira <= 0)
            Console.WriteLine("numero invalido, tente novamente");

        paciente.AlterarNome(novoNome);
        paciente.AlterarNumeroCarteira(novoNumeroCarteira);
    }

    void DeletarPaciente()
    {
        int indicePaciente;

        MostrarPaciente();

        Console.WriteLine("Digite o indice do paciente que deseja alterar: ");
        while(!int.TryParse(Console.ReadLine(), out indicePaciente) || indicePaciente <= 0 || indicePaciente > Pacientes.Count())
            Console.WriteLine("indice invalido, tente novamente");

        Paciente paciente = Pacientes[indicePaciente-1];

        // validar se esta em outra lista

        Pacientes.Remove(paciente);
    }

    void CadastrarMedico()
    {
        string NumeroRegistro;
        string Nome;
        string EspecialidadeMedico;

        Console.WriteLine("Digite o numero de registro: ");
        NumeroRegistro = Console.ReadLine();
        while(string.IsNullOrWhiteSpace(NumeroRegistro))
        {
           Console.WriteLine("numero de registro invalido, tente novamente");
           NumeroRegistro = Console.ReadLine();
        }

        Console.WriteLine("Digite o nome do medico: ");
        Nome = Console.ReadLine();
        while(string.IsNullOrWhiteSpace(Nome))
        {
           Console.WriteLine("o nome digitado é invalido, tente novamente");
           Nome = Console.ReadLine();
        }

        Console.WriteLine("Digite a especialidade do medico: ");
        EspecialidadeMedico = Console.ReadLine();
        while(string.IsNullOrWhiteSpace(EspecialidadeMedico))
        {
           Console.WriteLine("especialidade invalida, tente novamente");
           EspecialidadeMedico = Console.ReadLine();
        }

        Medico medico = new Medico(NumeroRegistro, Nome, EspecialidadeMedico);
        Medicos.Add(medico);
    }

    void MostrarMedico()
    {
        if (Medicos.Count == 0)
        {
            Console.WriteLine("nenhum medico cadastrado");
            return;
        }

        int indiceMedico = 1;

        foreach(var medico in Medicos)
        {
            Console.WriteLine($"{indiceMedico} | Numero Registro: {medico.NumeroRegistro} | Nome: {medico.Nome} | Especialidade: {medico.EspecialidadeMedico}");
            indiceMedico++;
        }
    }

    void AtualizarMedico()
    {
        string NumeroRegistro;
        string Nome;
        string EspecialidadeMedico;

        MostrarMedico();

        int indiceMedico;

        Console.WriteLine("indice do medico que deseja atualizar: ");
        while(!int.TryParse(Console.ReadLine(), out indiceMedico) || indiceMedico <= 0 || indiceMedico > Medicos.Count())
            Console.WriteLine("indice invalido, tente novamente");

        Medico medico = Medicos[indiceMedico-1];

        Console.WriteLine("Digite o novo Numero de registro (aperte enter se for manter)");
        NumeroRegistro = Console.ReadLine();

        Console.WriteLine("Digite o novo nome do Medico (aperte enter se for manter)");
        Nome = Console.ReadLine();

        Console.WriteLine("Digite a especialidade medica nova (aperte enter se for manter)");
        EspecialidadeMedico = Console.ReadLine();

        medico.AtualizarNumeroRegistro(NumeroRegistro);
        medico.AtualizarNome(Nome);
        medico.AtualizarEspecialidade(EspecialidadeMedico);
    }

    void DeletarMedico()
    {
        MostrarMedico();

        int indiceMedico;

        Console.WriteLine("indice do medico que deseja deletar: ");
        while(!int.TryParse(Console.ReadLine(), out indiceMedico) || indiceMedico <= 0 || indiceMedico > Medicos.Count())
            Console.WriteLine("indice invalido, tente novamente");

        Medico medico = Medicos[indiceMedico-1];

        Medicos.Remove(medico);
    }

    void CadastrarConsulta()
    {
        if (Medicos.Count == 0)
        {
            Console.WriteLine("nenhum medico cadastrado");
            return;
        }

        MostrarMedico();

        int indiceMedico;
        Console.WriteLine("Selecione o indice do medico responsavel: ");
        while (!int.TryParse(Console.ReadLine(), out indiceMedico) || indiceMedico <= 0 || indiceMedico > Medicos.Count)
            Console.WriteLine("indice invalido, tente novamente");
        Medico medico = Medicos[indiceMedico - 1];

        string codigo;
        Console.WriteLine("codigo da consulta:  ");
        codigo = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(codigo) || Consultas.Any(c => c.Codigo == codigo))
        {
            Console.WriteLine("codigo invalido ou ja existe, tente novamente");
            codigo = Console.ReadLine();
        }

        string localAtendimento;
        Console.WriteLine("local de atendimento: ");
        localAtendimento = Console.ReadLine();
        while (string.IsNullOrWhiteSpace(localAtendimento))
        {
            Console.WriteLine("local invalido, tente novamente");
            localAtendimento = Console.ReadLine();
        }

        DateTime dataHora;
        Console.WriteLine("data e hora da consulta (ex: 25/12/2025 14:30): ");
        while (!DateTime.TryParse(Console.ReadLine(), out dataHora))
            Console.WriteLine("data/hora invalida, tente novamente");

        int duracao;
        Console.WriteLine("duracao estimada em minutos: ");
        while (!int.TryParse(Console.ReadLine(), out duracao) || duracao <= 0)
            Console.WriteLine("duracao invalida, tente novamente");

        Consulta consulta = new Consulta(medico, codigo, localAtendimento, dataHora, duracao);
        Consultas.Add(consulta);
    }

    void MostrarConsulta()
    {
        if (Consultas.Count == 0)
        {
            Console.WriteLine("nenhuma consulta cadastrada");
            return;
        }

        int indice = 1;
        foreach (var consulta in Consultas)
        {
            Console.WriteLine($"{indice} | Código: {consulta.Codigo} | Médico: {consulta.Medico.Nome} | Local: {consulta.LocalAtendimento} | Data: {consulta.DataHora:dd/MM/yyyy HH:mm} | Duração: {consulta.DuracaoEstimadaMinutos} min | Status: {consulta.Status}");
            indice++;
        }
    }

    void AtualizarConsulta()
    {
        if (Consultas.Count == 0)
        {
            Console.WriteLine("nenhuma consulta cadastrada");
            return;
        }

        MostrarConsulta();

        int indiceConsulta;
        Console.WriteLine("indice da consulta que deseja atualizar: ");
        while (!int.TryParse(Console.ReadLine(), out indiceConsulta) || indiceConsulta <= 0 || indiceConsulta > Consultas.Count)
            Console.WriteLine("indice invalido, tente novamente");

        Consulta consulta = Consultas[indiceConsulta - 1];

        Console.WriteLine($"codigo atual: {consulta.Codigo}");
        Console.WriteLine("novo codigo (Enter para manter): ");
        string novoCodigo = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(novoCodigo))
        {
            if (Consultas.Any(c => c.Codigo == novoCodigo && c.Id != consulta.Id))
                Console.WriteLine("codigo ja existe");
            else
                consulta.AtualizarCodigo(novoCodigo);
        }

        Console.WriteLine($"local atual: {consulta.LocalAtendimento}");
        Console.WriteLine("novo local (Enter para manter): ");
        string novoLocal = Console.ReadLine();
        consulta.AtualizarLocal(novoLocal);

        Console.WriteLine($"data/hora atual: {consulta.DataHora:dd/MM/yyyy HH:mm}");
        Console.WriteLine("nova data/hora (Enter para manter): ");
        string dataInput = Console.ReadLine();
        if (DateTime.TryParse(dataInput, out DateTime novaData))
            consulta.AtualizarDataHora(novaData);

        Console.WriteLine($"duracao atual: {consulta.DuracaoEstimadaMinutos} min");
        Console.WriteLine("nova duracao em minutos (Enter para manter): ");
        string duracaoInput = Console.ReadLine();
        if (int.TryParse(duracaoInput, out int novaDuracao) && novaDuracao > 0)
            consulta.AtualizarDuracao(novaDuracao);

        Console.WriteLine($"status atual: {consulta.Status}");
        Console.WriteLine("1 - Pendente | 2 - Confirmada | 3 - Realizada | 4 - Cancelada");
        Console.WriteLine("novo status (Enter para manter): ");
        string statusInput = Console.ReadLine();
        if (int.TryParse(statusInput, out int statusNum) && statusNum >= 1 && statusNum <= 4)
            consulta.AtualizarStatus((ConsultaStatus)statusNum);
    }

    void DeletarConsulta()
    {
        if (Consultas.Count == 0)
        {
            Console.WriteLine("nenhuma consulta cadastrada");
            return;
        }

        MostrarConsulta();

        int indiceConsulta;
        Console.WriteLine("indice da consulta que deseja deletar: ");
        while (!int.TryParse(Console.ReadLine(), out indiceConsulta) || indiceConsulta <= 0 || indiceConsulta > Consultas.Count)
            Console.WriteLine("indice invalido, tente novamente");

        Consulta consulta = Consultas[indiceConsulta - 1];

        if (Agendamentos.Any(a => a.Consulta.Id == consulta.Id))
        {
            Console.WriteLine("consulta possui agendamentos vinculados");
            return;
        }

        Consultas.Remove(consulta);
    }

    void CadastrarAgendamento()
    {
        if (Consultas.Count == 0)
        {
            Console.WriteLine("nenhuma consulta cadastrada");
            return;
        }

        if (Pacientes.Count == 0)
        {
            Console.WriteLine("nenhum paciente cadastrado");
            return;
        }

        MostrarConsulta();

        int indiceConsulta;
        Console.WriteLine("indice da consulta: ");
        while (!int.TryParse(Console.ReadLine(), out indiceConsulta) || indiceConsulta <= 0 || indiceConsulta > Consultas.Count)
            Console.WriteLine("indice invalido, tente novamente");
        Consulta consulta = Consultas[indiceConsulta - 1];

        MostrarPaciente();

        int indicePaciente;
        Console.WriteLine("indice do paciente: ");
        while (!int.TryParse(Console.ReadLine(), out indicePaciente) || indicePaciente <= 0 || indicePaciente > Pacientes.Count)
            Console.WriteLine("indice invalido, tente novamente");
        Paciente paciente = Pacientes[indicePaciente - 1];

        if (Agendamentos.Any(a => a.Consulta.Id == consulta.Id && a.Paciente.Id == paciente.Id))
        {
            Console.WriteLine("paciente ja possui agendamento nesta consulta");
            return;
        }

        int TipoAtendimento;
        Console.WriteLine("tipo de atendimento: 1 - Presencial | 2 - Telemedicina | 3 - Procedimento Complexo");
        while (!int.TryParse(Console.ReadLine(), out TipoAtendimento) || TipoAtendimento < 1 || TipoAtendimento > 3)
            Console.WriteLine("tipo invalido, tente novamente");
        TipoAtendimentoEnum tipo = (TipoAtendimentoEnum)TipoAtendimento;

        decimal valorCobrado;
        Console.WriteLine("valor cobrado: ");
        while (!decimal.TryParse(Console.ReadLine(), out valorCobrado) || valorCobrado < 0)
            Console.WriteLine("valor invalido, tente novamente");

        Agendamento agendamento = new Agendamento(consulta, paciente, valorCobrado, DateTime.Now, tipo);
        Agendamentos.Add(agendamento);
    }

    void MostrarAgendamento()
    {
        if (Agendamentos.Count == 0)
        {
            Console.WriteLine("nenhum agendamento cadastrado");
            return;
        }

        int indice = 1;
        foreach (var ag in Agendamentos)
        {
            Console.WriteLine($"{indice} | Consulta: {ag.Consulta.Codigo} | Paciente: {ag.Paciente.Nome} | Tipo: {ag.TipoAtendimento} | Valor: R${ag.ValorCobrado:F2} | Confirmado em: {ag.DataConfirmacao:dd/MM/yyyy}");
            indice++;
        }
    }

    void AtualizarAgendamento()
    {
        if (Agendamentos.Count == 0)
        {
            Console.WriteLine("Nenhum agendamento cadastrado");
            return;
        }

        MostrarAgendamento();

        int indice;
        Console.WriteLine("Digite o indice do agendamento que deseja atualizar: ");
        while (!int.TryParse(Console.ReadLine(), out indice) || indice <= 0 || indice > Agendamentos.Count)
            Console.WriteLine("Índice inválido, tente novamente.");

        Agendamento agendamento = Agendamentos[indice - 1];

        Console.WriteLine($"Tipo atual: {agendamento.TipoAtendimento}");
        Console.WriteLine("1 - Presencial | 2 - Telemedicina | 3 - Procedimento Complexo");
        Console.WriteLine("Digite o novo tipo (aperte Enter para manter): ");
        string tipoInput = Console.ReadLine();
        if (int.TryParse(tipoInput, out int tipoNum) && tipoNum >= 1 && tipoNum <= 3)
            agendamento.AtualizarTipoAtendimento((TipoAtendimentoEnum)tipoNum);

        Console.WriteLine($"Valor atual: R${agendamento.ValorCobrado:F2}");
        Console.WriteLine("Digite o novo valor (aperte Enter para manter): ");
        string valorInput = Console.ReadLine();
        if (decimal.TryParse(valorInput, out decimal novoValor) && novoValor >= 0)
            agendamento.AtualizarValorCobrado(novoValor);
    }

    void DeletarAgendamento()
    {
        if (Agendamentos.Count == 0)
        {
            Console.WriteLine("nenhum agendamento cadastrado");
            return;
        }

        MostrarAgendamento();

        int indice;
        Console.WriteLine("indice do agendamento que deseja deletar: ");
        while (!int.TryParse(Console.ReadLine(), out indice) || indice <= 0 || indice > Agendamentos.Count)
            Console.WriteLine("indice invalido, tente novamente");

        Agendamento agendamento = Agendamentos[indice - 1];
        Agendamentos.Remove(agendamento);
    }

    void BuscarPacientePeloNome()
    {
        MostrarPaciente();

        
    }
}
