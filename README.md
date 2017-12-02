# ACC17
Advent coding contest (TGM) 2017 - C#

# Levels
For every level there is a subdirectory (e.g.: `ACC17/01_GameOfLife`) for all source files, **and** a subdirectory for unit tests (`ACC17_Tests/01_GameOfLifeTests`)

# Add a new Project
```sh
dotnet sln ACC17.sln add ACC_17/[LEVEL_NAME]/[LEVEL_NAME].csproj    # Actual Project
dotnet sln ACC17.sln add ACC_17_Tests/[LEVEL_NAME]Tests/[LEVEL_NAME]Tests.csproj    # Test Project
```
(For more info on XUnit test projects see [here](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-dotnet-test))

# Building:
### Prerequisites:
1. [.NET Core SDK](https://www.microsoft.com/net/download) > 2.0 (determine with `dotnet --version`)

### Build
* Restore NuGet Packages
```sh
dotnet restore
```

* Build Projects
```sh
dotnet build ACC_17/[LEVEL_NAME]/[LEVEL_NAME].csproj -c Release
dotnet build ACC_17_Tests/[LEVEL_NAME]Tests/[LEVEL_NAME]Tests.csproj -c Release
```

### Run tests
```sh
dotnet test ACC_17_Tests/[LEVEL_NAME]Tests/[LEVEL_NAME]Tests.csproj -c CATEGORY_LEVEL
```

### Run Main
```sh
dotnet run ACC_17/[LEVEL_NAME]/[LEVEL_NAME].csproj -c Release -- "3;3;0;000111000$" "output.csv" "0" "50"
```

(Or just run `build.sh`)

#### Where `LEVEL_NAME` is combined of the Level (01, 02, ..) and the Name (GameOfLife, ..)
E.g: `01_GameOfLife`
