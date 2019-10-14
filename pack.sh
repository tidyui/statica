#!/usr/bin/env bash

# Define directories
SCRIPT_DIR=$( cd "$( dirname "${BASH_SOURCE[0]}" )" && pwd )
OUTPUT_DIR=$SCRIPT_DIR/artifacts

# Clean and build in release
cd src/Statica
dotnet clean
dotnet build -c Release
cd ..
cd ..

# Make sure output folder exist.
if [ ! -d "$OUTPUT_DIR" ]; then
  mkdir "$OUTPUT_DIR"
fi

# Create all NuGet packages
nuget pack nuspec/Statica.nuspec -OutputDirectory $OUTPUT_DIR
