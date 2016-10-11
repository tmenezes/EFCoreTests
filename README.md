# EFCoreTests
A test app using **EntityFrameworkCore** + **SqlLocalDb** + **XUnit**

## Pre requisits
* [.Net Core SDK](https://www.microsoft.com/net/core#windows)
* **SqlLocalDb** installed 
* **MsSqlLocalDb** instance created on your **SqlLocalDb**

## Setup the Enviroment
1. Open your prompt command line tool
1. Change to the *EFCoreTests* folder
1. Change to "src\EF-Core" folder (``cd src\EF-Core``)
1. Compile and Restore the project  (``dotnet restore``)
1. Run the EF migrations: (``dotnet ef database update``)
1. Done!

## Run the test scenarios
1. Change to "test\EF-Core" folder (``cd src\EFCore.Test``)
1. Compile and Restore the project  (``dotnet restore``)
1. Run the EF migrations: (``dotnet test``)
1. Done!