FinFlow.Dashboard

Aplicação web para importação de dados financeiros via CSV e visualização de KPIs de cobrança em um dashboard interativo — construída com ASP.NET Core 8 MVC, Entity Framework Core e PostgreSQL.


Contexto
Este é o segundo projeto do meu portfólio de transição de carreira — de Analista de Negócios Jr para Desenvolvedor Backend.
A ideia surgiu de um problema real: analistas financeiros perdem horas consolidando dados de cobrança manualmente em planilhas. O FinFlow resolve isso com um ciclo completo de dados — importação, processamento, validação e visualização — entregando os KPIs direto num dashboard, sem Excel, sem esforço manual.

O que o sistema faz
O usuário sobe um arquivo CSV com dados de cobranças. O sistema processa, valida, salva no banco e exibe um dashboard com os indicadores financeiros calculados automaticamente.
Ciclo completo:
Upload CSV → Extração → Validação → Persistência → Dashboard com KPIs

KPIs do Dashboard
KPIDescriçãoTotal a ReceberSoma das cobranças com status PendingTotal RecebidoSoma dos pagamentos em um períodoTaxa de Inadimplência% de cobranças com status OverdueTicket MédioValor médio por tipo de clienteTempo Médio de PagamentoMédia de dias entre vencimento e pagamentoCobranças por StatusAgrupamento por Pending, Paid, Overdue, CancelledTop 5 InadimplentesClientes com maior volume de cobranças em atraso

Stack

ASP.NET Core 8 MVC — framework web com padrão Model-View-Controller
Entity Framework Core — ORM para acesso ao banco
PostgreSQL via Npgsql
FluentValidation — validação dos dados importados
AutoMapper — mapeamento entre entidades e DTOs
Chart.js — gráficos interativos no dashboard
Bootstrap 5 — interface responsiva


Arquitetura
Controllers → Services → Repositories → Entities
                ↓
            Views (Razor)

Controllers — recebem requisições e retornam views
Services — lógica de negócio, processamento do CSV e cálculo dos KPIs
Repositories — isolam o acesso ao banco de dados
Entities — representam as tabelas do banco
Views — páginas Razor renderizadas no servidor
DTOs — objetos de transferência entre camadas


Entidades
Customer (1) ──────< Invoice (N)
                        │
                    Payment (1)
Customer — cliente com tipo (Individual / Company) e status ativo
Invoice — cobrança com valor, vencimento e status (Pending / Paid / Overdue / Cancelled)
Payment — pagamento com valor pago, data e método (Pix / BankSlip / CreditCard / Transfer)

Fluxo de Importação

Usuário acessa a tela de upload e envia um arquivo .csv
O sistema valida o formato e as colunas esperadas
Os dados são transformados e validados com FluentValidation
Registros válidos são salvos no banco via EF Core
Metadados da importação são registrados (data, total de linhas, erros)
Usuário é redirecionado ao dashboard com os dados atualizados


Como rodar localmente
Pré-requisitos

.NET 8 SDK
Docker

1. Subir o banco de dados
bashdocker run --name finflow-db \
  -e POSTGRES_USER=postgres \
  -e POSTGRES_PASSWORD=postgres \
  -e POSTGRES_DB=finflow \
  -p 5433:5432 \
  -d postgres
2. Configurar a connection string
Em appsettings.Development.json:
json{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5433;Database=finflow;Username=postgres;Password=postgres"
  }
}
3. Aplicar as migrations
bashdotnet ef database update
4. Rodar a aplicação
bashdotnet run
Acesse em: https://localhost:{porta}

Roadmap

 Autenticação de usuários
 Histórico de importações com log de erros
 Filtros por período no dashboard
 Exportação do relatório em PDF
 Testes unitários com xUnit e Moq


Projeto anterior
Este projeto é a evolução do OpMetrics.Core — primeira API REST do portfólio, focada em indicadores operacionais industriais.
