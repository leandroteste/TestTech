# Teste técnico Ourinvest

Este é um projeto de exemplo que demonstra a estruturação de um aplicativo usando .NET Core 3.1. O projeto é dividido em camadas separadas para facilitar a manutenção e testes.

## Estrutura do Projeto

O projeto está organizado da seguinte forma:

- `Domain`: Camada de domínio contendo a lógica de negócios e modelos de dados.
- `View`: Camada de visualização contendo a interface do usuário, neste caso, um console para interação com o usuário.
- `Tests`: Camada de testes contendo os testes unitários usando NUnit.

## Funcionalidades do Projeto

O projeto possui as seguintes funcionalidades:

1. Leitura de listas separadas por vírgulas: O aplicativo permite que o usuário insira uma lista de itens separados por vírgulas e retorna o item mais comum da lista.

2. Avaliação de Expressões Matemáticas: O aplicativo permite que o usuário insira uma expressão matemática e retorna o resultado da avaliação da expressão.

## Tecnologias Utilizadas

- .NET Core 3.1
- NUnit

## Executando o Projeto

Certifique-se de ter o .NET Core 3.1 instalado em sua máquina. Para executar o projeto, siga as etapas abaixo:

1. Clone o repositório para sua máquina local.
2. Navegue até o diretório do projeto usando o terminal ou prompt de comando.
3. Execute o seguinte comando para compilar o projeto:

   ```shell
   dotnet build
   ```

4. Execute o seguinte comando para executar os testes:

   ```shell
   dotnet test
   ```

5. Navegue até o diretório da camada `View` usando o terminal ou prompt de comando.
6. Execute o seguinte comando para executar o aplicativo:

   ```shell
   dotnet run
   ```

O aplicativo será iniciado e você poderá interagir com ele através do console, inserindo listas separadas por vírgulas ou expressões matemáticas.

## Contribuição

## Licença

Este projeto está licenciado sob a [Leandro trindade](LICENSE).