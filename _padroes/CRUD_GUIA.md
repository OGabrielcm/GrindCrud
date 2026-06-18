# CRUD_GUIA — Esqueletos de referência por operação

> **O que este doc é:** referência reutilizável dos *padrões* de cada operação CRUD e das assinaturas do `Validador`.
> **O que este doc NÃO é:** gabarito. Os corpos abaixo são **esqueletos com pseudocódigo** — você escreve a lógica. Relatórios (ranking, histórico, filtro) aparecem só como *passos*, não como C# copiável.
>
> Fronteira com os outros docs:
> - `PROGRESSO.md` = estado/checklist **deste** projeto.
> - `FLUXO_ATIVIDADE.md` = o **processo** de atacar uma atividade do zero.
> - **este** = padrão **por operação** (consulta rápida enquanto codifica um método).

---

## 1. Anatomia de qualquer método CRUD

Todo método de CRUD segue a mesma espinha. Decore a ordem, não o código:

| Operação | Passos na ordem |
|----------|----------------|
| **Cadastrar** | 1. ler campos (Validador) → 2. validar unicidade (`.Any()`) → 3. resolver dependências (buscar médico/paciente) → 4. `new` → 5. `lista.Add` → 6. msg `[OK]` |
| **Listar** | 1. lista vazia? → msg e `return` → 2. `foreach` imprimindo `ToString()` |
| **Editar** | 1. lista vazia? → msg e `return` → 2. **listar** (reusar `Listar()`) p/ o usuário ver os IDs → 3. ler identificador → 4. buscar (`FirstOrDefault`) → 5. não achou? msg e `return` → 6. ler novos campos → 7. `obj.Atualizar(...)` → 8. msg `[OK]` |
| **Excluir** | 1. lista vazia? → msg e `return` → 2. **listar** (reusar `Listar()`) → 3. ler identificador → 4. buscar → 5. não achou? msg e `return` → 6. tem dependente? (`.Any()`) msg e `return` → 7. `lista.Remove` → 8. msg `[OK]` |

> Regra de ouro: **valide formato ao ler (Validador), valide negócio depois (inline com as listas).**
>
> **UX de Editar/Excluir:** trate lista vazia primeiro, depois **reuse o `Listar()`** antes de pedir o identificador — o usuário vê os IDs disponíveis sem precisar sair e listar à parte. Reusar > copiar o `foreach`.

---

## 2. Esqueleto — CADASTRAR

```csharp
void CadastrarMedico()
{
    // 1. LER (formato já validado pelo Validador)
    string crm  = Validador.ValidarCrm("CRM (ex.: CRM12345): ");
    // ... demais campos

    // 2. UNICIDADE — olhar a lista
    if (medicos.Any(m => m.Crm.Equals(crm, StringComparison.OrdinalIgnoreCase)))
    {
        Console.WriteLine("[ERRO] CRM já cadastrado.");
        return;
    }

    // 3. (se houver dependência) buscar o objeto-pai e abortar se não existir
    // 4. CRIAR + ADICIONAR
    // medicos.Add(new Medico(...));
    // 5. Console.WriteLine("[OK] ...");
}
```

> **Cadastros com dependência** (Consulta precisa de Médico; Agendamento precisa de Paciente + Consulta): a busca do pai entra **entre** a unicidade e o `new`. Se o pai não existe, `[ERRO]` e `return` — nunca crie filho órfão.

---

## 3. Esqueleto — LISTAR

```csharp
void ListarMedico()
{
    if (medicos.Count == 0)
    {
        Console.WriteLine("Nenhum registro encontrado.");
        return;
    }
    foreach (var m in medicos)
        Console.WriteLine(m); // usa o ToString() do Model
}
```

---

## 4. Esqueleto — EDITAR

```csharp
void EditarMedico()
{
    if (medicos.Count == 0) { Console.WriteLine("Nenhum registro encontrado."); return; }

    ListarMedico();  // reusa o Listar p/ o usuário ver os IDs antes de escolher

    string crm = Validador.ValidarCrm("CRM do médico a editar: ");

    var medico = medicos.FirstOrDefault(m => m.Crm.Equals(crm, StringComparison.OrdinalIgnoreCase));
    if (medico == null)
    {
        Console.WriteLine("[ERRO] Não encontrado.");
        return;
    }

    // ler só os campos EDITÁVEIS (nunca o identificador único)
    // medico.Atualizar(novoNome, novaEspecialidade);
    // Console.WriteLine("[OK] Dados atualizados.");
}
```

> Identificadores únicos (CRM, CPF, código) **não** se editam — mudar quebraria as referências dos agendamentos/consultas.
>
> **Campo com método mutador dedicado** (ex.: `Consulta.AlterarStatus`, separado de `Atualizar` por SRP): NÃO o enfie no `Editar`. Crie uma **opção de menu própria** (ex.: "5. Alterar Status") que reusa o mesmo começo (guarda de vazio → `Listar()` → buscar → guarda de `null`) e troca só o passo final por `obj.AlterarX(...)`. O menu espelha a separação de responsabilidades do Model.
>
> **Ler um enum do usuário:** use `Validador.ValidarOpcaoEnum<MeuEnum>(...)` — ele lista as opções via `Enum.GetValues<T>()` e devolve o **valor do enum já tipado**. Prefira isso ao cast cru `(MeuEnum)int`: o cast aceita números fora da faixa e cria "enum-fantasma"; o índice no array só devolve valores reais.
>
> **Campo editável que TAMBÉM é único** (ex.: número da carteirinha): ao reler, re-cheque a unicidade **excluindo o próprio registro** — `lista.Any(x => x != atual && x.Campo == novo)`. Sem o `x != atual`, manter o mesmo valor dispara um "[ERRO] já existe" falso e trava a edição.

