# Desafio de Desenvolvimento Backend: Mesha
Bem-vindo ao Desafio de Desenvolvimento Backend! Este desafio foi projetado para avaliar suas habilidades no desenvolvimento de APIs RESTful utilizando tecnologias modernas.

# Descrição do Desafio
O objetivo deste desafio é criar uma API RESTful para um sistema de gerenciamento de tarefas. A API deve permitir que os clientes realizem operações CRUD (Create, Read, Update, Delete) em tarefas, além de incluir as seguintes funcionalidades:

- Autenticação e Autorização: Implementar um sistema de autenticação para proteger as rotas da API e garantir que apenas usuários autenticados possam realizar operações.
- Validação de Dados: Validar os dados de entrada para garantir a consistência e integridade dos dados.
- Paginação: Implementar a paginação para lidar com grandes volumes de dados retornados em uma única chamada.
- Documentação da API: Documentar a API utilizando uma ferramenta como Swagger ou Postman para facilitar o entendimento e o uso por parte dos desenvolvedores consumidores.

# Tecnologias Recomendadas
- Framework: .NET Core ou .NET 5 (escolha um)
- Banco de Dados: SQL Server, MySQL, PostgreSQL ou MongoDB (escolha um)
- ORM: Entity Framework Core (para SQL Server, MySQL, PostgreSQL) ou MongoDB Driver (para MongoDB)
- Autenticação e Autorização: JWT (JSON Web Tokens) com ASP.NET Core Identity ou IdentityServer4
-  Documentação da API: Swagger ou Postman

# Requisitos Técnicos
- A API deve ser desenvolvida utilizando .NET Core ou .NET 5 e C#.
- O uso de ORM é fortemente encorajado para lidar com a interação com o banco de dados.
- Implemente o padrão Repository para isolar a lógica de acesso aos dados.
- Utilize boas práticas de segurança, como hashing de senhas e proteção contra ataques de injeção de SQL.
- A documentação da API deve ser detalhada e fácil de entender.

# Critérios de Avaliação
Sua solução será avaliada com base nos seguintes critérios:

- Adesão aos requisitos técnicos e funcionalidades solicitadas.
- Qualidade do código, incluindo legibilidade, organização e boas práticas de desenvolvimento.
- Segurança da API, incluindo autenticação e proteção contra vulnerabilidades.
- Documentação detalhada e fácil de entender da API.
- Eficiência e escalabilidade da solução.
- Dúvidas e Perguntas
- Se tiver dúvidas sobre o desafio, abra uma issue neste repositório e ficaremos felizes em ajudar esclarecê-las.

# Execução
1. Primeiramente rode o comando para gerar o banco de dados:
  - dotnet ef database update -p TodoList.Infra -s TodoList.Api
2. Em seguida execute o projeto através do vs studio
