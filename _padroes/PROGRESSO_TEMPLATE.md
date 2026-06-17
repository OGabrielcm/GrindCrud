# PROGRESSO — <NOME DO PROJETO>

> **Estado** deste projeto: o que já existe, o que falta e as decisões específicas do domínio.
> Itere neste arquivo a cada etapa concluída. (Descartável: vale só para este projeto.)
>
> Método e referência de código moram fora daqui (symlinks na raiz do projeto):
> - **Como atacar a atividade / ritmo** → `FLUXO_ATIVIDADE.md`
> - **Esqueleto de cada operação + assinaturas do `Validador`** → `CRUD_GUIA.md`
>
> Setup do projeto novo:
> ```
> cp ../_padroes/PROGRESSO_TEMPLATE.md ./PROGRESSO.md
> ln -s ../_padroes/CRUD_GUIA.md ./CRUD_GUIA.md
> ln -s ../_padroes/FLUXO_ATIVIDADE.md ./FLUXO_ATIVIDADE.md
> ```

---

## Regras específicas do domínio

**Métodos obrigatórios em cada Model:**

| Model | Métodos além do construtor |
|-------|---------------------------|
| `<Entidade>` | `Atualizar(...)`, `ToString()` |

**Unicidade (inline via `.Any()`):** `<campos únicos>`.
**Dependência antes de excluir:** `<quem aponta para quem>`.
**Imutáveis** (não entram no `Atualizar()`): `<identificadores>`.

---

## Checklist do Projeto

### ✅ Concluído

- [ ] Enums
- [ ] Models
- [ ] `Program.cs`: listas + menu + submenus placeholder

---

### 🔲 Próximas etapas (em ordem)

#### Etapa 0 — Helper de validação
- [ ] `Helpers/Validador.cs`: métodos de leitura validada (ver `CRUD_GUIA.md` §6)

#### Etapa 1 — Métodos nos Models
- [ ] `Atualizar()` / `ToString()` em cada entidade

#### Etapa 2+ — CRUD por entidade (pai antes de filho)
- [ ] Cadastrar / Listar / Editar / Excluir

#### Etapa final — Funcionalidades obrigatórias
- [ ] Buscas, rankings, filtros, ordenações do enunciado

---

## Decisões técnicas registradas

| Decisão | Motivo |
|--------|--------|
| | |
