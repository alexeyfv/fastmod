```

BenchmarkDotNet v0.13.12, Windows 11 (10.0.22631.4037/23H2/2023Update/SunValley3)
AMD Ryzen 5 3500U with Radeon Vega Mobile Gfx, 1 CPU, 8 logical and 4 physical cores
.NET SDK 8.0.203
  [Host]     : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2
  DefaultJob : .NET 8.0.3 (8.0.324.11423), X64 RyuJIT AVX2


```
| Method     | Mean     | Error    | StdDev   | Ratio    | RatioSD | Code Size | Allocated | Alloc Ratio |
|----------- |---------:|---------:|---------:|---------:|--------:|----------:|----------:|------------:|
| DefaultMod | 625.0 μs | 11.83 μs | 11.07 μs | baseline |         |      68 B |         - |          NA |
| FastMod    | 105.6 μs |  2.01 μs |  2.32 μs |     -83% |    2.7% |      82 B |         - |          NA |
