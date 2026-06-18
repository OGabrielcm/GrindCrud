# ROTEIRO_PROVA — Execução ágil de um CRUD sob tempo

> **O que é:** a linha de raciocínio comprimida pra atacar uma prova de CRUD em C# Console do zero, genérica (qualquer domínio). Não é teoria — é a ordem de execução + onde o tempo realmente vaza.
> **Premissa:** o esqueleto é sempre o mesmo; o que muda é o domínio (nomes, campos, regras). Velocidade vem de NÃO reinventar a forma. Pontos vêm de NÃO errar os relatórios.

---

## 0. Antes de digitar (10 min) — ler o enunciado como engenheiro

Extraia numa folha, nesta ordem:

1. **Entidades** (substantivos centrais) → uma Model cada.
2. **Campos** de cada entidade → propriedades.
3. **Identificador único** de cada uma (CRM, CPF, código…) → regra de unicidade + propriedade **imutável**.
4. **Relacionamentos** "X tem vários Y" → o Y (filho) guarda referência ao X (pai). Define a **ordem de construção: pai antes de filho.**
5. **Valores fechados** (status, tipo…) → enums.
6. **Regras de negócio**: "não pode dois iguais" (unicidade, simples ou composta) · "não pode excluir se…" (dependência).
7. **Relatórios** (verbos: buscar, rankear, ordenar, filtrar, agrupar) → liste cada um e **qual LINQ** (Contains / GroupBy / OrderBy / Where).

> Saída: lista de entidades + campos + únicos + regras + relatórios. **Só então abra o editor.** 10 min aqui economiza 1h de retrabalho.

---

## 1. Ordem de construção (de baixo pra cima — cada degrau compila antes do próximo)

```
Enums/      → tipos fechados
Models/     → construtor + props {get; private set;} + Atualizar() + ToString()
Helpers/    → Validador estático (todos os métodos de leitura)
Program.cs  → listas + menu/submenus com placeholders vazios   ← COMPILA aqui (esqueleto navegável)
CRUD entidade-pai inteiro (Cadastrar→Listar→Editar→Excluir)    ← COMPILA
Replica nos filhos
Relatórios
Teste manual ponta a ponta
```

**Regra de ouro do tempo: compila a cada entidade fechada. Nunca acumule 4 métodos sem rodar `dotnet build`.** Um erro isolado custa 30s; quatro empilhados custam 20 min de caça.

---

## 2. O CRUD-base (decore a ESPINHA, não o código)

| Operação | Espinha |
|----------|---------|
| **Cadastrar** | ler campos (Validador) → unicidade `.Any()` → buscar pai e abortar se órfão → `new` → `Add` → `[OK]` |
| **Listar** | `Count==0`? msg e `return` → `ForEach(x => WriteLine(x))` |
| **Editar** | `Count==0`? → `Listar()` → ler chave → `FirstOrDefault` → `is null`? `return` → ler campos editáveis → `Atualizar()` → `[OK]` |
| **Excluir** | `Count==0`? → `Listar()` → ler chave → `FirstOrDefault` → `is null`? `return` → tem dependente `.Any()`? `return` → `Remove` → `[OK]` |

- **Toda guarda termina em `return;`.** Guarda sem `return` não guarda nada — segue e cria o bug.
- **Chave única NÃO entra no `Atualizar()`** (editá-la quebra referências). Campo editável que também é único: re-cheque com `Any(x => x != atual && x.Campo == novo)`.
- **Campo de ciclo de vida** (status que evolui) → método próprio (`AlterarStatus`) + **opção de menu separada**, fora do `Editar`. Atributo descritivo escolhido na criação → entra no `Atualizar` normal.
- **Entidade-filho sem chave própria** (a chave é o par pai+pai) → busca por `FirstOrDefault(a => a.Pai1.Id == x && a.Pai2.Id == y)`.

---

## 3. Replicar o CRUD nos filhos — a fase onde VOCÊ mais erra

