📦 Labest Backend
📌 Propósito do Projeto

O Labest Backend é uma API REST desenvolvida com foco em arquitetura limpa, organização em camadas e aplicação de boas práticas do ecossistema .NET.

O projeto foi estruturado para:

Aplicar princípios de Clean Architecture
Demonstrar separação clara de responsabilidades
Implementar autenticação e autorização com JWT
Centralizar a Injeção de Dependência
Implementar logs estruturados e auditoria
Facilitar execução e testes através de banco de dados em memória

O sistema utiliza banco de dados InMemory, permitindo execução imediata sem necessidade de configurar banco externo.

Integração com o frontend:
👉 https://github.com/lcavianna-gmail/Labest-frontend

🏗️ Arquitetura

A solução segue os princípios da Clean Architecture, organizando o sistema em camadas desacopladas:

Labest  
│  
├── Labest.API  
├── Labest.Application  
├── Labest.Domain  
├── Labest.Infrastructure  
└── Labest.CrossCutting  
🔹 Responsabilidade das Camadas  
🟦 Labest.API  
Controllers  
Configuração do pipeline  
Middlewares  
Autenticação e autorização  
Swagger  
🟩 Labest.Application  
Casos de uso  
Serviços de aplicação  
DTOs  
Orquestração das regras de negócio  
🟨 Labest.Domain  
Entidades  
Interfaces (contratos)  
Regras de negócio puras  

A camada Domain não depende de nenhuma outra camada.  

🟪 Labest.Infrastructure  
Implementações concretas de repositórios  
Configuração do DbContext  
Implementação do banco de dados InMemory  
Integrações externas  
🟥 Labest.CrossCutting  
Registro e organização da Injeção de Dependência  
Encapsulamento da configuração de serviços  
Modularização da configuração entre camadas  

Essa abordagem mantém a API desacoplada das implementações concretas.  

🗄️ Banco de Dados  

Para facilitar execução e avaliação técnica, o projeto utiliza:  

✔ Entity Framework Core InMemory  

Isso permite:  

Executar a aplicação imediatamente  
Não depender de banco externo  
Testar fluxos completos rapidamente  
Simplificar setup para avaliadores técnicos  
🔄 Substituição por Banco Relacional  

A arquitetura permite facilmente substituir o InMemory por:  

SQL Server  
PostgreSQL  
MySQL  

Bastando alterar a configuração na camada Infrastructure e no CrossCutting.  

🛠️ Tecnologias Utilizadas  
Plataforma  
.NET 8  
ASP.NET Core Web API  
Persistência  
Entity Framework Core  
Provider InMemory  
Autenticação e Segurança  
JWT (JSON Web Token)  
Authorization com [Authorize]  
CORS dinâmico por ambiente  
Logs  
Serilog  
Logs estruturados  
Escrita em arquivo  
Rotação automática  
Conceitos Aplicados  
Clean Architecture  
Injeção de Dependência  
Repository Pattern   
DTO Pattern  
Separation of Concerns  
Princípios SOLID  
🔐 Segurança  

A aplicação utiliza autenticação baseada em JWT, garantindo:  

Controle de acesso a endpoints protegidos  
Identificação do usuário autenticado  
Segurança baseada em token  

O CORS é configurado dinamicamente conforme o ambiente (Development / Production).  

📊 Logs e Auditoria  

A aplicação implementa:  

Serilog para logs estruturados  
Persistência de logs em arquivo  
Rotação automática  
Serviço de auditoria para rastreamento de ações críticas  

Essa abordagem facilita monitoramento e rastreabilidade em ambientes produtivos.  

🚀 Como Executar o Projeto  
1️⃣ Clonar o repositório  
git clone https://github.com/lcavianna-gmail/Labest-backend.git  
2️⃣ Executar a aplicação  
dotnet run

Pronto ✅  
Nenhuma configuração adicional é necessária, pois o banco é InMemory.  

A API estará disponível em:
https://localhost:{porta}  

📁 Estrutura Organizacional  
Camada	Responsabilidade  
API	Entrada da aplicação e configuração  
Application	Regras de negócio  
Domain	Entidades e contratos  
Infrastructure	Persistência e integrações  
CrossCutting	Injeção de Dependência  

📌 Evoluções Futuras  
Testes unitários  
Testes de integração  
Dockerização  
Banco relacional persistente  
CI/CD  
Monitoramento  
Health Checks  
Versionamento de API  

👨‍💻 Autor

Luiz Claudio de Almeida Vianna
Backend Developer | .NET | Arquitetura de Software
