using AdventOfCode2022.Benchmark;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Running;

var config = DefaultConfig.Instance.WithArtifactsPath(@".");

BenchmarkRunner.Run<SolutionsBenchmarker>(config);
