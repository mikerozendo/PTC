# PTC

CRUD criado p/ fins pessoais. <br />

Estrutura do projeto<br />
Arquitetura baseada em DOMAIN DRIVEN DESIGN(DDD).<br />

Camada WEB => Recebe requisições AJAX e contém Injecões de Depêndencia p/ outras camadas da aplicação no Startup; <br />
Camada de Domínio (PTC.Domain) => Contém entidades, enums e Interfaces que apontam p/ camada de Service e Repository; <br />
Camada de Serviço (PTC.Application) => Contém toda lógica de negócio, validações, aplicações de regras e tratamento de possíveis exceptions visando chamar a camada de repository passando valores limpos p/ escrita no banco;<br />
Camada de Dados (PTC.Repository) => Recebe paramêtros passados pela camada de serviço e inicia fluxo de leitura ou escrita no banco por meio de Stored Procedures;<br />

 
Técnologias utilizadas{<br />
  C# / .NET 5,<br />
  Html,<br />
  Css,<br />
  JavaScript,<br />
  SQL Server
}<br />


