# Nensor
Lightweight .NET Tensor library with hardware intrinsic support.

Now based on the architecture of [TinyGrad](https://github.com/tinygrad/tinygrad)

## What is this?

A library that provides a simple way to work with Tensors (multi-dimensional arrays) of abitrary type, size and shape. In a similar vein to Pytorch, Numpy or Tensorflow, but with the following goals:

* Simple and lightweight with Zero dependencies - No BLAS, BLIS, MKL or any giant C++ templated packages required.
* Using only managed code (no C or C++ bindings unless absolutely necessary).
* Fully type and memory safe. - Unlike C libraries.
* Thread-safe. - Unlike libraries that call out to Python.
* Lazy evaluation - Computation is deferred until the graph is realized (graph based non-destructive tensor operations).
* Acceptable performance, while not necessarily state of the art. - Utilizing hardware intrinsics AVX512, AvdSimd (ARM) etc.

## Why would anyone do this?

1. To learn more about the logic and math behind libraries Numpy and Tensorflow.
2. To experiment with .NET generic math.
3. To see how far .NET performance can be pushed.

## Status

Very experimental.

## How to contribute

Grab the code and play, you will probably want to use [Visual Studio Code](https://code.visualstudio.com/) and [.NET 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0).

