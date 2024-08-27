using System.Runtime.CompilerServices;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Diagnosers;

namespace Benchmark;

[CategoriesColumn]
[DisassemblyDiagnoser(printSource: true, exportCombinedDisassemblyReport: true)]
[MemoryDiagnoser]
public class Benchmark
{
    private const int size = 100_000;
    private uint bucketsNum = 0;
    private ulong multiplier = 0;
    private int[] hashcodes = [];

    [GlobalSetup]
    public void Initialize()
    {
        hashcodes = new int[size];
        for (var i = 0; i < size; i++) hashcodes[i] = Random.Shared.Next(0, int.MaxValue);

        bucketsNum = 14591;
        multiplier = ulong.MaxValue / bucketsNum + 1;

        for (var i = 0; i < hashcodes.Length; i++)
        {
            var a = (uint)hashcodes[i] % bucketsNum;
            var b = FastMod((uint)hashcodes[i], multiplier, bucketsNum);

            if (a == b) continue;
            throw new InvalidOperationException($"a: {a}, b: {b}, hashcode: {hashcodes[i]}, multiplier: {multiplier}, bucketsNum: {bucketsNum}");
        }
    }

    [Benchmark(Baseline = true)]
    public uint DefaultMod()
    {
        uint sum = 0;
        for (var i = 0; i < hashcodes.Length; i++)
        {
            sum += (uint)hashcodes[i] % bucketsNum;
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
    private static uint FastMod(uint hashcode, ulong multiplier, uint bucketsNum)
    {
        return (uint)(((((multiplier * hashcode) >> 32) + 1) * bucketsNum) >> 32);
    }
}
