# ThaiStringTokenizer

Thai string tokenizer is a dotnet Library tokenizer and Substring for Thai language.

Source code base on <https://github.com/tyroroto/ThaiWord-Segmentation-.Net> but implemented for support dotnet standard 2.0

## Installation

### dotnet core

```sh
dotnet add package ThaiStringTokenizer
```

### other options from nuget

<https://www.nuget.org/packages/ThaiStringTokenizer/0.2.1>

## How to use

### Split Thai word

```cs
using System.Collections.Generic;
using ThaiStringTokenizer

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
using ThaiStringTokenizer

public void SubstringThaiStyle()
{
    ThaiTokenizer tokenizer = new ThaiTokenizer();
    string text = "ปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอด";
    var maxLenght = 20;
    List<string> result = tokenizer.SubThaiString(text, maxLength);
    //result will be => ["ปลาที่ใหญ่ที่สุดในโลกคือ", "ปารีสชุบแป้งทอด"]
}
```

### Append custom dictionary

```cs
using System.Collections.Generic;
using ThaiStringTokenizer

public void SplitWord()
{
    List<string> customDictionary = new List<string>{ "หวัดดี", "หวักลี", "เชอแตม" };
    ThaiTokenizer tokenizer = new ThaiTokenizer(customDictionary);
    string text = "หวักลีหวัดดีปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอดเชอแตม";
    List<string> result = tokenizer.Split(text);
    //result will be => ["หวักลี", "หวัดดี", "ปลา", "ที่", "ใหญ่", "ที่สุด", "ใน", "โลก", "คือ", "ปารีส", "ชุบ", "แป้ง", "ทอด", "เชอแตม"]
}
```
