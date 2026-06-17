# PROGRESSO — MedConsulta CRUD

> **Estado** deste projeto: o que já existe, o que falta e as decisões específicas do MedConsulta.
> Itere neste arquivo a cada etapa concluída. (Descartável: numa atividade nova, começa um do zero.)
>
> Método e referência de código moram fora daqui:
> - **Como atacar a atividade / ritmo** → `FLUXO_ATIVIDADE.md`
> - **Esqueleto de cada operação + assinaturas do `Validador`** → `CRUD_GUIA.md`

---

## Regras específicas do domínio MedConsulta

**Métodos obrigatórios em cada Model:**

| Model | Métodos além do construtor |
|-------|---------------------------|
| `Medico` | `Atualizar(nome, especialidade)`, `ToString()` |
| `Paciente` | `Atualizar(nomeCompleto, dataNascimento, numeroPlano)`, `ToString()` |
| `Consulta` | `Atualizar(local, dataHora, duracao, medico)`, `AlterarStatus(status)`, `ToString()` |
| `Agendamento` | `Atualizar(tipoAtendimento, valorCobrado)`, `ToString()` |

**Unicidade (inline via `.Any()`):** CRM · CPF · NumeroPlano (carteirinha) · CodigoUnico · par `Paciente.Cpf + Consulta.CodigoUnico`.
**Dependência antes de excluir:** Médico ← consultas · Paciente ← agendamentos · Consulta ← agendamentos · Agendamento = folha.
**Imutáveis** (não entram no `Atualizar()`): `Crm`, `Cpf`, `CodigoUnico`.

---

## Checklist do Projeto

### ✅ Concluído

- [x] Enums: `StatusConsultaEnum` (Pendente, Confirmada, Realizada, Cancelada)
- [x] Enums: `TipoAtendimentoEnum` (Presencial, Telemedicina, ProcedimentoComplexo)
- [x] Model: `Medico` (Crm, Nome, Especialidade)
- [x] Model: `Paciente` (NomeCompleto, DataNascimento, Cpf, NumeroPlano)
- [x] Model: `Consulta` (CodigoUnico, LocalAtendimento, DataHoraPrevista, DuracaoEstimada, MedicoResponsavel, StatusConsulta)
- [x] Model: `Agendamento` (TipoAtendimento, ValorCobrado, DataConfirmada, Paciente, Consulta)
- [x] `Program.cs`: listas em memória + menu principal + submenus placeholder

---

### 🔲 Próximas etapas (em ordem)

#### Etapa 0 — Helper de validação
- [ ] `Helpers/Validador.cs`: `ValidarTexto`, `ValidarCpf`, `ValidarCrm`, `ValidarCodigoConsulta`, `ValidarInt`, `ValidarDecimal`, `ValidarData`, `ValidarDataHora`, `ValidarOpcaoEnum<T>`

#### Etapa 1 — Métodos nos Models
- [ ] `Medico`: adicionar `Atualizar()` e `ToString()`
- [ ] `Paciente`: adicionar `Atualizar()` e `ToString()`
- [ ] `Consulta`: adicionar `Atualizar()`, `AlterarStatus()` e `ToString()`
- [ ] `Agendamento`: adicionar `Atualizar()` e `ToString()`

#### Etapa 2 — CRUD de Médicos
- [ ] `CadastrarMedico()`: validar formato + unicidade CRM → criar e adicionar
- [ ] `ListarMedico()`: exibir todos via `ToString()` ou mensagem vazia
- [ ] `EditarMedico()`: buscar por CRM → chamar `Atualizar()`
- [ ] `ExcluirMedico()`: verificar dependência → remover da lista

#### Etapa 3 — CRUD de Pacientes
- [ ] `CadastrarPaciente()`: validar CPF (formato + unicidade) + carteirinha única
- [ ] `ListarPaciente()`: exibir todos
- [ ] `EditarPaciente()`: buscar por CPF → chamar `Atualizar()`
- [ ] `ExcluirPaciente()`: verificar agendamentos → remover

#### Etapa 4 — CRUD de Consultas (depende de Médico)
- [ ] `CadastrarConsulta()`: validar código único + buscar médico por CRM
- [ ] `ListarConsulta()`: exibir todas
- [ ] `EditarConsulta()`: buscar por código → `Atualizar()` e/ou `AlterarStatus()`
- [ ] `ExcluirConsulta()`: verificar agendamentos → remover

#### Etapa 5 — CRUD de Agendamentos (depende de Paciente + Consulta)
- [ ] `CadastrarAgendamento()`: buscar paciente (CPF) + consulta (código) → validar par único
- [ ] `ListarAgendamento()`: exibir todos
- [ ] `EditarAgendamento()`: buscar par → `Atualizar()` tipo e valor
- [ ] `ExcluirAgendamento()`: buscar par → remover

#### Etapa 6 — Relatórios
- [ ] `BuscarPacientePorNome()`: nome parcial, case-insensitive
- [ ] `RankingAgendamentosConsulta()`: buscar consulta → agrupar por tipo → ordenar decrescente
- [ ] `HistoricoConsultasPaciente()`: buscar paciente → filtrar agendamentos → ordenar por `DataHoraPrevista`
- [ ] `FiltrarPacientesPorTipoAtendimento()`: filtrar por consulta + tipo → ordenar por nome

---

## Decisões técnicas registradas

| Decisão | Motivo |
|--------|--------|
| `Helpers/Validador.cs` estático; sem `Services/` | Validação de formato se repete em todo cadastro/edição — centralizar elimina duplicação |
| Propriedades `private set` + métodos `Atualizar()` | Encapsulamento: atributo só muda via método explícito |
| `Crm`, `Cpf`, `CodigoUnico` imutáveis | Identificadores únicos — mudar quebraria referências |
| Unicidade/dependência inline via `.Any()` no `Program.cs` | Precisa das listas; sem overhead de classe extra |
| `Agendamento` guarda referência direta a `Paciente` e `Consulta` | Navegação direta no objeto, sem lookup por ID |
| `StatusConsulta` começa como `Pendente` no construtor | Toda consulta nasce pendente (⚠️ construtor atual recebe status por parâmetro — revisar na Etapa 1) |
