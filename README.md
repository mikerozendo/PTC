# PTC

Projeto para controle de compra e venda de veículos, cadastro de proprietários e estatísticas de compra e venda. <br />

O projeto ainda não esta finalizado!!

Estrutura do projeto<br />
Arquitetura baseada em DOMAIN DRIVEN DESIGN(DDD).<br />

Aplicando conceitos de DTO e Mapper feito de forma manual mascarando estrutura do de DB's, 

Modelando uma camada simples porém rica com dversos tratamentos e lançamento de exceptions em violações à regra.

Fluxos extensos de insert envolvendo diversas tabelas do banco, onde é aplicado o conceito de rollback chamando camadas de serviços de específicas entidades e gerando notificação do status do fluxo solicitado pelo cliente.

Atendendo à responses com Status code's específicos para fornecer uma melhor padronização dentro dos modelo REST. 

Próximas features 
* Refatoração de abertura de modais por arquivo JS para repassar todas notificações de fluxo ao Controller QNotfica que por sua vez devolverá HTML limpo <br />
 da notificação à ser aberto como modal.
* Alteração da estrutura de comportamentos das interfaces p/ descontinuação de métodos desnecessários.
* Implementação de dashboard de tela home com estatísticas em gráfico de acordo com informações retornadas do DB.
* Login feature com autentificação e refatoração.
* Mais testes unitários.

Técnologias utilizadas<br />
 * C# <br /> ,
 * ASP.NET CORE 6,<br />
 * Html,<br />
 * Css,<br />
 * JavaScript,<br />
 * MySQL,<br />
 * IText7 <br />
 * XUnit <br />


