# ThaiStringTokenizer

## From 0.x.x to 1.x.x

If you specified parameter `MachingTechnique` in constructor such as

```cs
    var technique = MachingTechnique.LongestMatching;
    var thaiString = new ThaiStringTokenizer(machingTechnique: technique);
```

Just replace enum `MachingTechnique` with `MachingMode`

```cs
    var mode = MachingMode.Longest;
    var thaiString = new ThaiStringTokenizer(machingMode: mode);
```
