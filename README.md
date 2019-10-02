# Standard - Integração

# Objetivo
Desafio de integração de arquivos em ambiente corporativo.

# Tecnologias e Componentes utilizados
- Visual Studio 2017;
- .Net Core 2.1;
- Banco de Dados seria (SQL SERVER ou Firebase) Estou analisando a possibilidade de usar um não relacional, pois no momento utilizaria apenas para log;
- Utilização do Padrão DDD com algumas outras camadas e vendo a possibildade da utilização do padrão SOA;
- Api Rest;
- Testes Unitários com XUnit;
- Injeção de dependência;
- NSubstitute para Mocks;
- Para testar as Apis recomendo o uso do postman;
- Swagger para documentação;
- Docker;

# Resumo
- Deixo registrado que fui informado para enviar o projeto do jeito que estava até o momento para não atrasar o processo. Solicito que seja considerado as ideias nos projetos "Standard" e "Standard.Framework" mais a organização da estrutura de código para o sucesso desse desafio, por isso vou buscar detalhar um pouco mais a documentação abaixo, para melhorar o entendimento do código gerado.

- Projeto "Standard.Framework" encapsulo atividades que evitam repetir código e que apoiam as implementações no projeto Standard. 
Abaixo um breve resumo de cada projeto: 
  1- "Data" utilizado para funcionalidades de banco.  
  2- "Extension" utilizado para funcionalidades de manipulação de tipos. 
  3- "Filter" utilizado para trabalhar em conjunto com validator para exibição do resultado da funcionalidade. 
  4- "Http" utilizado para colocar detalhes de manipulação das chamadas Json, como Serialize e Deserialize. 
  5- "Result" utilizado para colocar os objetos que trafegam na comunicação entre as camadas do projeto. 
  6- "Utils" utilizado para colocar funcionalidades que podem ser comuns em outros projetos. 
  7- "Validator" utilizado para validar os atributos no momento da requisição ao projeto.
  
- Entregar arquivo vai FTP ou SFTP.
  Resposta: Não houve tempo para implementar.

- Notificar por e-mail problemas gerados no processo.
  Resposta: Criado um projeto "ServiceProvider" com uma classe chamada "NotificacaoEmailServiceProvider" para comunicar aos interessados os possiveis problemas ocorridos na aplicação. Lembrando que a documentação do desafio dizia que "Para envio de e-mails, considere que já existe um serviço para este fim."

- Fazer validação de checksum.
  Resposta: Criei na classe "ArquivoEntityService" um método "public IDomainResult<bool> ValidarCheckSum()" para realizar essa operação, mas não deu tempo para implementar.
  
- Docker.
  Resposta:  Não houve tempo para implementar, sendo assim decidi mostrar como seria a configuração desse item. Deverá ser inserido um projeto no WebApi chamado "Dockerfile" e um outro arquivo chamado "Docker-compose" na solution. Eles serão os responsáveis por subir os containers de nossa aplicação.
  
- Aplicar Https.
  Resposta: Não houve tempo para implementar.
  
- Apis de "Copiar, Mover, Deletar"
  Resposta: Funcionando.
  
- Teste Unitário
  Resposta: Realizei um teste na camada de domínio para representar também que caso não haja tempo, tente cobrir algo do seu domínio, pois é nesse projeto que estará as suas regras de negócio.

# API
**Operação de Copiar os Arquivos**
[Post]
Url: {Localhost}/api/Arquivo/copiar
Request - Body
{
	"caminhoOrigem" : "C:\\Users\\Orlando\\Desktop\\Globo\\LocalOrigem",
  "caminhoDestino" : "C:\\Users\\Orlando\\Desktop\\Globo\\LocalDestino"
}

Response
{
    "Data": true,
    "StatusCode": 200,
    "Messages": [
        "Arquivo(s) copiado(s) com sucesso."
    ]
}

**Operação de Mover dos Arquivos**
[Post]
Url: {Localhost}/api/Arquivo/mover
Request - Body
{
	"caminhoOrigem" : "C:\\Users\\Orlando\\Desktop\\Globo\\LocalOrigem",
  "caminhoDestino" : "C:\\Users\\Orlando\\Desktop\\Globo\\LocalDestino"
}
Response
{
    "Data": true,
    "StatusCode": 200,
    "Messages": [
        "Arquivo(s) movido(s) com sucesso."
    ]
}

**Operação de Entregar dos Arquivos**
[Post]
Url: {Localhost}/api/Arquivo/entregar
Request - Body
{
	"caminhoDestino" : "C:\\Users\\Orlando\\Desktop\\Globo\\LocalDestino"
}

Response
{
    "Data": true,
    "StatusCode": 200,
    "Messages": [
        "Arquivo(s) entregue(s) com sucesso."
    ]
}

**Operação de Exclusão dos Arquivos**
[Delete]
Url: {Localhost}/api/Arquivo
Request - Body
{
	"caminhoDestinoOrigem" : "C:\\Users\\Orlando\\Desktop\\Globo\\LocalOrigem"
}

Response
{
    "Data": true,
    "StatusCode": 200,
    "Messages": [
        "Arquivo(s) deletado(s) com sucesso."
    ]
}

# Autor
Orlando Linhares de Oliveira
