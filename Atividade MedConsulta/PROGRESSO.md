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

#### Etapa 2 — CRUD de Médicos ✅
- [x] `CadastrarMedico()`: unicidade CRM (re-prompt) → criar e adicionar
- [x] `ListarMedico()`: exibir todos via `ToString()` ou mensagem vazia
- [x] `EditarMedico()`: listar → buscar por CRM → `Atualizar()` (CRM imutável)
- [x] `ExcluirMedico()`: listar → buscar por CRM → checar consultas → remover

#### Etapa 3 — CRUD de Pacientes ✅
- [x] `CadastrarPaciente()`: validar CPF (formato + unicidade) + carteirinha única (re-prompt)
- [x] `ListarPaciente()`: exibir todos
- [x] `EditarPaciente()`: buscar por CPF → re-checar plano único (`p != paciente`) → `Atualizar()` (CPF imutável)
- [x] `ExcluirPaciente()`: checar agendamentos → remover

#### Etapa 4 — CRUD de Consultas (depende de Médico) ✅
- [x] `CadastrarConsulta()`: validar código único + buscar médico por CRM
- [x] `ListarConsulta()`: exibir todas
- [x] `EditarConsulta()`: buscar por código → `Atualizar()` (só dados descritivos; status fora)
- [x] `AlterarStatusConsulta()`: **opção de menu separada** → buscar por código → `AlterarStatus()` via `ValidarOpcaoEnum<StatusConsultaEnum>`
- [x] `ExcluirConsulta()`: verificar agendamentos (`a.Consulta == consulta`) → remover

#### Etapa 5 — CRUD de Agendamentos (depende de Paciente + Consulta) ✅
- [x] `CadastrarAgendamento()`: buscar paciente (CPF) + consulta (código) → validar par único
- [x] `ListarAgendamento()`: exibir todos
- [x] `EditarAgendamento()`: buscar par (CPF + código) → `Atualizar()` tipo e valor
- [x] `ExcluirAgendamento()`: buscar par → remover (folha, sem dependência)

#### Etapa 6 — Relatórios ✅
- [x] `BuscarPacientePorNome()`: nome parcial, case-insensitive (`Contains` + `OrdinalIgnoreCase`)
- [x] `RankingAgendamentosConsulta()`: buscar consulta → agrupar por tipo → ordenar decrescente
- [x] `HistoricoConsultasPaciente()`: buscar paciente → filtrar agendamentos → ordenar por `DataHoraPrevista`
- [x] `FiltrarPacientesPorTipoAtendimento()`: filtrar por consulta + tipo → ordenar por nome

---

## Decisões técnicas registradas

| Decisão | Motivo |
|--------|--------|
| `Helpers/Validador.cs` estático; sem `Services/` | Validação de formato se repete em todo cadastro/edição — centralizar elimina duplicação |
| Propriedades `private set` + métodos `Atualizar()` | Encapsulamento: atributo só muda via método explícito |
| `Crm`, `Cpf`, `CodigoUnico` imutáveis | Identificadores únicos — mudar quebraria referências |
| Unicidade/dependência inline via `.Any()` no `Program.cs` | Precisa das listas; sem overhead de classe extra |
| `Agendamento` guarda referência direta a `Paciente` e `Consulta` | Navegação direta no objeto, sem lookup por ID |
| Editar/Excluir: guarda `Count == 0` + `Listar...()` antes de pedir a chave | UX — mostra o que existe (chaves válidas) e barra cedo se a lista está vazia. Padrão pros 4 CRUDs |
| CRM/CPF/Código fora do `Atualizar()` (imutáveis) | Mudar a chave sem re-checar unicidade criaria duplicata — 2 colegas têm esse furo |
| Busca por chave (não por índice) em Editar/Excluir | Consistente com os 4 CRUDs do PROGRESSO; treina `FirstOrDefault` + tratamento de `null` |
| Re-prompt em loop na unicidade (Cadastrar); fail-fast no "não encontrado" (Editar/Excluir) | Re-prompt quando há correção que destrava; fail-fast quando "não achou" pode não ter o que corrigir |
| `StatusConsulta` começa como `Pendente` no construtor | Toda consulta nasce pendente (⚠️ construtor atual recebe status por parâmetro — revisar na Etapa 1) |
| Editar campo único: re-checar com `Any(x => x != atual && x.Campo == novo)` | Sem excluir o próprio registro, manter o mesmo valor dispara "já existe" falso — trava a edição |
| Mudar status = opção de menu própria (`AlterarStatusConsulta`), fora do `EditarConsulta` | Model separa `Atualizar` (dados) de `AlterarStatus` (ciclo de vida) por SRP — o menu espelha isso. Editar mexe só em local/data/duração/médico |
| Ler enum do usuário via `ValidarOpcaoEnum<T>` genérico (`Enum.GetValues<T>` + índice) | Um método pra qualquer enum; devolve valor tipado sem cast cru. Evita enum-fantasma do `(Tipo)int` e a duplicação de um método por enum |
