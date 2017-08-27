# izone-slack

[![Build Status](https://drone.iteam.life/api/badges/Iteam1337/izone-core-api/status.svg)](https://drone.iteam.life/Iteam1337/izone-core-api)

## About

This is an API used to connect our daily lives (i.e. Slack) with our time reporting, planning and economy systems.

## Slack

The SlackController holds endpoints for slash commands in Slack. They are using features that requires your slash commands to be setup in the context of a Slack App.

## Getting started

The project is using dotnet core 2.0 and it is recommended that you have docker and docker-compose installed. You can use a traditional SQL Server installation or you can simply run the docker-compose stack to get a containerized SQL Server.

### Running the stack locally

```
docker-compose up --build
```

### Tests

```
dotnet test ica.rest.tests/ica.rest.tests.csproj
```
