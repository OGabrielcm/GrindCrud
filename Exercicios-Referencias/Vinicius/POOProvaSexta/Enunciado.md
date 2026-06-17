# Prova – Programação Orientada a Objetos: Sistema de Gestão de Consultas Médicas MedConsulta

## Regra de negócio: Clínica MedConsulta

A Clínica MedConsulta é uma clínica médica de médio porte que realiza centenas de atendimentos mensalmente em diversas especialidades. Com o crescimento da operação, a administração decidiu desenvolver um sistema interno para organizar e consultar informações sobre consultas, pacientes e médicos.

A clínica conta com um corpo de **médicos** cadastrados. Cada médico possui um número de registro no Conselho Regional de Medicina (CRM) único — como "CRM12345" —, um nome e uma especialidade. Um médico pode ser responsável por várias consultas ao longo do tempo.

As **consultas** são a entidade central do sistema. Cada consulta possui um código único — por exemplo, "CONS0512" —, um local de atendimento, uma data e hora previstas e uma duração estimada em minutos. Toda consulta deve estar obrigatoriamente vinculada a um médico responsável, sem o qual ela não pode ser cadastrada no sistema. Além disso, cada consulta possui um status, que pode ser: **Pendente**, **Confirmada**, **Realizada** ou **Cancelada**.

Os **pacientes** atendidos pela clínica são cadastrados com nome completo, data de nascimento, CPF único e número da carteirinha do plano de saúde, que também deve ser único no sistema. Um paciente pode possuir vários agendamentos ao longo do tempo.

A associação entre um paciente e uma consulta é registrada como um **agendamento**. Ao confirmar o agendamento, o sistema registra o tipo de atendimento escolhido pelo paciente — que pode ser **Presencial**, **Telemedicina** ou **Procedimento Complexo** —, o valor cobrado pelo atendimento e a data de confirmação do agendamento. Um paciente não pode ter dois agendamentos na mesma consulta.

O sistema precisa ser capaz de, a qualquer momento, listar todos os pacientes, consultas e médicos cadastrados. Também deve ser possível buscar um paciente pelo nome — mesmo que a busca seja parcial, o sistema deve retornar todos os pacientes cujo nome contenha o trecho digitado, sem distinção entre maiúsculas e minúsculas.

Uma funcionalidade essencial para a operação da clínica é o **Ranking de Agendamentos por Consulta**: dado o código de uma consulta, o sistema deve exibir quantos pacientes estão agendados naquela consulta, detalhando a quantidade por tipo de atendimento. Os grupos devem ser exibidos em ordem decrescente de quantidade de pacientes.

O sistema também deve oferecer um **Histórico de Consultas por Paciente**: ao selecionar um paciente, o sistema exibe todas as consultas em que ele possui agendamento registrado, com o código da consulta, médico responsável, data prevista, tipo de atendimento em que foi agendado e o status da consulta. As consultas devem ser exibidas em ordem cronológica crescente pela data prevista.

Por fim, a administração precisa filtrar pacientes de uma consulta específica por tipo de atendimento: dado o código de uma consulta e um tipo de atendimento, o sistema exibe todos os pacientes daquele tipo naquela consulta, ordenados alfabeticamente pelo nome.

Todo o funcionamento do sistema se dá por meio de um menu interativo no console, que permanece ativo até que o usuário escolha explicitamente a opção de encerramento.

---

## Objetivo

Desenvolver um sistema de gestão de consultas médicas em console, aplicando conceitos de:

- Programação Orientada a Objetos (POO)

---

## Etapas da Atividade

### Etapa 1 – Desenvolvimento do Sistema (CRUD)

O sistema deve ser feito em **C# (Console)** e conter:

**CRUD completo para:**
- Pacientes (Criar, Editar, Excluir, Listar)
- Médicos (Criar, Editar, Excluir, Listar)
- Consultas (Criar, Editar, Excluir, Listar)
- Agendamentos (Criar, Editar, Excluir, Listar)

---

## Funcionalidades Obrigatórias

### Busca de Pacientes
- Busca por nome (parcial)
- Busca case insensitive

---

### Ranking de Agendamentos por Consulta
- Dado o código de uma consulta, exibir a quantidade de pacientes agendados
- Detalhar a quantidade por tipo de atendimento
- Ordenar os grupos em ordem decrescente de quantidade de pacientes

---

### Histórico de Consultas por Paciente
Para cada consulta em que o paciente possui agendamento:
- Código da consulta
- Médico responsável
- Data prevista
- Tipo de atendimento em que foi agendado
- Status da consulta
- Ordenar em ordem cronológica crescente pela data prevista

---

### Filtro por Tipo de Atendimento
- Dado o código de uma consulta e um tipo de atendimento, exibir todos os pacientes daquele tipo naquela consulta
- Ordenar alfabeticamente pelo nome do paciente

---

## Interface

- Menu interativo no console
- Sistema deve continuar rodando até o usuário sair
- Navegação clara (sem travar ou quebrar fluxo)

---

## Entrega

- Código fonte completo
- O sistema deve compilar e executar corretamente