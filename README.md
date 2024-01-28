## Description
Sample .Net application developed in late 2022 as part of a company learning program.<br>
Usefull as a small tech demo

## Solution structure
### Carting Service
  Layered style microservice<br>
  Features:
  - REST-based API
  - LiteDb storage
  - Listening to Azure ServiceBus
  - Minimal unit/integration tests
### Catalog Service
  Hexagonal-styled microservice<br>
  Features:
  - REST-based API, implicit validation
  - Sql Server storage, EF Core
  - Publishing messages to Azure ServiceBus
  - Azure Ad authentication
  - Role-based authorization
  - Minimal unit/integration tests
### Api Gateway
  Ocelot Gateway 

