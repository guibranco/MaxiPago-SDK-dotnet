# MaxiPago SDK client

The MaxiPago gateway SDK for .NET projects

![MaxiPago](https://raw.githubusercontent.com/guibranco/MaxiPago-SDK-dotnet/master/logo.png)

## CI/CD

[![Build status](https://ci.appveyor.com/api/projects/status/0rghu1mnaahlfi16?svg=true)](https://ci.appveyor.com/project/guibranco/MaxiPago-SDK-dotnet)
[![GitHub last commit](https://img.shields.io/github/last-commit/guibranco/MaxiPago-SDK-dotnet)](https://github.com/guibranco/MaxiPago-SDK-dotnet)
[![GitHub last release](https://img.shields.io/github/release-date/guibranco/MaxiPago-SDK-dotnet.svg?style=flat)](https://github.com/guibranco/MaxiPago-SDK-dotnet)
[![GitHub license](https://img.shields.io/github/license/guibranco/MaxiPago-SDK-dotnet)](https://github.com/guibranco/MaxiPago-SDK-dotnet)

## Code Quality

[![Codacy Badge](https://api.codacy.com/project/badge/Grade/13745ba64d924c90a9e2368e8736ea5d)](https://www.codacy.com/manual/changeme/13745ba64d924c90a9e2368e8736ea5d)
[![Codacy Badge](https://api.codacy.com/project/badge/Coverage/13745ba64d924c90a9e2368e8736ea5d)](https://www.codacy.com/manual/changeme/13745ba64d924c90a9e2368e8736ea5d)
[![Codecov](https://codecov.io/gh/guibranco/MaxiPago-SDK-dotnet/branch/master/graph/badge.svg)](https://codecov.io/gh/guibranco/MaxiPago-SDK-dotnet)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=guibranco_MaxiPago-SDK-dotnet&metric=alert_status)](https://sonarcloud.io/dashboard?id=guibranco_MaxiPago-SDK-dotnet)
[![Coverage](https://sonarcloud.io/api/project_badges/measure?project=guibranco_MaxiPago-SDK-dotnet&metric=coverage)](https://sonarcloud.io/dashboard?id=guibranco_MaxiPago-SDK-dotnet)

[![Maintainability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_MaxiPago-SDK-dotnet&metric=sqale_rating)](https://sonarcloud.io/dashboard?id=guibranco_MaxiPago-SDK-dotnet)
[![Lines of Code](https://sonarcloud.io/api/project_badges/measure?project=guibranco_MaxiPago-SDK-dotnet&metric=ncloc)](https://sonarcloud.io/dashboard?id=guibranco_MaxiPago-SDK-dotnet)
[![Technical Debt](https://sonarcloud.io/api/project_badges/measure?project=guibranco_MaxiPago-SDK-dotnet&metric=sqale_index)](https://sonarcloud.io/dashboard?id=guibranco_MaxiPago-SDK-dotnet)
[![Duplicated Lines (%)](https://sonarcloud.io/api/project_badges/measure?project=guibranco_MaxiPago-SDK-dotnet&metric=duplicated_lines_density)](https://sonarcloud.io/dashboard?id=guibranco_MaxiPago-SDK-dotnet)

[![Reliability Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_MaxiPago-SDK-dotnet&metric=reliability_rating)](https://sonarcloud.io/dashboard?id=guibranco_MaxiPago-SDK-dotnet)
[![Security Rating](https://sonarcloud.io/api/project_badges/measure?project=guibranco_MaxiPago-SDK-dotnet&metric=security_rating)](https://sonarcloud.io/dashboard?id=guibranco_MaxiPago-SDK-dotnet)
[![Code Smells](https://sonarcloud.io/api/project_badges/measure?project=guibranco_MaxiPago-SDK-dotnet&metric=code_smells)](https://sonarcloud.io/dashboard?id=guibranco_MaxiPago-SDK-dotnet)
[![Bugs](https://sonarcloud.io/api/project_badges/measure?project=guibranco_MaxiPago-SDK-dotnet&metric=bugs)](https://sonarcloud.io/dashboard?id=guibranco_MaxiPago-SDK-dotnet)
[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=guibranco_MaxiPago-SDK-dotnet&metric=vulnerabilities)](https://sonarcloud.io/dashboard?id=guibranco_MaxiPago-SDK-dotnet)

---

## Installation

[![MaxiPago NuGet Version](https://img.shields.io/nuget/v/MaxiPago.svg?style=flat)](https://www.nuget.org/packages/MaxiPago/)
[![MaxiPago NuGet Downloads](https://img.shields.io/nuget/dt/MaxiPago.svg?style=flat)](https://www.nuget.org/packages/MaxiPago/)
[![Github All Releases](https://img.shields.io/github/downloads/guibranco/MaxiPago-SDK-dotnet/total.svg?style=flat)](https://github.com/guibranco/MaxiPago-SDK-dotnet)

Download the latest zip file from the [Release pages](https://github.com/guibranco/MaxiPago-SDK-dotnet/releases) or simple install from [NuGet](https://www.nuget.org/packages/MaxiPago) package manager.

NuGet URL: [https://www.nuget.org/packages/MaxiPago](https://www.nuget.org/packages/MaxiPago)

NuGet installation via *Package Manager Console*:

```ps

Install-Package MaxiPago

```

---

## Features

Implements all features of MaxiPago API available at [Integration Documentation](https://www.maxipago.com/docs/maxiPago_API_Latest.pdf)

- Feature #1
- Feature #2
- Feature #3
- Feature #N

---

## Usage

```cs

//sample CSharp code showing how to use the lib
var client = new MaxiPagoClient();
client.CallSomeMethod();

```

---