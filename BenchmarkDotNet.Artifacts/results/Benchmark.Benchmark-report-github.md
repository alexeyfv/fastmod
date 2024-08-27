```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method     | Mean     | Error    | StdDev   | Ratio    | RatioSD | Code Size | Allocated | Alloc Ratio |
|----------- |---------:|---------:|---------:|---------:|--------:|----------:|----------:|------------:|
| DefaultMod | 666.3 μs | 12.51 μs | 11.09 μs | baseline |         |      49 B |         - |          NA |
| FastMod    | 111.1 μs |  2.18 μs |  4.30 μs |     -83% |    5.5% |      82 B |         - |          NA |
