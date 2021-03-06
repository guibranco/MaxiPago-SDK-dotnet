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

- Add customer
- Delete customer
- Update customer
- Add card on file
- Delete card on file
- Cancel recurring
- Sale (with card data)
- Sale (with saved card)
- Sale (with card data, saving the card for future use)
- Auth (with card data)
- Auth (with saved card)
- Auth (with card data, saving the card for future use)
- Boleto (bank slip / bank bill - Brazil only!)
- Capture (capture a pre auth request)
- Return
- Void
- Recurring (with card data)
- Recurring (with saved card)
- Online Debit (Brazil only!)
- Transactions report
- Transaction detailed report
- Transaction detailed report by order id
- Check request status

---

## Usage

### Adding a customer

```cs

//For each environment (TEST and LIVE) this information is different!
var merchantId = "your-merchant-id"; //get this information with MaxiPago
var merchantKey = "your-merchant-key"; //get this information with MaxiPago

var api = new Api { Environment = "TEST" }; //TEST or LIVE
var response = api.AddConsumer(
    MerchantId,
    MerchantKey,
    userIdInYourSystem,
    firstName,
    lastName,
    addressLineOne, //if you don't has this information, use null instead
    addressLineTwo, //if you don't has this information, use null instead
    city, //if you don't has this information, use null instead
    state, //if you don't has this information, use null instead
    zipCode, //if you don't has this information, use null instead
    phone, //if you don't has this information, use null instead
    email,
    dateOfBirth, //if you don't has this information, use null instead
    document,
    gender); //M for Male and F for Female

if(!string.IsNullOrWhiteSpace(response.ErrorMessage))
    //handle the error message.
return response.Result.CustomerId; //store this customer id value for update or delete the customer in future.

```

### Delete customer

```cs

//For each environment (TEST and LIVE) this information is different!
var merchantId = "your-merchant-id"; //get this information with MaxiPago
var merchantKey = "your-merchant-key"; //get this information with MaxiPago

var api = new Api { Environment = "TEST" }; //TEST or LIVE

var response = api.DeleteCustomer(merchantId, merchantKey, customerId); //this information was returned by the AddCustomer method.
if(!string.IsNullOrWhiteSpace(response.ErrorMessage))
    //handle the error message.

```

### Update customer

```cs

//For each environment (TEST and LIVE) this information is different!
var merchantId = "your-merchant-id"; //get this information with MaxiPago
var merchantKey = "your-merchant-key"; //get this information with MaxiPago

var api = new Api { Environment = "TEST" }; //TEST or LIVE

var response = api.UpdatedCustomer(
    merchantId,
    merchantKey,
    customerId,
    userIdOnYourSystem,
    firstName,
    lastName,
    null,
    null,
    null,
    null,
    null,
    "+5511123456789", //updates the telephone
    email,
    null,
    null,
    "M");

if(!string.IsNullOrWhiteSpace(response.ErrorMessage))
    //handle the error message.

```

### Save card

```cs

//For each environment (TEST and LIVE) this information is different!
var merchantId = "your-merchant-id"; //get this information with MaxiPago
var merchantKey = "your-merchant-key"; //get this information with MaxiPago

var api = new Api { Environment = "TEST" }; //TEST or LIVE

var response = api.AddCardOnFile(
    merchantId,
    merchantKey,
    customerId,
    creditCardNumber,
    expirationMonth,
    expirationYear,
    billingName,
    billingAddressLineOne,
    billingAddressLineTwo,
    billingCity,
    billingState,
    billingZip,
    billingCountry,
    billingPhone,
    billingEmail,
    onFileEndDate, //Deadline to keep the card in the base
    onFilePermission, //Limit duration for the use of the saved card. "ongoing" = indefinitely / "use_once" = only once after the 1st payment
    onFileComment,
    onFileMaxChargeAmount); //Maximum amount that this card is authorized to be charged.

if(!string.IsNullOrWhiteSpace(response.ErrorMessage))
    //handle the error message.
return response.Result.Token; //store this token for future use (remove card, sale, auth...)

```

### Create recurring payment

```cs

//For each environment (TEST and LIVE) this information is different!
var merchantId = "your-merchant-id"; //get this information with MaxiPago
var merchantKey = "your-merchant-key"; //get this information with MaxiPago

var transaction = new Transaction { Environment = "TEST" }; //TEST or LIVE

var response = transaction.Recurring(
        merchantId,
        merchantKey,
        transactionId,
        value,
        creditCardNumber,
        expirationMonth,
        expirationYear,
        null,
        creditCardSecureCode,
        processorId, //TEST SIMULATOR = 1 | Rede = 2 | GetNet = 3 | Cielo = 4 | TEF = 5 | Elavon = 6 | ChasePaymentech = 8 
        6, //installments
        "N", //charge interest
        ipAddress,
        "new",
        startDate, //the date of first charge
        frequency, //combined with period, so if frequency is 1, every "period" will be charged. So if period is "weekly" and frequency is "2", every two weeks will be charged.
        period, //The charge recurring period: daily, weekly, monthly
        numberOfTimes, //The number of times to repeat the charge (use 999 as max value for "indefinitely" time, after 999 times, this recurring will need to be created again).
        failureThreshold, //Number of failed attempts needed to trigger email notification to merchant.
        "BRL"); //currency of the charge.

if(response.IsErrorResponse){
    if(response is ErrorResponse errorResult)
        Console.WriteLine(errorResult.ErrorMsg); //handle the error message.
}
if(!(response is TransactionResponse result))
    //some other erro, handle it

var orderId = result.OrderId;
var responseCode = result.ResponseCode;
if(responseCode != 0) {
    Console.WriteLine(result.ErrorMessage); //handle it

```
