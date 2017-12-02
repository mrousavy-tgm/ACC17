# ACC17
Advent coding contest (TGM) 2017 - C#

# Levels
For every level there is a subdirectory (e.g.: `ACC17/01_GameOfLife` and `ACC17_Tests/01_GameOfLife`) for all source files, **and** a build-configuration for Category + Level. (e.g. `Expert_01`)

# Building:
### Prerequisites:
1. [.NET Core SDK](https://www.microsoft.com/net/download)

### Build
```
dotnet build ACC17/ACC17.csproj -c CATEGORY_LEVEL		        # Build Source Project
dotnet build ACC17_Tests/ACC17_Tests.csproj -c CATEGORY_LEVEL		# Build Test Project
```

### Run tests
```
dotnet test ACC17_Tests/ACC17_Tests.csproj -c CATEGORY_LEVEL		# Run unit tests
```

#### Where `CATEGORY_LEVEL` is combined of the Category (Junior, Intermediate, Expert) and the level (01, 02, ..).
E.g: `Expert_01`
