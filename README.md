# Dime.Kendo

![Build Status](https://dev.azure.com/dimenicsbe/Utilities/_apis/build/status/System%20-%20MASTER%20-%20CI?branchName=master) [![Dime.Kendo package in Dime.Scheduler feed in Azure Artifacts](https://feeds.dev.azure.com/dimenicsbe/_apis/public/Packaging/Feeds/a7b896fd-9cd8-4291-afe1-f223483d87f0/Packages/06914876-f487-480e-b6a3-37f9b9c00a2d/Badge)](https://dev.azure.com/dimenicsbe/Utilities/_packaging?_a=package&feed=a7b896fd-9cd8-4291-afe1-f223483d87f0&package=06914876-f487-480e-b6a3-37f9b9c00a2d&preferRelease=true)

## Introduction

Server-side models for the Kendo UI library such as filters and sorters.

## Getting Started

- You must have Visual Studio 2019 Community or higher.
- The dotnet cli is also highly recommended.

## About this project

The most notable types in this assembly include:

- `Filter`
- `Sort`

These classes are useful when a ASP.NET (Core) Web API is used as a proxy to Kendo UI's widgets. They can be declared in the action's parameters.

## Build and Test

- Run dotnet restore
- Run dotnet build
- Run dotnet test

## Installation

Use the package manager NuGet to install Dime.Kendo:

`dotnet add package Dime.Kendo`

## Usage

``` csharp
[HttpPost]
[Route(Routes.Appointments.Get)]
public async Task<IPage<BackOfficeAppointmentDto>> Get([FromBody]DataSourceRequest request)
    => await Service.GetAsync(request.Take, request.Skip, request.Page, request.PageSize, request.Filter, request.Sort);
```

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License

[![License](http://img.shields.io/:license-mit-blue.svg?style=flat-square)](http://badges.mit-license.org)