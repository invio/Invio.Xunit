#!/usr/bin/env bash

#exit if any command fails
set -e

artifactsFolder="./artifacts"

if [ -d $artifactsFolder ]; then
  rm -R $artifactsFolder
fi

dotnet restore ./src/Invio.Xunit
dotnet restore ./test/Invio.Xunit.Tests

dotnet test ./test/Invio.Xunit.Tests/Invio.Xunit.Tests.csproj -c Release -f netcoreapp1.0

dotnet pack ./src/Invio.Xunit -c Release -o ../../artifacts
