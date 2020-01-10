# TOTORIAL

## Examples usage

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

    Console.WriteLine("results = [{0}]", string.Join('|', results));

    // results = [ปลา|ที่|ใหญ่|ที่สุด|ใน|โลก|คือ|ปารีส|ชุบ|แป้ง|ทอด]
}
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

    Console.WriteLine("results = [{0}]", string.Join('|', results));

    // results = [ปลาที่ใหญ่ที่สุดในโลกคือ|ปารีสชุบแป้งทอด]
}
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

    var tokenizer = new ThaiTokenizer();
    var results = tokenizer.SubThaiStringAndCount(input, 24);

    foreach (var result in results) {
        Console.WriteLine("word = {0}, countable = {1}, uncountable = {2}", result.Words, result.Countable, result.Uncountable);
    }

    // Words = ถ้าหากรักนี้ ไม่บอกไม่พูดไม่กล่าว, Countable = 24, Uncountable = 9
    // Words =  แล้วเขาจะรู้ว่ารักหรือเปล่า, Countable = 21, Uncountable = 7
}
```

### Append custom dictionary

```cs
using System;
using System.Collections.Generic;
using ThaiStringTokenizer;

public void SplitWord()
{
    var customDictionary = new List<string> { "หวัดดี", "หวักลี", "เชอแตม" };
    var tokenizer = new ThaiTokenizer(customDictionary);
    var text = "หวักลีหวัดดีปลาที่ใหญ่ที่สุดในโลกคือปารีสชุบแป้งทอดเชอแตม";
    var results = tokenizer.Split(text);

    Console.WriteLine("results = [{0}]", string.Join('|', results));

    // results = [หวักลี|หวัดดี|ปลา|ที่|ใหญ่|ที่สุด|ใน|โลก|คือ|ปารีส|ชุบ|แป้ง|ทอด|เชอแตม]
}
```

### Do not remove space

```cs
using System;
using System.Collections.Generic;
using ThaiStringTokenizer;

public void SubstringThaiStyle()
{
    var tokenizer = new ThaiTokenizer();
    var text = "อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์";
    var maxLenght = 50;
    var results = tokenizer.SubThaiString(text, maxLength);

    Console.WriteLine("results = [{0}]", string.Join('|', results));

    // results = [อาราธนาพระพุทธ อาราธนาพระธรรม อาราธนาพระสงฆ์]
}
```

### Short word 1

```cs
using System;
using System.Collections.Generic;
using ThaiStringTokenizer;

public void SplitWord()
{
    var tokenizer = new ThaiTokenizer(matchingMode: MatchingMode.Shortest);
    var text = "เจริญ";
    var results = tokenizer.Split(text);

    Console.WriteLine("results = [{0}]", string.Join('|', results));

    // results = [เจ|ริญ]
}
```

### Short word 2

```cs
using System;
using System.Collections.Generic;
using ThaiStringTokenizer;

public void SplitWord()
{
    var tokenizer = new ThaiTokenizer(matchingMode: MatchingMode.Longest);
    var text = "เจริญ";
    var results = tokenizer.Split(text);

    Console.WriteLine("results = [{0}]", string.Join('|', results));

    // results = [เจริญ]
}
```

### Short word 3

```cs
using System;
using System.Collections.Generic;
using ThaiStringTokenizer;

public void SplitWord()
{
    var tokenizer = new ThaiTokenizer(matchingMode: MatchingMode.Shortest);
    var text = "ศิริวิมล";
    var results = tokenizer.Split(text);

    Console.WriteLine("results = [{0}]", string.Join('|', results));

    // results = [ศิ|ริ|วิ|มล]
}
```
