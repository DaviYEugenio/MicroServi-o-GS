#  Global Solution - Microservice and Web Engineering Project

## Integrantes 
- Davi Yamane Eugenio - RM: 87221
- Gustavo Costa Pereira - RM: 87843
- Vitor Ramos Santos de Faria - RM: 88000

## Matéria e Professor 📖
- Matéria: Microservice and Web Engineering
- Professor: José Romualdo da Costa Filho

## Front-end
O Front-end é um modulo do projeto para exibição dos dados trazidos pela API. Ele oferece as seguintes funções:

- Mostra um gráfico com as informações das metas ODS 3 dos anos anteriores;
- Mostra tabela com informações sobre as metas ODS 3 dos anos anteriores.

## API 
A API é um módulo do projeto dedicada ao gerenciamento de dados de clientes. Ela oferece uma variedade de funcionalidades, incluindo:

- Carrega os dados salvos no banco de dados (Objetivos, Indicados e ODS)
  
Todos os dados gerenciados por esta API são persistidos em um banco de dados SQL Server integrado ao projeto.

## Como utilizar 📄
Para consumir nossos serviço basta seguir os seguintes passos:

1 - [Criar tabelas no SQL Server](https://github.com/DaviYEugenio/MicroServi-o-GS/tree/main/BD)

2 - Executar Dockerfile e abrir o seguinte [Link](https://localhost:44366/swagger/index.html)

## Bando de dados 🎲
O Modelo Relaciona utilizado no banco de dados foi: 
![MER banco de dados](BD/MER.png)

## Tecnologias Utilizadas 💻
O projeto foi desenvolvido utilizando as seguintes tecnologias:
- **C#**: Versão da linguagem de programação Java utilizada no projeto.
- **Angular**: Ferramenta de gerenciamento de dependências utilizada no projeto.
- **SQL Server**: Versão do Spring Boot utilizada no projeto.
- **Docker**: Tecnologia de contêiner utilizada para gerenciar e implantar aplicações de forma eficiente.
- **Microsoft Visual Studio**: Utilizamos o ambiente de desenvolvimento Microsoft Visual Studio IDE para a escrita, edição e depuração de código C# de forma eficaz.
- **SQL Developer**: Empregamos o SQL Developer como uma ferramenta robusta de administração e desenvolvimento de banco de dados Oracle SQL.

<p display="inline-block">
  <img width="48" src="https://github.com/FIAP20233SIS/Cliente/assets/98359422/47409cfd-cfa8-4139-a78b-15592d7771bf" alt="docker-logo"/>
  <img width="40" src="https://upload.wikimedia.org/wikipedia/en/thumb/6/68/Oracle_SQL_Developer_logo.svg/1200px-Oracle_SQL_Developer_logo.svg.png" alt="oracle-database-logo"/>
  <img width="48" src="https://uxwing.com/wp-content/themes/uxwing/download/brands-and-social-media/postman-icon.png" alt="spring-boot-logo"/>
  <img width="48" src="https://swimburger.net/media/fbqnp2ie/azure.svg" alt="spring-boot-logo"/>  
</p>
 
