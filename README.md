# 🟩 HealthHabits.Api  
API desenvolvida para o Challenge Care Plus – Engenharia de Software 3º Ano (2025/AGO)  
Disciplina: Arquitetura Orientada a Serviços e Web Services

---

## 📘 Sobre o Projeto

O **HealthHabits.Api** é um serviço de saúde digital focado em **promoção de hábitos saudáveis**, alinhado ao propósito da Care Plus:  
*“Ajudar as pessoas a viverem vidas mais longas, saudáveis e felizes.”*

A API permite que o usuário:

- Cadastre usuários  
- Cadastre hábitos de saúde  
- Registre atividades diárias  
- Consulte estatísticas (soma e média)  
- Gerencie tudo isso via endpoints REST

O projeto segue **arquitetura orientada a serviços (SOA)**, com forte separação de camadas, boas práticas de API REST, segurança de entradas e integração com banco SQLite via Entity Framework Core.

---

# 🏛 Arquitetura do Projeto (SOA)

A solução foi construída utilizando **camadas independentes**, refletindo os princípios de SOA:

Controllers (Apresentação)
↓
Services (Regras de Negócio)
↓
Repositories (Acesso ao Banco)
↓
Data (DbContext / EF Core)
↓
Models (Entidades de Domínio)

markdown
Copiar código

### ✔ Benefícios dessa arquitetura:

- Camadas independentes  
- Baixo acoplamento  
- Alta coesão  
- Fácil manutenção e evolução  
- Testabilidade melhorada  
- Reuso de serviços  
- Ponto alto na rubrica da disciplina  

---

# 🛠 Tecnologias Utilizadas

- **ASP.NET Core 8 – Web API**
- **Entity Framework Core 8**
- **SQLite**
- **C# 12**
- **Swagger / OpenAPI**
- **Injeção de Dependência (DI)**

---

# 📦 Estrutura de Pastas

HealthHabits.Api/
├── Controllers/
├── Services/
├── Repositories/
├── Models/
├── Data/
├── Program.cs
├── appsettings.json
└── healthhabits.db

yaml
Copiar código

---

# 🔧 Como Executar o Projeto

### 1. Restaurar dependências

dotnet restore
2. Aplicar migrations (se ainda não existir o banco)
bash
Copiar código
dotnet ef database update
3. Rodar a API
bash
Copiar código
dotnet run
4. Abrir o Swagger
bash
Copiar código
http://localhost:5003/swagger
(Use a porta exibida no console.)

🔗 Endpoints da API
👤 Usuários
➤ Listar usuários
GET /api/usuarios

➤ Buscar usuário por ID
GET /api/usuarios/{id}

➤ Criar usuário
POST /api/usuarios
Body:

json
Copiar código
{
  "nome": "João Pedro",
  "email": "jp@careplus.com"
}
➤ Atualizar usuário
PUT /api/usuarios/{id}

➤ Remover usuário
DELETE /api/usuarios/{id}

📝 Hábitos
➤ Listar hábitos de um usuário
GET /api/usuarios/{usuarioId}/habitos

➤ Buscar hábito por ID
GET /api/habitos/{id}

➤ Criar hábito
POST /api/habitos
Body:

json
Copiar código
{
  "usuarioId": 1,
  "tipo": "agua",
  "unidade": "ml",
  "metaDiaria": 2000
}
➤ Atualizar hábito
PUT /api/habitos/{id}

➤ Remover hábito
DELETE /api/habitos/{id}

➤ Estatísticas do hábito
GET /api/habitos/{id}/estatisticas
Retorna:

json
Copiar código
{
  "habitoId": 1,
  "soma": 1500,
  "media": 500
}
📊 Registros de Hábitos
➤ Listar registros
GET /api/habitos/{habitoId}/registros

➤ Criar registro
POST /api/habitos/{habitoId}/registros
Body:

json
Copiar código
{
  "valor": 500
}
➤ Buscar registro por ID
GET /api/registros/{id}

➤ Remover registro
DELETE /api/registros/{id}

🔒 Segurança e Tratamento de Erros
A API aplica validações em todas as operações, incluindo:

✔ Validação de entrada
Nome e email obrigatórios

Email com formato válido

Meta diária maior que zero

Registro de valor maior que zero

Usuário precisa existir para criar hábito

Hábito precisa existir antes de registrar atividade

✔ Tratamento de erros (Status Codes)
200 OK

201 Created

204 No Content

400 Bad Request (dados inválidos)

404 Not Found (entidade inexistente)

500 Internal Server Error (falha inesperada)

✔ Proteção contra ciclos JSON
O projeto utiliza:

csharp
Copiar código
options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
Isso evita loops de serialização entre Usuários ↔ Hábitos ↔ Registros.

🌐 Interoperabilidade (8% da rubrica)
A API é totalmente interoperável, podendo ser consumida por qualquer plataforma:

Mobile (React Native)

Web (React, Angular, Vue)

Outras APIs

Sistemas corporativos

Dispositivos IoT

Porque utiliza:

REST

JSON

URLs padronizadas

Métodos HTTP corretos

Tipos simples e universais

📈 Escalabilidade (7% da rubrica)
A arquitetura do projeto permite crescer facilmente:

✔ Horizontal
Rodando múltiplas instâncias em load balancing.

✔ Vertical
Mudando o banco SQLite para:

SQL Server

PostgreSQL

MySQL

Azure SQL

sem alterar as regras de negócio.

✔ Arquitetura em camadas
Controllers → Services → Repositories → Data
Mantém tudo desacoplado e expansível.

✔ DI (Injeção de Dependência)
Permite trocar repositórios, bancos e serviços sem quebrar o restante.

🧪 Testes recomendados via Swagger
Criar usuário

Criar hábito

Registrar atividades

Listar estatísticas

Atualizar informações

Excluir registros e entidades

📌 Conclusão
Este projeto atende integralmente aos requisitos da disciplina:

API RESTful completa

Arquitetura SOA

Uso correto de HTTP

Documentação via Swagger

Boas práticas e tratamento de erros

Segurança nas entradas

Banco integrado via EF Core

Interoperabilidade e Escalabilidade descritas

Pronto para ser integrado ao aplicativo mobile do Challenge Care Plus.

👥 Integrantes do Grupo
(Preencha com Nome + RM + GitHub)

- Kaio Vinicius Meireles Alves - RM553282
- Lucas Alves de Souza -  RM553956
- Guilherme Fernandes de Freitas - RM554323
- João Pedro Chizzolini de Freitas - RM553172
- Lucas de Freitas Pagung - RM553242
