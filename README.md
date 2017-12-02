# ACC17
Advent coding contest (TGM) 2017 - C#

# Levels
For every level there is a subdirectory (e.g.: `ACC17/01_GameOfLife` and `ACC17_Tests/01_GameOfLife`) for all source files, **and** a build-configuration for Category + Level. (e.g. `Expert_01`)

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
dotnet build ACC17/ACC17.csproj -c CATEGORY_LEVEL
dotnet build ACC17_Tests/ACC17_Tests.csproj -c CATEGORY_LEVEL
```

### Run tests
```sh
dotnet test ACC17_Tests/ACC17_Tests.csproj -c CATEGORY_LEVEL
```

### Run Main
```sh
dotnet run ACC17/ACC17.csproj -c Release -- "3;3;0;000111000$" "output.csv" "0" "50"
```

(Or just run `build.sh`)

#### Where `CATEGORY_LEVEL` is combined of the Category (Junior, Intermediate, Expert) and the level (01, 02, ..).
E.g: `Expert_01`
