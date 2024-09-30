# Dev Writer - API Backend
# Dev Writer - API Backend

Este repositório contém a API backend do projeto **Dev Writer**, uma plataforma de blogs desenvolvida com **ASP.NET Core** e **SQL Server**. O backend fornece serviços RESTful para criar, editar, e gerenciar publicações, categorias, comentários e usuários.

## Funcionalidades

A API do Dev Writer oferece as seguintes funcionalidades:

- [ ] **Gerenciamento de Usuários**: Cadastro, autenticação (token-based), e gerenciamento de perfis de usuários.
- [x] **Postagens**: Criação, edição, exclusão e visualização de postagens.
- [ ] **Comentários**: Permite aos usuários comentar em postagens e visualizar comentários.
- [x] **Categorias**: Criação e gerenciamento de categorias para organizar as postagens.
- [x] **Imagens**: Criação e gerenciamento das imagens feitas upload.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework para construção da API RESTful.
- **Entity Framework Core**: Para mapeamento objeto-relacional (ORM) e acesso ao banco de dados.
- **SQL Server**: Banco de dados utilizado para persistência de dados.

## Requisitos

- **.NET 8 SDK**
- **SQL Server**
- **Visual Studio ou VS Code**

## Instalação

1. Clone o repositório;
2. Navegue até o diretório do projeto;
3. Restaure as dependências do projeto;
4. Configure o banco de dados (SQL Server) no arquivo `appsettings.json`. Certifique-se de fornecer a string de conexão correta:5. Atualize o banco de dados com as migrações existentes:6. Execute o projeto:A API estará disponível em `http://localhost:5000` (ou a porta especificada no `launchSettings.json`).


## Endpoints da API

### Autenticação e Usuários

- [ ] `POST /api/auth/login`: Login de usuários (retorna token JWT).
- [ ] `POST /api/auth/register`: Cadastro de novo usuário.

### Postagens

- [x] `GET /api/posts`: Lista todas as postagens.
- [x] `GET /api/posts/{id}`: Obtém detalhes de uma postagem específica.
- [x] `POST /api/posts`: Cria uma nova postagem (autenticado).
- [x] `PUT /api/posts/{id}`: Edita uma postagem existente (autenticado).
- [x] `DELETE /api/posts/{id}`: Exclui uma postagem (autenticado).

### Comentários

- [ ] `GET /api/comments/{postId}`: Lista todos os comentários de uma postagem.
- [ ] `POST /api/comments`: Cria um novo comentário (autenticado).

### Categorias

- [x] `GET /api/categories`: Lista todas as categorias.
- [x] `POST /api/categories`: Cria uma nova categoria (administrador).
- [x] `PUT /api/categories/{id}`: Atualiza uma categoria existente (administrador).
- [x] `DELETE /api/categories/{id}`: Remove uma categoria (administrador).

## Legendas das Checkboxes

**Legendas**: Foi feito [x] (Marcado) - [ ] (Não deu tempo de ser implementado)

## Testes

Este projeto faltou a case de testes unitários para as principais funcionalidades da API.

Os testes que serão implemenmtados no futuro.

## Estrutura do Projeto

- **Controllers**: Contêm os controladores da API, responsáveis por definir os endpoints e a lógica de interação com o repositório e serviços.
- **Models**: Definições das entidades do banco de dados e os objetos de transferência de dados (DTOs).
- **Repositories**: Camada de abstração para acesso e manipulação de dados.
- **Services**: Lógica de negócios, responsável por orquestrar as operações entre repositórios e controladores.
- **Data**: Configuração do Entity Framework Core e migrações do banco de dados.

## Desenvolvido

Desenvolvido por [Raiannecaroline](https://github.com/Raiannecaroline)

## Em Andamento

A documentação e a parte de testes, JWT token e filtro de paginação e ordenação das queries ainda não foram implementados. A aplicação segue em andamento e essas funcionalidades serão adicionadas futuramente.
Este repositório contém a API backend do projeto **Dev Writer**, uma plataforma de blogs desenvolvida com **ASP.NET Core** e **SQL Server**. O backend fornece serviços RESTful para criar, editar, e gerenciar publicações, categorias, comentários e usuários.

## Funcionalidades

A API do Dev Writer oferece as seguintes funcionalidades:

- **Gerenciamento de Usuários**: Cadastro, autenticação (token-based), e gerenciamento de perfis de usuários.
- **Postagens**: Criação, edição, exclusão e visualização de postagens.
- **Comentários**: Permite aos usuários comentar em postagens e visualizar comentários.
- **Categorias**: Criação e gerenciamento de categorias para organizar as postagens.

## Tecnologias Utilizadas

- **ASP.NET Core**: Framework para construção da API RESTful.
- **Entity Framework Core**: Para mapeamento objeto-relacional (ORM) e acesso ao banco de dados.
- **SQL Server**: Banco de dados utilizado para persistência de dados.
- **JWT (JSON Web Tokens)**: Implementado para autenticação e autorização de usuários.
- **XUnit**: Framework de testes unitários.

## Requisitos

- **.NET 8 SDK**
- **SQL Server**
- **Visual Studio ou VS Code**

## Instalação

1. Clone o repositório:

   ```bash
   git clone https://github.com/Raiannecaroline/dev-writer-project-final.git
   ```

2. Navegue até o diretório do projeto:

   ```bash
   cd dev-writer-project-final
   ```

3. Restaure as dependências do projeto:

   ```bash
   dotnet restore
   ```

4. Configure o banco de dados (SQL Server) no arquivo `appsettings.json`. Certifique-se de fornecer a string de conexão correta:

   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=.;Database=dev_writer;Trusted_Connection=True;MultipleActiveResultSets=true"
   }
   ```

5. Atualize o banco de dados com as migrações existentes:

   ```bash
   dotnet ef database update
   ```

6. Execute o projeto:

   ```bash
   dotnet run
   ```

A API estará disponível em `http://localhost:5000` (ou a porta especificada no `launchSettings.json`).

## Algumas explicações

O banco vai estar nesse link (o mesmmo foi implementado de forma local e pela forma Code Firt ['Não seria o mais correto, mas tive alguns problemas'])
Link: [Banco de Dados no Drive](https://drive.google.com/drive/folders/1yzwBW01FhrdPLQ8xBBPOSpio4aWZ-966?usp=sharing)