Copiar o esqueleto é 2 min. O bug é sempre **nome herdado não-renomeado**. Ao colar, troque conscientemente, nesta ordem:

1. **Tipo e lista** — `Medico`/`medicos` → `Paciente`/`pacientes`.
2. **Campos únicos** — quantos são e qual Validador de cada (um tinha 1; o próximo pode ter 2).
3. **Ordem dos argumentos no `new`** — a pegadinha nº 1. O construtor não avisa se você trocou a ordem de dois `string`.
4. **Dependência do Excluir** — qual lista aponta pra essa entidade? (filho = folha, sem checagem).

> **Regra de ouro do bug:** depois de colar, **leia linha por linha caçando nome herdado.** `cpf` onde era `numeroPlano`, `ValidarCpf` onde era `ValidarTexto`. O esqueleto copia sozinho; os nomes não se renomeiam sozinhos.

---

## 4. Relatórios — é AQUI que a prova dá nota (não deixe pro fim sem tempo)

Não têm esqueleto pronto de propósito. Padrão de todos: **guarda de vazio → (buscar âncora) → LINQ → tratar resultado vazio → imprimir.**

| Verbo no enunciado | LINQ | Detalhe que derruba ponto |
|--------------------|------|---------------------------|
| "buscar por nome (parte)" | `Where(x => x.Nome.Contains(termo, StringComparison.OrdinalIgnoreCase))` | **case-insensitive** — sem isso, "ana" não acha "Ana" |
| "ranking / quantos por…" | `GroupBy(...).Select(g => new {g.Key, Total=g.Count()}).OrderByDescending(x => x.Total)` | direção: **decrescente** |
| "histórico / linha do tempo" | `Where(...).OrderBy(x => x.Data)` | direção: **crescente** por data |
| "filtrar por X, em ordem" | `Where(...).Select(...).OrderBy(x => x.Nome)` | ordenação **alfabética** que ele pediu |

> Erros que mais custam: ordenação na direção errada, esquecer case-insensitive, não tratar coleção vazia. Releia o verbo do enunciado — ele diz a direção.

---

## 5. Disciplina de escopo (seu padrão de erro: superestimar)

- **Só valide o que o enunciado pede.** Não invente regra de transição ("status X não volta pra Y") se o texto não pediu — é código a mais pra dar errado e zero ponto.
- **Não crie classe/Service** se uma lista + `.Any()` no `Program.cs` resolve.
- **Não otimize** (dicionário, índice) num CRUD de prova com 5 registros em memória.

---

## 6. Orçamento de tempo (prova de ~8h — folgado, o risco é dispersar, não faltar)

| Fase | Alvo | Gate |
|------|------|------|
| Ler enunciado + extrair (passo 0) | 15 min | folha preenchida |
| Enums + Models + Validador | 1h30 | **compila** |
| Program.cs esqueleto (listas + menus vazios) | 30 min | **roda e navega** |
| 1º CRUD inteiro (pai) | 1h | **compila + testa as 4 ops** |
| Replicar nos demais | 1h por entidade | compila a cada um |
| Relatórios | 1h30 | testa cada um com dado real |
| Teste ponta a ponta + folga | resto | cadastra→edita→relatório→exclui |

> Com 8h isso sobra tempo. **Não use a folga pra inventar feature** — use pra reler enunciado e testar caso de borda (lista vazia, chave que não existe, valor 0).

---

## 7. Checklist final (antes de entregar)

- [ ] `dotnet build` = 0 errors.
- [ ] Toda guarda tem `return;`.
- [ ] Nenhum identificador único dentro de `Atualizar()`.
- [ ] Excluir checa dependência; Cadastrar aborta filho órfão.
- [ ] Menu volta ao loop em entrada inválida (`default`), sai sem travar.
- [ ] Cada relatório: ordenação na direção do enunciado + case-insensitive + trata vazio.
- [ ] Li cada CRUD replicado linha por linha caçando nome herdado.
