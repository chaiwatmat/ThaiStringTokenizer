# ThaiStringTokenizer

## Run test

```sh
dotnet test
```

## Build

```sh
dotnet build
```

## Publish to nuget.org

```sh
dotnet nuget push ThaiStringTokenizer/bin/Debug/ThaiStringTokenizer.0.1.0.nupkg \
    -k $NUGET_TOKEN \
    -s https://api.nuget.org/v3/index.json
```

## More info

<https://docs.microsoft.com/en-us/nuget/quickstart/create-and-publish-a-package-using-the-dotnet-cli>
