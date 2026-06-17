# Prova – Programação Orientada a Objetos: Sistema de Streaming de Música SoundStream

## Regra de negócio: Plataforma SoundStream

A SoundStream é uma plataforma de streaming de música de médio porte que processa milhares de reproduções mensalmente entre diversos gêneros musicais. Com o crescimento da operação, a administração decidiu desenvolver um sistema interno para organizar e consultar informações sobre músicas, usuários e artistas.

A plataforma conta com um corpo de **artistas** cadastrados. Cada artista possui um código de artista único — como "ART00231" —, um nome e um gênero musical. Um artista pode ser responsável por várias músicas ao longo do tempo.

As **músicas** são a entidade central do sistema. Cada música possui um código único — por exemplo, "MUS04521" —, um álbum ao qual pertence, uma data e hora de lançamento e uma duração estimada em segundos. Toda música deve estar obrigatoriamente vinculada a um artista responsável, sem o qual ela não pode ser cadastrada no sistema. Além disso, cada música possui um status, que pode ser: **Em Produção**, **Lançada**, **Em Destaque** ou **Removida**.

Os **usuários** da plataforma são cadastrados com nome completo, data de nascimento, e-mail único e nome de usuário (username), que também deve ser único no sistema. Um usuário pode possuir várias curtidas ao longo do tempo.

A associação entre um usuário e uma música é registrada como uma **curtida**. Ao confirmar a curtida, o sistema registra o tipo de dispositivo utilizado pelo usuário — que pode ser **Celular**, **Desktop** ou **Smart Speaker** —, o tempo de reprodução acumulado (em segundos) até o momento da curtida e a data da curtida. Um usuário não pode curtir a mesma música duas vezes.

O sistema precisa ser capaz de, a qualquer momento, listar todos os usuários, músicas e artistas cadastrados. Também deve ser possível buscar um usuário pelo nome — mesmo que a busca seja parcial, o sistema deve retornar todos os usuários cujo nome contenha o trecho digitado, sem distinção entre maiúsculas e minúsculas.

Uma funcionalidade essencial para a operação da plataforma é o **Ranking de Curtidas por Música**: dado o código de uma música, o sistema deve exibir quantos usuários curtiram aquela música, detalhando a quantidade por tipo de dispositivo. Os grupos devem ser exibidos em ordem decrescente de quantidade de usuários.

O sistema também deve oferecer um **Histórico de Curtidas por Usuário**: ao selecionar um usuário, o sistema exibe todas as músicas que ele curtiu, com o código da música, artista responsável, data de lançamento, tipo de dispositivo utilizado na curtida e o status da música. As músicas devem ser exibidas em ordem cronológica crescente pela data de lançamento.

Por fim, a administração precisa filtrar usuários que curtiram uma música específica por tipo de dispositivo: dado o código de uma música e um tipo de dispositivo, o sistema exibe todos os usuários que curtiram naquele dispositivo, ordenados alfabeticamente pelo nome.

Todo o funcionamento do sistema se dá por meio de um menu interativo no console, que permanece ativo até que o usuário escolha explicitamente a opção de encerramento.

---

## Objetivo

Desenvolver um sistema de gestão de streaming de música em console, aplicando conceitos de:

- Programação Orientada a Objetos (POO)

---

## Etapas da Atividade

### Etapa 1 – Desenvolvimento do Sistema (CRUD)

O sistema deve ser feito em **C# (Console)** e conter:

**CRUD completo para:**
- Usuários (Criar, Editar, Excluir, Listar)
- Artistas (Criar, Editar, Excluir, Listar)
- Músicas (Criar, Editar, Excluir, Listar)
- Curtidas (Criar, Editar, Excluir, Listar)

---

## Funcionalidades Obrigatórias

### Busca de Usuários
- Busca por nome (parcial)
- Busca case insensitive

---

### Ranking de Curtidas por Música
- Dado o código de uma música, exibir a quantidade de usuários que curtiram
- Detalhar a quantidade por tipo de dispositivo
- Ordenar os grupos em ordem decrescente de quantidade de usuários

---

### Histórico de Curtidas por Usuário
Para cada música que o usuário curtiu:
- Código da música
- Artista responsável
- Data de lançamento
- Tipo de dispositivo utilizado na curtida
- Status da música
- Ordenar em ordem cronológica crescente pela data de lançamento

---

### Filtro por Tipo de Dispositivo
- Dado o código de uma música e um tipo de dispositivo, exibir todos os usuários que curtiram naquele tipo
- Ordenar alfabeticamente pelo nome do usuário

---

## Interface

- Menu interativo no console
- Sistema deve continuar rodando até o usuário sair
- Navegação clara (sem travar ou quebrar fluxo)

---

## Entrega

- Código fonte completo
- O sistema deve compilar e executar corretamente
