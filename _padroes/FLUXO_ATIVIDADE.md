# FLUXO_ATIVIDADE — Como atacar uma atividade de CRUD do zero

> **O que este doc é:** o **processo** padronizado para resolver qualquer prova/atividade de CRUD em C# Console — a ordem de construção e o ritmo de trabalho.
> **O que NÃO é:** referência de código por operação (isso é `CRUD_GUIA.md`) nem o checklist do projeto atual (isso é `PROGRESSO.md`).
>
> Objetivo: praticar ao máximo. Cada atividade nova é resolvida na mesma ordem, para a forma virar automática.

---

## 1. Ordem de construção (sempre esta)

Construa de baixo (dados) para cima (interface). Cada degrau só começa quando o anterior compila.

```
1. Ler o enunciado e extrair as ENTIDADES e os RELACIONAMENTOS
2. Enums/         → tipos fechados do domínio (status, tipos)
3. Models/        → uma classe por entidade (construtor + props private set)
4. Helpers/       → Validador estático (leitura validada do console)
5. Program.cs     → listas em memória + menu/submenus com métodos placeholder
6. Métodos dos Models  → Atualizar() / AlterarStatus() / ToString()
7. CRUD por entidade   → na ordem das dependências (pai antes de filho)
8. Relatórios / funcionalidades obrigatórias
9. Teste manual ponta a ponta
```

> **Por que pai antes de filho:** Consulta depende de Médico; Agendamento depende de Paciente + Consulta. Não dá pra cadastrar uma consulta se não há médico pra vincular. Implemente Médico e Paciente primeiro.

---

## 2. Passo 1 detalhado — ler o enunciado como engenheiro

Antes de qualquer código, extraia do texto:

| Pergunta ao enunciado | O que vira no código |
|-----------------------|----------------------|
| Quais são os substantivos centrais? | as **Models** |
| Quais campos cada um tem? | as **propriedades** |
| Qual campo é "único"/"identificador"? | regra de **unicidade** + propriedade **imutável** |
| "X pode ter vários Y" | relacionamento 1–N → o N guarda referência ao 1 |
| Quais valores são fechados (lista fixa)? | **enums** |
| "não pode ter dois ... iguais" | regra de **unicidade composta** |
| "não pode excluir se ..." | regra de **dependência** |
| Verbos de relatório (listar, buscar, rankear, ordenar) | **funcionalidades** + qual LINQ |

Saída deste passo: uma lista de entidades, campos, identificadores únicos e regras. Só então abra o editor.

---

## 3. Ritmo de trabalho (loop pedagógico)

Trabalhamos **uma etapa por vez**. O ciclo de cada etapa:

```
[próxima etapa]  →  você explica o CONCEITO  →  eu escrevo o código
       ↑                                              ↓
[avança]  ←  revisão: aponto desvios, NÃO entrego pronto  ←  [eu mostro]
```

Regras do ritmo:
- **Não pulo etapa.** Só revelo a próxima quando a atual compila e está revisada.
- **Conceito antes de código.** Cada decisão (composição, encapsulamento, unicidade) é explicada — saber *por quê* importa mais que digitar.
- **Revisão sem gabarito.** Desvio é apontado com a direção do conserto; o código quem corrige é você.
- **Compila a cada etapa.** Nunca acumular 4 funcionalidades sem rodar.

---

## 4. Checkpoints de qualidade por etapa

Antes de marcar uma etapa como concluída, confira:

**Models**
- [ ] Propriedades `private set` (não `public set` solto)?
- [ ] Identificador único é imutável (sem entrar no `Atualizar()`)?
- [ ] `ToString()` mostra o objeto de forma legível?

**CRUD**
- [ ] Cadastrar valida formato (Validador) **e** unicidade (`.Any()`)?
- [ ] Editar/Excluir buscam antes e tratam "não encontrado"?
- [ ] Excluir checa dependência antes de remover?
- [ ] Cadastro com dependência aborta se o pai não existe?

**Menu**
- [ ] Loop não quebra com entrada inválida (volta ao menu)?
- [ ] Toda opção tem `case`; `default` trata o resto?
- [ ] Dá pra navegar e sair sem travar?

**Relatórios**
- [ ] Ordenação na direção que o enunciado pede (crescente/decrescente/alfabética)?
- [ ] Busca textual é case-insensitive quando exigido?
- [ ] Trata coleção vazia?

---

## 5. Armadilhas frequentes (anti-checklist)

- ❌ Criar filho órfão (consulta sem médico) — sempre buscar e abortar.
- ❌ Editar o identificador único — quebra referências.
- ❌ Condição de validação impossível (`Length > 11 && Length < 11`) — teste a lógica booleana.
- ❌ Esquecer `StringComparison.OrdinalIgnoreCase` em comparação de CRM/código.
- ❌ Acumular muitas funcionalidades antes de compilar.
- ❌ Validação de formato espalhada inline em vez de no `Validador`.

---

## 6. Mapa dos três documentos

| Preciso de... | Vou em... |
|---------------|-----------|
| Onde estou neste projeto / o que falta | `PROGRESSO.md` |
| Como se escreve um Cadastrar/Editar/Excluir + assinatura do Validador | `CRUD_GUIA.md` |
| Por onde começo uma atividade nova / qual o ritmo | **este (`FLUXO_ATIVIDADE.md`)** |
