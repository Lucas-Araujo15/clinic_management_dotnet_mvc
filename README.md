# Descrição do Projeto
O projeto envolveu o desenvolvimento de uma aplicação web utilizando o framework ASP.NET MVC, com o objetivo de consumir uma API que gerencia o cadastro de pacientes e planos de saúde. A aplicação permite a interação com os dados através de uma interface intuitiva, facilitando o gerenciamento de informações de saúde de maneira eficiente.

## Principais Funcionalidades

- **Cadastro de Pacientes**: A aplicação permite a criação, leitura, atualização e deleção (CRUD) de informações dos pacientes. Os dados incluem nome, data de nascimento, CPF, endereço, telefone etc.

- **Gestão de Planos de Saúde**:  O sistema permite o cadastro e gerenciamento completo dos planos de saúde. As operações CRUD (criar, ler, atualizar e deletar) podem ser realizadas nos planos de saúde.
  
- **Vínculo entre Pacientes e Planos de Saúde**: Uma das funcionalidades mais importantes do sistema é a capacidade de vincular um ou mais planos de saúde a um paciente. A aplicação permite:

  - **Associação de Pacientes a Planos**: Vincular um paciente a um ou mais planos de saúde existentes, permitindo que cada paciente tenha seu histórico de planos de saúde registrado.
    
  - **Gestão de Vínculo**: Permite adicionar ou remover planos de saúde associados a um paciente, garantindo que o cadastro esteja sempre atualizado com as informações mais recentes.
    
  - **Visualização de Vínculos**: Visualizar todos os planos de saúde associados a um paciente e todos os pacientes vinculados a um plano de saúde.

## Vídeo Demonstração
[![](https://img.youtube.com/vi/AfF7dxSA2dQ/0.jpg)](https://youtu.be/AfF7dxSA2dQ)

# Instruções para executar o projeto (API)
Para executar o projeto da API localmente, é necessário possuir alguns programas e ferramentas instaladas e seguir esses passos:

## Pré-requisitos
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) com o workload de desenvolvimento para ASP.NET Core
- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) (versão compatível com o projeto (.NET 8.0))
- Git instalado ([Baixar Git](https://git-scm.com/))
- Banco de Dados Oracle

## Passo 1: Clonar o Repositório
Abra o terminal ou o Git Bash e execute o seguinte comando para clonar o repositório do projeto:

```bash
git clone https://github.com/Lucas-Araujo15/clinic_management_dotnet
```

## Passo 2: Navegar até a Pasta do Projeto
Depois de clonar o repositório, navegue até a pasta raiz do projeto:

```bash
cd clinic_management_dotnet
```

## Passo 3: Restaurar as Dependências
Restaure todas as dependências necessárias para o projeto executando o seguinte comando:

```bash
dotnet restore
```
## Passo 4: Configurar String de Conexão
Edite o arquivo appsettings.json e configure credenciais corretas para acessar seu banco de dados Oracle:

```json
"ConnectionStrings": {
  "DefaultConnection": "Data Source=oracle.fiap.com.br:1521/orcl; User Id={Seu usuário}; Password={Sua senha}"
}
```

## Passo 5: Executar as migrations do projeto
Aplique as migrations executando o seguinte comando para criar as tabelas em seu banco de dados:

```bash
dotnet ef database update
```

## Passo 6: Executar o projeto
Para rodar o projeto, utilize o seguinte comando:

```bash
dotnet run
```
Isso irá iniciar a API localmente. A saída no terminal indicará o endereço no qual a API está sendo executada, geralmente http://localhost:5263

## Passo 7: Acessando documentação e testando o projeto com Swagger
No navegador, acesse o seguinte endereço para visualizar a documentação da API gerada pelo Swagger:

```bash
https://localhost:5263/swagger/index.html
```
Através da interface do Swagger, você pode testar os endpoints diretamente, enviando requisições e recebendo as respostas em tempo real. Isso facilita a verificação da funcionalidade da API sem a necessidade de ferramentas externas.

# Instruções para executar o projeto (MVC)
Para executar o projeto MVC localmente, é necessário possuir alguns programas e ferramentas instaladas e seguir esses passos:

## Pré-requisitos
- [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) com o workload de desenvolvimento para ASP.NET Core
- [.NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) (versão compatível com o projeto (.NET 8.0))
- Git instalado ([Baixar Git](https://git-scm.com/))

## Passo 1: Clonar o Repositório
Abra o terminal ou o Git Bash e execute o seguinte comando para clonar o repositório do projeto:

```bash
git clone https://github.com/Lucas-Araujo15/clinic_management_dotnet_mvc
```

## Passo 2: Navegar até a Pasta do Projeto
Depois de clonar o repositório, navegue até a pasta raiz do projeto:

```bash
cd clinic_management_dotnet_mvc
```

## Passo 3: Restaurar as Dependências
Restaure todas as dependências necessárias para o projeto executando o seguinte comando:

```bash
dotnet restore
```

## Passo 4: Executar o projeto
Para rodar o projeto, utilize o seguinte comando:

```bash
dotnet run
```
Isso irá iniciar o projeto. A saída no terminal indicará o endereço no qual o projeto MVC está sendo executado, geralmente http://localhost:5078

# Integrantes do Grupo
- RM99565 - Erick Nathan Capito Pereira
- RM550841 - Lucas Araujo Oliveira Silva
- RM551569 - Marina de Souza Cucco
