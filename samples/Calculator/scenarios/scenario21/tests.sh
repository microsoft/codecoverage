#!/usr/bin/env bash
SCRIPT_DIR=$( cd -- "$( dirname -- "${BASH_SOURCE[0]}" )" &> /dev/null && pwd )
cd $SCRIPT_DIR/../../src/Calculator.Server
dotnet run --no-build &
cd ../../
dotnet test --results-directory "$SCRIPT_DIR/../../TestResults/"
kill %1
