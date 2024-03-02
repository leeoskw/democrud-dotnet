<h1 align="center" style="font-weight: bold;">Crud simples para consulta =) 💻</h1>

<p align="center">
 <a href="#tech">Technologies</a> • 
  <a href="#routes">API Endpoints</a> •
 <a href="#colab">Collaborators</a> •
 <a href="#contribute">Contribute</a>
</p>

<p align="center">
    <b>Uma simples web api, contendo os métodos de um CRUD na qual persiste os dados utilizando um SQLServer.</b>
</p>

<h2 id="technologies">💻 Technologies</h2>

- .NET 6.0
- SQLServer

<h2 id="started">🚀 Getting started</h2>

Essa demo foi construída utilizando dotnet e as extensões do nuget:
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

<h3>Cloning</h3>

Para clonar, abra o cmd/git bash (ou qualquer terminal de sua preferência) e digite

```bash
git clone https://github.com/leeoskw/democrud-dotnet.git
```

<h3>Config .appsettings </h2>

Use the `.appsettings.example` as reference to create your configuration file `.appsettings.json` with your data

```json

"ConnectionStrings": {
    "DefaultConnection": "Data Source=HUFFLEPUFF;Database=FuncionariosWebApi;Trusted_Connection=True; Encrypt=false; TrustServerCertificate=true"
}
```
Note: This is a repository to be used as a reference and study. DB Connections, password and others sensible data should be store in a Parameter Store inside AWS, for example or similar.


<h2 id="routes">📍 API Endpoints</h2>

| route               | description                                          
|----------------------|-----------------------------------------------------
| <kbd>GET /api/funcionario</kbd>     | retrieves 'funcionario' info see [response details](#get-funcionario-detail)
| <kbd>POST /api/funcionario</kbd>     | create a 'funcionario' into db see [request details](#post-funcionario-detail)

<h3 id="get-funcionario-detail">GET /api/funcionario</h3>

**RESPONSE**
```json
{
	"dados": {
    "id" : 42,
    "nome": "Ellie The Cat",
    "sobrenome" : "miau",
    "departamento" : "Financeiro",
    "ativo" : true,
    "turno" : "noite",
    "DataDeCriacao" : "2024-02-28 10:15:30",
    "DataDeAlteracao" : "2024-04-04 19:10:12"
  },
	"mensagem": "",
	"sucesso": true
}
```

<h3 id="post-funcionario-detail">POST /api/funcionario</h3>

**REQUEST**
```json
{
  "username": "fernandakipper",
  "password": "4444444"
}
```

**RESPONSE**
```json
{
  "token": "OwoMRHsaQwyAgVoc3OXmL1JhMVUYXGGBbCTK0GBgiYitwQwjf0gVoBmkbuyy0pSi"
}
```
