# GrindCrud

Repositório de estudo de CRUD em C# Console — atividades e provas de POO.

## Estrutura

```
GrindCrud/
├── _padroes/               # Guias e templates reutilizáveis em todo repo
│   ├── FLUXO_ATIVIDADE.md  # Processo: ordem de construção de um CRUD do zero
│   ├── CRUD_GUIA.md        # Referência por operação (Cadastrar/Listar/Editar/Excluir)
│   └── PROGRESSO_TEMPLATE.md
├── Atividade MedConsulta/  # CRUD de médicos e consultas (em andamento)
├── AtividadeSoundstream/   # Enunciado de prova — Soundstream
├── AtividadeTransLogica/   # Enunciado de prova — TransLogica Avançada
└── Exercicios-Referencias/ # Exercícios e códigos de referência por aluno
```

## Como usar os padrões

Todo projeto de CRUD novo segue o mesmo fluxo:

1. Leia `_padroes/FLUXO_ATIVIDADE.md` — define a **ordem** de construção (dados → interface, pai antes de filho).
2. Consulte `_padroes/CRUD_GUIA.md` enquanto implementa — esqueletos de cada operação e assinaturas do `Validador`.
3. Copie o template de progresso para o novo projeto:

```bash
cp _padroes/PROGRESSO_TEMPLATE.md NovoProjeto/PROGRESSO.md
cd NovoProjeto
ln -s ../_padroes/CRUD_GUIA.md CRUD_GUIA.md
ln -s ../_padroes/FLUXO_ATIVIDADE.md FLUXO_ATIVIDADE.md
```

## Stack

- C# (.NET Console Application)
- Armazenamento em memória (`List<T>`)
- Sem banco de dados — foco em POO pura