if ! type "$dotnet" > /dev/null; then		# Only works on sh/bash/zsh
  echo "dotnet command is not installed/in PATH"
fi

dotnet restore												# Restore NuGet Packages
dotnet build ACC17/ACC17.csproj -c Release					# Build Source Project
dotnet build ACC17_Tests/ACC17_Tests.csproj -c Release		# Build Test Project
dotnet test ACC17_Tests/ACC17_Tests.csproj -c Release		# Run unit tests
