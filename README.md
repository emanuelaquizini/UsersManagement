# UsersManagement

Aplicação para cadastro de usuários com um Backend .NET Core (8.0) e Frontend Angular SPA usando Bootstrap.

1. No caminho root UserManagementApi, rodar o seguinte comando para subir a imagem Docker:
`docker-compose up --build`

. Em seguida, rode a migration do banco de dados:
   `dotnet ef database update`

4. Iniciar a Solution para rodar a API (porta 44346), acessar <https://localhost:44346/swagger> para ter acesso ao swagger.

5. No caminho da pasta do projeto UserManagementApi/ClientApp, rodar o seguinte comando para subir a aplicação Angular:
   `ng serve`
O serviço rodará na porta 4200, acessar <http://localhost:4200/>.
