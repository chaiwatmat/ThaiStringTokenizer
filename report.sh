#!/bin/bash

dotnet build

dotnet test --no-build \
    /p:CollectCoverage=true \
    /p:CoverletOutputFormat=lcov \
    /p:Threshold=80

cd ThaiStringTokenizerTest
dotnet reportgenerator \
    "-reports:coverage.info" \
    "-targetdir:report" \
    "-reporttypes:HTML;HTMLSummary;SonarQube"
