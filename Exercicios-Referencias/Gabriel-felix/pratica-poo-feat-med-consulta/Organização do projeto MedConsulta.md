# Organização do projeto MedConsulta

## 1. Médico

- CRM - único - "CRM12345"
- Nome
- Especialidade (Enum)

> O Médico pode ter várias consultas ao longo do tempo

## 2. Consultas

- Código único - "CONS0512"
- Local de atendimento (Enum)
- Data e hora previstas 
- Duração em Minutos
- Status (Enum) - Pendente, Confirmada, Realizada ou Cancelada.

> Toda Consulta deve ser vinculda a um Médico, sem um Médico a Consulta não pode ser cadastrada

## 3. Paciente

- Nome
- DataNascimento
- Cpf único
- Número da carteirinha do plano de saúde - único

> O Paciente pode ter vários atendimentos ao longo do tempo 

## 4. Agendamento

- Tipo de atendimento (Enum) - Presencial, Telemedicina ou Procedimento Complexo
- Valor Cobrado
- Data da Confirmação do Agendamento

> Associação de Paciente com Consulta
>> O Paciente não pode ter dois Agendamentos para a mesma Consulta
