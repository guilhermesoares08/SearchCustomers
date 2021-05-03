# SearchCustomers
Sistema de busca e visualização de clientes

# versions APP
Angular CLI: 9.1.15
Node: 14.16.1
typescript: 3.8.3

# .NET
version: 5.0.202
EntityFrameworkCore: 5.0.5
Microsoft.EntityFrameworkCore.SqlServer: 5.0.5
AutoMapper.Extensions.Microsoft.DependencyInjection: 8.1.1

# Desing Pattern
Repository (Datacontext, Repo, Services, Controller)

# Approach
Decidi utilizar o padrão Repository, Angular e Webapi, pois já uso algo parecido no meu TCC e estou mais familiarizado com a estrutura;
Componentes e interfaces de usuário foram montados utilizando os componentes do Angular;
Os estilos foram feitos utilizando o bootstrap e o ngx-bootstrap;
Autenticação foi feita manualmente por motivo de não precisar de uma segurança tão avançada, como o Jwt;
O controle de acesso à tela é controlado por um Guard do angular;
