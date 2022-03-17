# PTC

CRUD criado p/ fins pessoais. 

Estrutura do projeto
Arquitetura baseada em DOMAIN DRIVEN DESIGN(DDD).

Camada WEB => Recebe requisições AJAX e contém Injecões de Depêndencia p/ outras camadas da aplicação no Startup;
Camada de Domínio (PTC.Domain) => Contém entidades, enums e Interfaces que apontam p/ camada de Service e Repository;
Camada de Serviço (PTC.Application) => Contém toda lógica de negócio, validações, aplicações de regras e tratamento de possíveis exceptions visando chamar a camada de repository passando valores limpos p/ escrita no banco;
Camada de Dados (PTC.Repository) => Recebe paramêtros passados pela camada de serviço e inicia fluxo de leitura ou escrita no banco por meio de Stored Procedures;

DTO'S => Não presentes na estrutura do projeto p/ evitar custos de processamento e tempo de implementação;


Técnologias utilizadas{
  C# / .NET 5,
  Html,
  Css,
  JavaScript,
  SQL Server
}


