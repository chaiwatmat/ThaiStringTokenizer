# ThaiStringTokenizer

## Build

```sh
dotnet build
```

## Run test

```sh
dotnet test ThaiStringTokenizerTest \
    /p:CollectCoverage=true \
    /p:CoverletOutputFormat=\"opencover\" \
    /p:Threshold=80 \
    /p:ThresholdType=branch
```

## Upload coverage to codecov.io

```sh
curl -s https://codecov.io/bash > codecov
chmod +x codecov
./codecov -f "ThaiStringTokenizerTest/coverage.opencover.xml" -t $CODECOV_TOKEN
```

## Publish to nuget.org

```sh
dotnet nuget push ThaiStringTokenizer/bin/Debug/ThaiStringTokenizer.0.3.1.nupkg \
    -k $NUGET_TOKEN \
    -s https://api.nuget.org/v3/index.json
```

## Generate report (optional)

```sh
cd ThaiStringTokenizerTest
dotnet reportgenerator \
    "-reports:coverage.opencover.xml" \
    "-targetdir:coveragereport" \
    "-reporttypes:HTML;HTMLSummary;SonarQube"
```

## Thai unicode

<https://en.wikipedia.org/wiki/Thai_(Unicode_block)>

## More info

<https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli>
