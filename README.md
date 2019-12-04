# ThaiStringTokenizer

[![GitHub license](https://img.shields.io/badge/license-MIT-blue.svg)](https://github.com/chaiwatmat/ThaiStringTokenizer/blob/master/LICENSE)
[![build](https://github.com/chaiwatmat/ThaiStringTokenizer/workflows/build/badge.svg?branch=master)](https://github.com/chaiwatmat/ThaiStringTokenizer/workflows/build/badge.svg?branch=master)
[![Coverage Status](https://coveralls.io/repos/github/chaiwatmat/ThaiStringTokenizer/badge.svg)](https://coveralls.io/github/chaiwatmat/ThaiStringTokenizer)
![Libraries.io dependency status for latest release](https://img.shields.io/librariesio/release/nuget/thaistringtokenizer)
[![CodeFactor](https://www.codefactor.io/repository/github/chaiwatmat/thaistringtokenizer/badge)](https://www.codefactor.io/repository/github/chaiwatmat/thaistringtokenizer)
[![Nuget Version](https://img.shields.io/nuget/v/ThaiStringTokenizer.svg)](https://www.nuget.org/packages/ThaiStringTokenizer)
[![Nuget Downloads](https://img.shields.io/nuget/dt/ThaiStringTokenizer.svg)](https://www.nuget.org/packages/ThaiStringTokenizer)

Thai string tokenizer is a dotnet Library tokenizer and Substring for Thai language, implemented for support dotnet standard 2.0

## Installation

### Package Manager

```bat
Install-Package ThaiStringTokenizer -Version 0.5.0
```

### .NET CLI

```sh
dotnet add package ThaiStringTokenizer --version 0.5.0
```

### PackageReference

```xml
<PackageReference Include="ThaiStringTokenizer" Version="0.5.0" />
```

### Paket CLI

```sh
paket add ThaiStringTokenizer --version 0.5.0
```

## Usage

### Split Thai word

```cs
using System.Collections.Generic;
using ThaiStringTokenizer;

public void SplitWord()
{
    ThaiTokenizer tokenizer = new ThaiTokenizer();
    string text = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
    List<string> result = tokenizer.Split(text);
    //result will be => ["ปลา", "ที่", "ใหญ่", "ที่สุด", "ใน", "โลก", "คือ", "ปารีส", "ชุบ", "แป้ง", "ทอด"]
}
```

### SubThaiString

```cs
using System.Collections.Generic;
using ThaiStringTokenizer;

public void SubstringThaiStyle()
{
    ThaiTokenizer tokenizer = new ThaiTokenizer();
    string text = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
    var maxLenght = 20;
    List<string> result = tokenizer.SubThaiString(text, maxLength);
    //result will be => ["ปลาที่ใหญ่ที่สุดในโลกคือ", "ปารีสชุบแป้งทอด"]
}
```

### SubThaiStringAndCount

```cs
using System.Collections.Generic;
using ThaiStringTokenizer;
using ThaiStringTokenizer.Models;

public void SubstringThaiStyle()
{
    var input = "ถ้าหากรักนี้ ไม่บอกไม่พูดไม่กล่าว แล้วเขาจะรู้ว่ารักหรือเปล่า";

    var tokenizer = new ThaiTokenizer(removeSpace: false);
    var results = tokenizer.SubThaiStringAndCount(input, 24);

    /*
    results will be :

    List<ThaiStringResponse>
    {
        new ThaiStringResponse{ Words = "ถ้าหากรักนี้ ไม่บอกไม่พูดไม่กล่าว", Countable = 24},
        new ThaiStringResponse{ Words = " แล้วเขาจะรู้ว่ารักหรือเปล่า", Countable = 21}
    };
    */
}
```

### Append custom dictionary

```cs
using System.Collections.Generic;
using ThaiStringTokenizer;

public void SplitWord()
{
    List<string> customDictionary = new List<string>{ "หวัดดี", "หวักลี", "เชอแตม" };
    ThaiTokenizer tokenizer = new ThaiTokenizer(customDictionary);
    string text = "หวักลีหวัดดีปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอดเชอแตม";
    List<string> result = tokenizer.Split(text);
    //result will be => ["หวักลี", "หวัดดี", "ปลา", "ที่", "ใหญ่", "ที่สุด", "ใน", "โลก", "คือ", "ปารีส", "ชุบ", "แป้ง", "ทอด", "เชอแตม"]
}
```

### Do not remove space

```cs
using System.Collections.Generic;
using ThaiStringTokenizer;

public void SubstringThaiStyle()
{
    ThaiTokenizer tokenizer = new ThaiTokenizer(removeSpace: false);
    string text = "อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์";
    var maxLenght = 50;
    List<string> result = tokenizer.SubThaiString(text, maxLength);
    //result will be => ["อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์"]
}
```

## License

Licensed under the MIT license. See [LICENSE](LICENSE) for details.
