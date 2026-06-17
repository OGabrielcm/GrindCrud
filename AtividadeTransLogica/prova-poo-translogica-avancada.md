# Prova – Programação Orientada a Objetos: Sistema de Gestão de Transportadora TransLógica (Nível Avançado)

## Regra de negócio: Transportadora TransLógica

A TransLógica é uma transportadora de médio porte que realiza viagens com roteiros de várias paradas para entregar cargas de diferentes clientes, partindo de diferentes filiais pelo país. Com o crescimento da operação, a administração decidiu desenvolver um sistema interno mais robusto, capaz de controlar não apenas o cadastro básico de motoristas e clientes, mas também a consistência operacional das viagens, dos veículos utilizados e das entregas.

A empresa conta com um quadro de **motoristas** cadastrados. Cada motorista possui uma CNH única — como "12345678900" —, um nome completo e uma categoria de habilitação, que pode ser **A**, **B**, **C**, **D** ou **E**. Um motorista pode ser responsável por várias viagens ao longo do tempo, mas não pode estar alocado em duas viagens cujos períodos de execução se sobreponham.

As **viagens** são a entidade central do sistema. Cada viagem possui um código único — por exemplo, "VIA04521" —, um motorista responsável, os dados do veículo utilizado (placa, modelo e capacidade máxima de peso suportada, em quilogramas), o nome da filial de origem, uma data e hora de saída e uma quilometragem inicial. Quando a viagem é concluída, registram-se também a data de chegada e a quilometragem final, que deve ser sempre maior que a quilometragem inicial, assim como a data de chegada deve ser sempre posterior à data de saída. Um mesmo veículo, identificado pela placa, também não pode estar alocado em duas viagens com período de execução sobreposto. Uma viagem pode ter um **roteiro de paradas**: cada parada indica a cidade visitada, a ordem sequencial dentro da viagem — não podendo haver duas paradas com a mesma ordem em uma mesma viagem —, e a quilometragem parcial acumulada até aquele ponto, que deve ser sempre crescente ao longo do roteiro.

Os **clientes** da transportadora são cadastrados com nome completo, documento (CPF ou CNPJ) único e telefone para contato. Um cliente pode despachar várias cargas ao longo do tempo.

A associação entre um cliente e uma viagem é registrada como uma **carga**. Cada carga possui um código de rastreio único — como "CRG04521" —, um peso (em quilogramas), um valor declarado, um tipo, que pode ser **Padrão**, **Frágil** ou **Perigosa**, e um status, que pode ser **Pendente**, **Em Trânsito**, **Entregue** ou **Cancelada**. A entrega de uma carga deve ser destinada a exatamente um local: ou uma parada específica de alguma viagem, ou um endereço informado diretamente pelo cliente — nunca os dois ao mesmo tempo, nem nenhum dos dois. Além disso, a soma dos pesos de todas as cargas vinculadas a uma mesma viagem não pode exceder a capacidade de peso do veículo utilizado nessa viagem.

O sistema precisa ser capaz de, a qualquer momento, listar todos os clientes, viagens e motoristas cadastrados. Também deve ser possível buscar um cliente pelo nome — mesmo que a busca seja parcial, o sistema deve retornar todos os clientes cujo nome contenha o trecho digitado, sem distinção entre maiúsculas e minúsculas.

Uma funcionalidade essencial para a operação da transportadora é o **Ranking de Cargas por Viagem**: dado o código de uma viagem, o sistema deve exibir quantos clientes despacharam carga naquela viagem, detalhando a quantidade por tipo de carga. Os grupos devem ser exibidos em ordem decrescente de quantidade de clientes.

O sistema também deve exibir o **Roteiro da Viagem**: dado o código de uma viagem, o sistema lista as paradas em ordem sequencial, indicando a cidade, a quilometragem parcial, a data de chegada (quando houver) e quais cargas estão programadas para serem entregues naquela parada.

