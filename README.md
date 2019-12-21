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
Install-Package ThaiStringTokenizer -Version 0.6.0
```

### .NET CLI

```sh
dotnet add package ThaiStringTokenizer --version 0.6.0
```

### PackageReference

```xml
<PackageReference Include="ThaiStringTokenizer" Version="0.6.0" />
```

### Paket CLI

```sh
paket add ThaiStringTokenizer --version 0.6.0
```

## Usage

### Split Thai word

```cs
using System;
using System.Collections.Generic;
using ThaiStringTokenizer;

public void SplitWord()
{
    var tokenizer = new ThaiTokenizer();
    var text = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
    var results = tokenizer.Split(text);

    foreach(var result in results){
        Console.WriteLine(result);
    }
}
```

#### result1

```text
ปลา
ที่
ใหญ่
ที่สุด
ใน
โลก
คือ
ปารีส
ชุบ
แป้ง
ทอด
```

### SubThaiString

```cs
using System;
using System.Collections.Generic;
using ThaiStringTokenizer;

public void SubstringThaiStyle()
{
    var tokenizer = new ThaiTokenizer();
    var text = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
    var maxLenght = 20;
    var result = tokenizer.SubThaiString(text, maxLength);

    foreach(var result in results){
        Console.WriteLine(result);
    }
}
```

#### result2

```text
ปลาที่ใหญ่ที่สุดในโลกคือ
ปารีสชุบแป้งทอด
```

### SubThaiStringAndCount

```cs
using System;
using System.Collections.Generic;
using ThaiStringTokenizer;
using ThaiStringTokenizer.Models;

public void SubstringThaiStyle()
{
    var input = "ถ้าหากรักนี้ ไม่บอกไม่พูดไม่กล่าว แล้วเขาจะรู้ว่ารักหรือเปล่า";

    var tokenizer = new ThaiTokenizer(removeSpace: false);
    var results = tokenizer.SubThaiStringAndCount(input, 24);

    foreach(var result in results){
        Console.WriteLine("word = {0}, countable = {1}, uncountable = {2}", result.Words, result.Countable, result.Uncountable);
    }
}
```

#### result3

```text
Words = ถ้าหากรักนี้ ไม่บอกไม่พูดไม่กล่าว, Countable = 24, Uncountable = 9
Words =  แล้วเขาจะรู้ว่ารักหรือเปล่า, Countable = 21, Uncountable = 7
```

### Append custom dictionary

```cs
using System;
using System.Collections.Generic;
using ThaiStringTokenizer;

public void SplitWord()
{
    var customDictionary = new List<string>{ "หวัดดี", "หวักลี", "เชอแตม" };
    var tokenizer = new ThaiTokenizer(customDictionary);
    var text = "หวักลีหวัดดีปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอดเชอแตม";
    var results = tokenizer.Split(text);

    foreach(var result in results){
        Console.WriteLine(result);
    }
}
```

#### result4

```text
หวักลี
หวัดดี
ปลา
ที่
ใหญ่
ที่สุด
ใน
โลก
คือ
ปารีส
ชุบ
แป้ง
ทอด
เชอแตม
```

### Do not remove space

```cs
using System;
using System.Collections.Generic;
using ThaiStringTokenizer;

public void SubstringThaiStyle()
{
    var tokenizer = new ThaiTokenizer(removeSpace: false);
    var text = "อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์";
    var maxLenght = 50;
    var results = tokenizer.SubThaiString(text, maxLength);

    foreach(var result in results){
        Console.WriteLine(result);
    }
}
```

#### result5

```text
อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์
```

## License

Licensed under the MIT license. See [LICENSE](LICENSE) for details.
