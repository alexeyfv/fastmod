using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

[CategoriesColumn]
[MemoryDiagnoser]
[SimpleJob(iterationCount: 20)]
public class Benchmark
{
    private const int size = 100_000;
    private uint bucketsNum = 0;
    private uint multiplier = 0;
    private int[] hashcodes = [];

    [GlobalSetup]
    public void Initialize()
    {
        hashcodes = new int[size];
        for (var i = 0; i < size; i++) hashcodes[i] = Random.Shared.Next(0, int.MaxValue);

        bucketsNum = 14591;
        multiplier = uint.MaxValue / bucketsNum;
    }

    [Benchmark(Baseline = true)]
    public uint DefaultMod()
    {
        uint sum = 0;
        for (var i = 0; i < hashcodes.Length; i++)
        {
            sum += (uint) hashcodes[i] % bucketsNum;
        }
        return sum;
    }

    [Benchmark]
    public uint FastMod()
    {
        uint sum = 0;
        for (var i = 0; i < hashcodes.Length; i++)
        {
            sum += FastMod((uint)hashcodes[i], multiplier, bucketsNum);
        }
        return sum;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static uint FastMod(uint hashcode, uint multiplier, uint bucketsNum)
    {
        return hashcode - ((hashcode * multiplier) >> 32) * bucketsNum;
    }
}