Outra funcionalidade obrigatória é o **Relatório de Ocupação do Veículo**: dado o código de uma viagem, o sistema exibe o peso total já comprometido pelas cargas vinculadas, a capacidade máxima do veículo utilizado e o percentual de ocupação resultante.

O sistema também deve oferecer um **Histórico de Cargas por Cliente**: ao selecionar um cliente, o sistema exibe todas as cargas que ele despachou, com o código da carga, motorista responsável pela viagem, data de saída da viagem, tipo de carga transportada, status da carga e o local de entrega (cidade da parada ou endereço direto). As cargas devem ser exibidas em ordem cronológica crescente pela data de saída da viagem.

Por fim, a administração precisa filtrar clientes que despacharam carga em uma viagem específica por tipo de carga: dado o código de uma viagem e um tipo de carga, o sistema exibe todos os clientes que despacharam aquele tipo de carga, ordenados alfabeticamente pelo nome.

Todo o funcionamento do sistema se dá por meio de um menu interativo no console, que permanece ativo até que o usuário escolha explicitamente a opção de encerramento.

---

## Regras de Validação Adicionais

- O peso total das cargas vinculadas a uma viagem não pode exceder a capacidade de peso do veículo utilizado.
- A quilometragem final de uma viagem deve ser maior que a quilometragem inicial.
- A data de chegada de uma viagem deve ser posterior à data de saída.
- A quilometragem parcial de cada parada deve ser maior que a da parada anterior dentro da mesma viagem.
- Não pode haver duas paradas com a mesma ordem sequencial em uma mesma viagem.
- Uma carga deve ter exatamente um destino de entrega: uma parada de viagem ou um endereço direto, nunca os dois nem nenhum.
- Um motorista ou um veículo não pode ser alocado em duas viagens com período de execução sobreposto.

---

## Objetivo

Desenvolver um sistema de gestão de transportadora em console, aplicando conceitos de:

- Programação Orientada a Objetos (POO)

---

## Etapas da Atividade

### Etapa 1 – Desenvolvimento do Sistema (CRUD)

O sistema deve ser feito em **C# (Console)** e conter:

**CRUD completo para:**
- Clientes (Criar, Editar, Excluir, Listar)
- Motoristas (Criar, Editar, Excluir, Listar)
- Viagens, incluindo dados do veículo, da filial de origem e o roteiro de paradas (Criar, Editar, Excluir, Listar)
- Cargas (Criar, Editar, Excluir, Listar)

---

## Funcionalidades Obrigatórias

### Busca de Clientes
- Busca por nome (parcial)
- Busca case insensitive

---

### Ranking de Cargas por Viagem
- Dado o código de uma viagem, exibir a quantidade de clientes que despacharam carga
- Detalhar a quantidade por tipo de carga
- Ordenar os grupos em ordem decrescente de quantidade de clientes

---

### Roteiro da Viagem
- Dado o código de uma viagem, listar as paradas em ordem sequencial
- Exibir cidade, quilometragem parcial e data de chegada de cada parada
- Exibir quais cargas estão programadas para entrega em cada parada

---

### Relatório de Ocupação do Veículo
- Dado o código de uma viagem, somar o peso de todas as cargas vinculadas
- Exibir a capacidade máxima do veículo utilizado
- Calcular e exibir o percentual de ocupação resultante

---

### Histórico de Cargas por Cliente
Para cada carga que o cliente despachou:
- Código da carga
- Motorista responsável pela viagem
- Data de saída da viagem
- Tipo de carga transportada
- Status da carga
- Local de entrega (cidade da parada ou endereço direto)
- Ordenar em ordem cronológica crescente pela data de saída da viagem

---

### Filtro por Tipo de Carga
- Dado o código de uma viagem e um tipo de carga, exibir todos os clientes que despacharam carga daquele tipo
- Ordenar alfabeticamente pelo nome do cliente

---

## Interface

- Menu interativo no console
- Sistema deve continuar rodando até o usuário sair
- Navegação clara (sem travar ou quebrar fluxo)

---

## Entrega

- Código fonte completo
- O sistema deve compilar e executar corretamente
