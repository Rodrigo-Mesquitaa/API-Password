# API-Password- DotNet 6.0
API construída usando a arquitetura hexagonal, consiste em dividir uma aplicação em camadas de acordo com suas responsabilidades e enfatizar uma camada em especial, onde ficará a lógica principal da aplicação, a camada de domínio ou domain (do termo original).


#3# Camada Services
 A Camada services é responsável por abranger o meu serviç (API).

## Camada Application
 A Camada de aplicação que é responsável por realizar a(s) aplicação(s) se comunicar diretamente com o Domínio. Nela são implementados:

 - Classes dos Servicos da aplicação.
 - Interfaces (contratos).
 - DataFrransferObjectos (DTO).
 - AutoMapper.
 
## Camada Domain
A camada de domínio que é responsável por ter uma modelagem sólida da regra de négocio. É baseado em um conjunto de ideias, conhecimento e processos de negócio. É a razão do negócio existir. Sem o domínio todo o sistema, todos os processos auxiliares, não servirão para nada. Nessa camada temos:

- Entidades.
- Interfaces (contratos) para Serviços e Repositórios.
- Classes dos Serviços do domínio.
- Validações (caso seja necessário).

## Infraestrutura 
 camada de infraestrutura é responsável por dar o suporte as demais camadas. Que atualmente é dividida por duas camadas com seus respectivos conteúdos:

### Data

- Repositórios.
- DataModel (Mapeamento).
- Persistência de dados.

### CrossCutting (Camada que atravessa todas as outras, portando possui referência de todas elas):
A camada CrossCutting pode realizar a inversão de controle e injeção de dependências. Isso significa que você não precisará instanciar todas as classes manualmente.

- IoC (Inversão de controle).

## Testes
Possui um projeto de testes, que terá como objetivo de realizar a cobertura de testes da PasswordApi.