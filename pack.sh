#!/usr/bin/env bash
dotnet restore
dotnet clean
dotnet build -c Release
dotnet pack --no-build -c Release -o ./artifacts
