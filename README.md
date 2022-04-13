# REST API Integration Tests

![NET SDK](https://img.shields.io/github/v/tag/dotnet/sdk?color=%23512bd4&label=sdk&logo=.net&style=for-the-badge)

This project demonstrates how to build a REST API application with .NET6, including integration tests.

## Prerequisites

Make sure you have installed and be configured the environment variables all the following prerequisites on your
development machine:

| OS      | .NET SDK                          |
| ------- | --------------------------------- |
| Windows | `winget install microsoft.dotnet` |
| Linux   | `brew install --cask dotnet-sdk`  |

## Executing the Tests

- Clone the repository.

```git
git clone git@github.com:burakkaygusuz/RESTAPI.IntegrationTests.git
```

- Change the directory.

```shell
cd RESTAPI.IntegrationTests
```

- Run the test.

```shell
dotnet build && dotnet test
```
