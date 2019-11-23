#!/bin/bash

dotnet build

dotnet test ThaiStringTokenizerTest \
    /p:CollectCoverage=true \
    /p:CoverletOutputFormat=\"opencover\" \
    /p:Threshold=80 \
    /p:ThresholdType=branch

cd ThaiStringTokenizerTest
dotnet reportgenerator \
    "-reports:coverage.opencover.xml" \
    "-targetdir:coveragereport" \
    "-reporttypes:HTML;HTMLSummary;SonarQube"
