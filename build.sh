if ! type "$dotnet" > /dev/null; then
  echo "dotnet command is not installed/in PATH"
fi

dotnet build ACC17/ACC17.csproj -c Release					# Build Source Project
dotnet build ACC17_Tests/ACC17_Tests.csproj -c Release		# Build Test Project
dotnet test ACC17_Tests/ACC17_Tests.csproj -c Release		# Run unit tests
