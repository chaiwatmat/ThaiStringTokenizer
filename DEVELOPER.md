# ThaiStringTokenizer

## Build

```sh
dotnet build
```

## Run test

```sh
dotnet test --no-build \
    /p:CollectCoverage=true \
    /p:CoverletOutputFormat=lcov \
    /p:Threshold=80 \
    /p:ThresholdType=branch
```

## Publish to nuget.org

```sh
dotnet nuget push ThaiStringTokenizer/bin/Release/ThaiStringTokenizer.0.4.1.nupkg \
    -k $NUGET_TOKEN \
    -s https://api.nuget.org/v3/index.json
```

## Generate report (optional)

```sh
cd ThaiStringTokenizerTest
dotnet reportgenerator \
    "-reports:coverage.info" \
    "-targetdir:report" \
    "-reporttypes:HTML;HTMLSummary;SonarQube"
```

## Thai unicode

<https://en.wikipedia.org/wiki/Thai_(Unicode_block)>

## More info

<https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli>