---

## 5. Esqueleto — EXCLUIR

```csharp
void ExcluirMedico()
{
    if (medicos.Count == 0) { Console.WriteLine("Nenhum registro encontrado."); return; }

    ListarMedico();  // reusa o Listar p/ o usuário ver os IDs antes de escolher

    string crm = Validador.ValidarCrm("CRM do médico a excluir: ");

    var medico = medicos.FirstOrDefault(m => m.Crm.Equals(crm, StringComparison.OrdinalIgnoreCase));
    if (medico == null) { Console.WriteLine("[ERRO] Não encontrado."); return; }

    // DEPENDÊNCIA: não pode excluir se algo aponta pra ele
    if (consultas.Any(c => c.MedicoResponsavel.Crm == medico.Crm))
    {
        Console.WriteLine("[ERRO] Não é possível excluir — há consultas vinculadas.");
        return;
    }

    medicos.Remove(medico);
    Console.WriteLine("[OK] Removido com sucesso.");
}
```

| Excluir | Verificar dependente antes |
|---------|----------------------------|
| Médico | `consultas.Any(c => c.MedicoResponsavel.Crm == crm)` |
| Paciente | `agendamentos.Any(a => a.Paciente.Cpf == cpf)` |
| Consulta | `agendamentos.Any(a => a.Consulta.CodigoUnico == codigo)` |
| Agendamento | (folha — sem dependentes) |

---

## 6. Assinaturas do `Validador` (Helpers)

Cada método **imprime a pergunta, lê, valida em `while` e devolve o valor limpo** (`Trim()`). Escreva os corpos você — a tabela é o contrato.

| Método | Aceita quando | Devolve |
|--------|--------------|---------|
| `ValidarTexto(string msg)` | não vazio | `string` |
| `ValidarCpf(string msg)` | 11 dígitos numéricos | `string` |
| `ValidarCrm(string msg)` | começa com `CRM` + restante só dígitos | `string` (UPPER) |
| `ValidarCodigoConsulta(string msg)` | começa com `CONS` + restante só dígitos | `string` (UPPER) |
| `ValidarInt(string msg)` | `int.TryParse` e `> 0` | `int` |
| `ValidarDecimal(string msg)` | `decimal.TryParse` e `>= 0` | `decimal` |
| `ValidarData(string msg)` | `DateTime.TryParse` e não futura | `DateTime` |
| `ValidarDataHora(string msg)` | `DateTime.TryParse` | `DateTime` |
| `ValidarOpcaoEnum<T>(string msg)` | inteiro de `1` a `Enum.GetValues<T>().Length` | `T` (o valor do enum, já tipado) |

**Forma de um método (modelo único — replique mudando a condição do `while`):**

```csharp
public static string ValidarTexto(string msg)
{
    Console.Write(msg);
    string entrada = Console.ReadLine().Trim();
    while (string.IsNullOrWhiteSpace(entrada))
    {
        Console.Write("Entrada inválida. Tente novamente: ");
        entrada = Console.ReadLine().Trim();
    }
    return entrada;
}
```

> ⚠️ Ao escrever `ValidarCpf`/`ValidarCarteirinha`, cuidado com a armadilha vista no código de um colega: `texto.Length > 11 && texto.Length < 11` é **sempre falso** (nunca dispara). Use `texto.Length != 11`.

---

## 7. Mensagens padronizadas

| Situação | Mensagem |
|----------|----------|
| Cadastrado | `[OK] <entidade> cadastrado(a) com sucesso.` |
| Editado | `[OK] Dados atualizados.` |
| Excluído | `[OK] Removido com sucesso.` |
| Duplicado | `[ERRO] <campo> já cadastrado.` |
| Não encontrado | `[ERRO] Não encontrado.` |
| Tem dependente | `[ERRO] Não é possível excluir — há <dependentes> vinculados.` |
| Lista vazia | `Nenhum registro encontrado.` |
| Opção de menu inválida | `Opção inválida. Tente novamente.` |

---

## 8. Relatórios — só os PASSOS (escreva o LINQ você)

Não há código pronto aqui de propósito — é onde a prova mais avalia. Siga os passos:

- **Buscar paciente por nome (parcial, case-insensitive):** filtrar `pacientes` onde o nome *contém* o termo ignorando caixa. Lista vazia → mensagem.
- **Ranking de agendamentos por consulta:** ler código → achar a consulta → pegar agendamentos dela → **agrupar por tipo de atendimento** → contar cada grupo → ordenar **decrescente** pela contagem → imprimir.
- **Histórico de consultas por paciente:** ler CPF → achar paciente → pegar agendamentos dele → para cada um, mostrar a consulta (código, médico, data, tipo, status) → ordenar **crescente** por data prevista.
- **Filtro por tipo de atendimento:** ler código + tipo → achar consulta → filtrar agendamentos por aquele tipo → ordenar pacientes **alfabeticamente** por nome → imprimir.

> Dica de método LINQ por tarefa, sem dar a query: `Contains`/`StringComparison` (busca) · `GroupBy`+`OrderByDescending` (ranking) · `OrderBy` (histórico/filtro). Monte a chamada.
