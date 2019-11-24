#!/bin/bash

dotnet build

dotnet test --no-build \
    /p:CollectCoverage=true \
    /p:CoverletOutput=coverage.xml \
    /p:CoverletOutputFormat=opencover \
    /p:Threshold=80 \
    /p:ThresholdType=branch

./codecov -f "ThaiStringTokenizerTest/coverage.xml" -t $CODECOV_TOKEN
