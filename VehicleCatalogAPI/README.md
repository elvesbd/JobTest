# VehicleCatalog

<!---Esses são exemplos. Veja https://shields.io para outras pessoas ou para personalizar este conjunto de escudos. Você pode querer incluir dependências, status do projeto e informações de licença aqui--->

![GitHub repo size](https://img.shields.io/github/repo-size/elvesbd/JobTest?style=for-the-badge)
![GitHub language count](https://img.shields.io/github/languages/count/elvesbd/JobTest?style=for-the-badge)
![GitHub forks](https://img.shields.io/github/forks/elvesbd/JobTest?style=for-the-badge)
![GitHub issues](https://img.shields.io/github/issues-raw/elvesbd/JobTest?style=for-the-badge)
![GitHub pull requests](https://img.shields.io/github/issues-pr/elvesbd/JobTest?style=for-the-badge)

<img src="https://i.imgur.com/rDiRPYM.png" alt="swagger api">

> A VehicleCatalog funciona como um catálogo de veículos a venda, onde é possível visualizar vários veículo disponíveis para venda, e onde uma pessoa pode anunciar veículos para venda desde que efetue um cadastro no sistema para estar apto a cadastrar veiculo. O sistema possui um API desenvolvida com a tecnologia [.NET](https://learn.microsoft.com/pt-br/dotnet) e uma Home Page que exibe uma vitrine de veículos, além de também possui uma area logada para que um usuário possa cadastrar novos veículos que foi desenvolvida em [React](https://pt-br.react.dev/).

## 💻 Pré-requisitos

Antes de começar, verifique se você atendeu aos seguintes requisitos:

<!---Estes são apenas requisitos de exemplo. Adicionar, duplicar ou remover conforme necessário--->

- Você precisa ter o [.NET](https://dotnet.microsoft.com/en-us/download) instalado
- [docker](https://docs.docker.com/engine/install) para rodar o banco de dados, na aplicação utilizamos SQL Server.

## 🚀 Instalando VehicleCatalogAPI

Para instalar o VehicleCatalogAPI, siga estas etapas:

Clone o projeto:

```
git clone https://github.com/elvesbd/JobTest
```

Acesse o diretório da API:

```
cd /VehicleCatalogAPI
```

Restaure as dependências:

```
dotnet restore
```

Rodando banco de dados SQL Server com docker:

```
docker run --name <nome container> -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server
```

Verifique se o container estar rodando:

```
docker ps
```

Aplicando Migrations para criação da base de dados e suas tabelas:

```
dotnet ef database update
```

## ☕ Usando VehicleCatalogAPI

Para usar VehicleCatalogAPI, execute:

```
dotnet run
```

Acesse a documentação da API através da url:

```
http://localhost:5108/swagger
```

## 🤝 Colaborador

Agradecemos às seguintes pessoas que contribuíram para este projeto:

<table>
  <tr>
    <td align="center">
      <a href="#">
        <img src="https://github.com/elvesbd.png" width="100px;" alt="Foto do Elves Brito no GitHub"/><br>
        <sub>
          <b>Elves Brito</b>
        </sub>
      </a>
    </td>
  </tr>
</table>

## 📝 Licença

Esse projeto está sob licença. Veja o arquivo [LICENÇA](LICENSE.md) para mais detalhes.

[⬆ Voltar ao topo](#Fincheck)<br>
