#!/bin/bash

rm -rf \
    ThaiStringTokenizer/bin \
    ThaiStringTokenizer/obj \
    ThaiStringTokenizerTest/bin \
    ThaiStringTokenizerTest/obj \
    ThaiStringTokenizerTest/report \
    ThaiStringTokenizerTest/coverage.info

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

cd report
php -S localhost:8000
