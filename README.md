
# Explicação sobre a API e decisões ténicas 🚀

**Tecnologias utilizadas:**

*.NET 8.0* + *Angular 18*

**Links**

*Swagger*

    http://localhost:5131/swagger/index.html

*Frontend*

    http://localhost:4200/

**Rotas**

- **GET /api/herois**

  Retorna a lista de todos os heróis cadastrados, incluindo seus superpoderes.  
  Retorna 200 com lista vazia caso não existam heróis.

- **GET /api/herois/{id}**  
  Retorna um herói específico pelo seu ID, com todos os dados e superpoderes associados.  
  Retorna 404 se não encontrado.

- **POST /api/herois**  
  Cria um novo herói com os dados enviados, incluindo a associação a superpoderes existentes.  
  Valida duplicidade de nome, superpoderes válidos e data de nascimento.  
  Retorna 201 com o herói criado.

- **PUT /api/herois/{id}**  
  Atualiza um herói existente pelo ID, permitindo alterar seus dados e superpoderes.  
  Valida existência do herói, duplicidade de nome, data e superpoderes válidos.  
  Retorna 200 com os dados atualizados.

- **DELETE /api/herois/{id}**  
  Remove o herói pelo ID.  
  Retorna 200 com mensagem de sucesso ou 404 se não encontrado.

## Arquitetura em camadas 🏗️

Para garantir um código organizado e de fácil manutenção, adotei uma arquitetura em camadas, separando as responsabilidades em:

- Controllers: responsável por receber as requisições HTTP e retornar respostas.

- Services: onde está a lógica de negócio e validações centrais.

- Repositories: camada de acesso a dados, isolando a persistência da lógica do sistema.

Essa separação facilita testes unitários, evolução do código e evita acoplamento excessivo entre as partes.
## DTOs (Data Transfer Objects) 📦

Para evitar garantir o controle sobre os dados, utilizei DTOs nas requisições e respostas da API. Isso permite aplicar validações específicas, definir formatos e impedir mudanças inesperadas no modelo interno impactando os consumidores da API.
## Inversão de Dependência e Uso de Interfaces  🔄

Seguindo o princípio da inversão de dependência, um dos pilares do SOLID, implementei interfaces para os repositórios e serviços, definindo contratos claros para cada funcionalidade. Assim, os controladores e serviços dependem de abstrações (interfaces) em vez de implementações concretas.

Isso traz vários benefícios importantes:

- Facilita a troca de implementações, por exemplo para testes com mocks ou futuras alterações.

- Aumenta a testabilidade e a flexibilidade do código.

- Promove um design desacoplado e alinhado às boas práticas de engenharia de software
## Tratamento Global de Exceções com Middleware 🛡️

Implementei um middleware global para captura e tratamento centralizado de exceções. Isso assegura que erros sejam retornados com um formato padronizado e mensagens customizadas, além de evitar vazamento de detalhes internos do sistema para o cliente.
## Uso de Entity Framework Core com Banco InMemory 🛠️

Escolhi usar o banco InMemory para facilitar o desenvolvimento local e testes, evitando configuração complexa de banco real. A arquitetura está preparada para, futuramente, trocar para um banco relacional real como SQL Server ou PostgreSQL com mudanças mínimas.
# Sobre o frontend

## Angular 18 com Standalone Components ⚙️

Optei por utilizar a arquitetura mais moderna do Angular, com componentes standalone para simplificar a estrutura e reduzir dependências desnecessárias em módulos.

## Angular Material 🎨

Para garantir uma interface consistente, responsiva e visualmente agradável, escolhi o Angular Material como biblioteca de componentes UI. Ele oferece componentes prontos e acessíveis como botões, diálogos modais, inputs, selects e datepickers, facilitando o desenvolvimento e mantendo um padrão profissional.
