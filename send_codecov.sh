#!/bin/bash

dotnet build

dotnet test ThaiStringTokenizerTest \
    /p:CollectCoverage=true \
    /p:CoverletOutputFormat=opencover \
    /p:Threshold=80 \
    /p:ThresholdType=branch

./codecov -f "ThaiStringTokenizerTest/coverage.opencover.xml" -t $CODECOV_TOKEN
