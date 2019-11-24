#!/bin/bash

dotnet build

dotnet test --no-build \
    /p:CollectCoverage=true \
    /p:CoverletOutput=coverage.xml \
    /p:CoverletOutputFormat=opencover \
    /p:Threshold=80 \
    /p:ThresholdType=branch

cd ThaiStringTokenizerTest
dotnet reportgenerator \
    "-reports:coverage.xml" \
    "-targetdir:coveragereport" \
    "-reporttypes:HTML;HTMLSummary;SonarQube"
