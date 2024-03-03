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
- FluentValidation

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
| <kbd>GET /api/funcionarios</kbd>     | retrieves a list of all 'funcionario' info see [response details](#get-funcionario-detail)
| <kbd>GET /api/funcionario/{idFuncionario}</kbd>     | retrieves a specific 'funcionario' info see [response details](#get-funcionario-byid-detail)
| <kbd>POST /api/funcionario</kbd>     | create a 'funcionario' see [request details](#post-funcionario-detail)
| <kbd>PUT /api/funcionario</kbd>     | update a 'funcionario' see [request details](#update-funcionario-detail)
| <kbd>PUT /api/funcionario</kbd>     | inativa a 'funcionario' see [request details](#inativa-funcionario-detail)
| <kbd>DELETE /api/funcionario</kbd>     | delete a 'funcionario' see [request details](#delete-funcionario-detail)


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

<h3 id="get-funcionario-byid-detail">GET /api/funcionario/{idFuncionario}</h3>

**RESPONSE**
```json
{
	"dados": {
		"id": 42,
		"nome": "Lua Another Cat",
		"sobrenome": "Muuuu",
		"departamento": 1,
		"ativo": false,
		"turno": 2,
		"dataDeCriacao": "2025-01-03T18:17:48.9702136",
		"dataDeAlteracao": "2026-07-12T14:12:11.9959941"
	},
	"mensagem": "",
	"sucesso": true
}
```



<h3 id="post-funcionario-detail">POST /api/funcionario</h3>

**REQUEST**
```json
{
	"nome": "Ellie The Cat",
	"sobrenome" : "miau",
	"departamento" : 2,
	"ativo" : true,
	"turno" : 1
}
```

**RESPONSE**
```json
{
	"dados": {
		"id": 1,
		"nome": "Ellie The Cat",
		"sobrenome": "miau",
		"departamento": 2,
		"ativo": true,
		"turno": 1,
		"dataDeCriacao": "2024-03-02T20:40:49.4549572-03:00",
		"dataDeAlteracao": "2024-03-02T20:40:49.4549582-03:00"
	},
	"mensagem": "Registro criado com sucesso!",
	"sucesso": true
}
```
<h3 id="update-funcionario-detail">PUT /api/funcionario - Altera um registro</h3>

**REQUEST**
```json
{
	"id" : 2,
	"nome": "Ellie Just the cat",
	"sobrenome" : "Miau",
	"departamento" : 2,
	"ativo" : true,
	"turno" : 2
}
```

**RESPONSE**
```json
{
	"dados": {
		"id": 2,
		"nome": "Ellie Just the cat",
		"sobrenome": "Miau",
		"departamento": 2,
		"ativo": true,
		"turno": 2,
		"dataDeCriacao": "2024-03-03T19:19:50.2648681-03:00",
		"dataDeAlteracao": "2024-03-03T19:19:53.9946721-03:00"
	},
	"mensagem": "Dados alterados com sucesso!",
	"sucesso": true
}
```

<h3 id="inativa-funcionario-detail">PUT /api/funcionario/{idFuncionario} - Inativa um registro</h3>

**RESPONSE**
```json
{
	"dados": {
		"id": 2,
		"nome": "Ellie The Cat",
		"sobrenome": "Miau",
		"departamento": 2,
		"ativo": false,
		"turno": 1,
		"dataDeCriacao": "2024-03-03T18:17:48.9702136",
		"dataDeAlteracao": "2024-03-03T19:00:31.6391382-03:00"
	},
	"mensagem": "Funcionário Inativado com sucesso!",
	"sucesso": true
}
```

<h3 id="delete-funcionario-detail"> DELETE /api/funcionario/{idFuncionario} - Deleta um registro</h3>

**RESPONSE**
```json
{
	"dados": {
		"id": 2,
		"nome": "Ellie Just the cat",
		"sobrenome": "Miau",
		"departamento": "Compras",
		"ativo": true,
		"turno": "Noite",
		"dataDeCriacao": "2024-03-03T19:19:50.2648681",
		"dataDeAlteracao": "2024-03-03T19:19:53.9946721"
	},
	"mensagem": "Funcionário removido com sucesso!",
	"sucesso": true
}
```