# 🎮 LocadoraAPI - Checkpoint 2

## 📝 Descrição do Projeto
A **LocadoraAPI** é um sistema de gerenciamento de locação de jogos desenvolvido em .NET Core. O objetivo do projeto é permitir o cadastro de clientes e jogos, além de realizar a operação de aluguel, vinculando um jogo a um cliente específico. 

O projeto foi construído utilizando **Entity Framework Core** para persistência de dados em um banco de dados **Oracle**, seguindo os padrões de arquitetura REST.

---

## 🛠️ Componentes e Tecnologias Utilizadas
*   **Linguagem:** C#
*   **Framework:** .NET 8.0
*   **ORM:** Entity Framework Core
*   **Banco de Dados:** Oracle SQL
*   **Documentação:** Swagger (OpenAPI)
*   **Ferramentas:** Visual Studio 2022

---

## 🚀 Como Rodar o Projeto

### 1. Pré-requisitos
*   SDK do .NET 8.0 instalado.
*   Acesso a uma instância de banco de dados Oracle.

### 2. Configuração do Banco de Dados
No arquivo `appsettings.json`, ajuste a sua string de conexão:

"ConnectionStrings": {
  "OracleDbConnection": "User Id=SeuRM;Password=SuaSenha;Data Source=oracle.fiap.com.br:1521/ORCL"
}

A documentação Swagger estará disponível em: https://localhost:XXXX/swagger/index.html

---
## 🛣️ Endpoints Disponíveis
Clientes (/api/Cliente)
GET /api/Cliente: Lista todos os clientes.

GET /api/Cliente/{id}: Busca um cliente por ID.

GET /api/Cliente/buscar/{nome}: Busca clientes por parte do nome.

POST /api/Cliente: Cadastra um novo cliente.

PUT /api/Cliente/{id}: Atualiza um cliente existente.

DELETE /api/Cliente/{id}: Remove um cliente.

Jogos (/api/Jogo)
GET /api/Jogo: Lista todos os jogos.

GET /api/Jogo/{id}: Busca um jogo por ID.

GET /api/Jogo/disponiveis: Lista jogos que não estão alugados.

POST /api/Jogo: Cadastra um novo jogo.

PUT /api/Jogo/{id}: Atualiza dados de um jogo.

PUT /api/Jogo/{id}/alugar/{clienteId}: Realiza a locação do jogo para um cliente.

DELETE /api/Jogo/{id}: Remove um jogo.

---

## 📊 Exemplos de Requisição (JSON)
Cadastrar Cliente (POST)

{
  "nome": "Isis Macedo",
  "email": "isis@exemplo.com",
  "dataCadastro": "2026-05-06T00:00:00Z"
}

Cadastrar Jogo (POST)

{
  "titulo": "The Legend of Zelda: Tears of the Kingdom",
  "genero": "Aventura",
  "precoLocacao": 25.50,
  "disponivel": true
}

Realizar Aluguel (PUT)
URL: https://localhost:7211/api/Jogo/10/alugar/1

(Onde 10 é o ID do Jogo e 1 é o ID do Cliente)

---
👨‍💻 Autores
Isis Macedo e Andrade - RM561497 - Turma 2TDSR
Ana Clara de Oliveira Nascimento | RM 561957 - Turma 2TDSR
Pedro Mariutti | RM 75999 - Turma 2TDSR
Rafael Carvalho Meireles | RM 563413 - Turma 2TDSR
