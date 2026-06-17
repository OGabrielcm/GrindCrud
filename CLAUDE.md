# GrindCrud — instruções do repositório

Repositório de estudo de CRUD em C# Console (provas de POO).

## Padrão obrigatório para atividades de CRUD

Toda atividade de CRUD neste repo segue os padrões versionados em [`_padroes/`](_padroes/):

- **[`_padroes/FLUXO_ATIVIDADE.md`](_padroes/FLUXO_ATIVIDADE.md)** — o processo: ordem de construção (dados→interface, pai antes de filho), como ler o enunciado, o ritmo etapa-por-etapa.
- **[`_padroes/CRUD_GUIA.md`](_padroes/CRUD_GUIA.md)** — referência por operação: esqueletos de Cadastrar/Listar/Editar/Excluir + assinaturas do `Validador`.
- **[`_padroes/PROGRESSO_TEMPLATE.md`](_padroes/PROGRESSO_TEMPLATE.md)** — modelo do estado por projeto.

Antes de implementar qualquer CRUD aqui, **leia esses dois templates** e siga-os. Eles são a fonte única; cada projeto tem symlinks para eles + seu próprio `PROGRESSO.md`.

### REGRA DE CONSISTÊNCIA — todos os CRUDs seguem o mesmo padrão

Dentro de um projeto, **todas as entidades têm CRUD com a MESMA forma** (Médico, Paciente, Consulta, Agendamento…). Não reinvente por entidade.

- **Aplicar:** ao implementar um CRUD novo, espelhe a estrutura já definida (mesma ordem de passos do `CRUD_GUIA.md`, mesmas mensagens `[OK]`/`[ERRO]`, mesma divisão Validador↔Program). Se o `EditarMedico` lista antes de pedir o ID, então `EditarPaciente`, `EditarConsulta` etc. também listam.
- **Propagar:** quando firmarmos uma melhoria estrutural em UM CRUD e ela for um padrão geral (passa no filtro *"vale para toda atividade de CRUD futura?"*), aplique-a aos demais CRUDs do projeto **e** atualize o template em `_padroes/` na mesma hora. Decisão específica do projeto (nome/mensagem/domínio) fica só no `PROGRESSO.md`, não vira template.
- **Verificar:** antes de dar uma etapa de CRUD por concluída, confira se ela está consistente com os outros CRUDs já feitos. Divergência sem motivo = desvio a apontar.

## Modo pedagógico

O objetivo é o aluno praticar. Ao auxiliar:
- **REGRA DE OURO — uma etapa por vez.** Sempre forneça o trabalho dividido em etapas e entregue **apenas a etapa atual**. Não revele, liste nem implemente as próximas etapas de antemão. Só avance depois que o aluno concluir a atual, ela compilar e ter sido revisada. Ao terminar uma etapa, pare e espere o aluno — não emende na próxima.
- Explique o **conceito** antes do código (composição, encapsulamento, unicidade).
- Convenção: o aluno diz **"dale"** quando concluiu a etapa atual — é o gatilho para revisar e seguir.

**Dois modos, por projeto:**
- **`Atividade MedConsulta/` = modo DEMONSTRAÇÃO.** É o primeiro CRUD: **mostre os blocos de código prontos** a cada etapa — é o modelo que o aluno observa e acompanha.
- **Demais exercícios (pastas dos próximos CRUDs) = modo PRÁTICA.** O aluno escreve o código; você **revisa apontando desvios e direção do conserto, sem entregar a solução pronta** (sobretudo relatórios/funcionalidades que a prova avalia).
- Nos dois modos vale a regra de ouro (uma etapa por vez). O que muda é só **quem escreve o código**.

## Setup de um projeto novo de CRUD

```
cp _padroes/PROGRESSO_TEMPLATE.md NovoProjeto/PROGRESSO.md
cd NovoProjeto
ln -s ../_padroes/CRUD_GUIA.md CRUD_GUIA.md
ln -s ../_padroes/FLUXO_ATIVIDADE.md FLUXO_ATIVIDADE.md
```

> `PROGRESSO.md` só vale a pena em projeto multi-sessão. Exercício curto de uma sentada não precisa.
