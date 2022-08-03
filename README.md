# Nensor
.NET Tensor library with hardware intrinsic support

## What is this?

A library that provides a simple way to work with Tensors (mulit-dimensional arrays) of abitrary type, size and shape. In a similar vein to Numpy or Tensorflow, but  with the following goals:

* Simple and lightweight (no BLAS, BLIS, MKL or any giant C++ templated packages required).
* Using only managed code (no C or C++ bindings unless absolutely necessary).
* Fully type and memory safe. - Unlike C libraries.
* Memory efficient. - Avoiding unnecessary memory allocatiosn by using Span and ReadOnlySpan.
* Thread-safe. - Unlike libraries that call out to Python.
* Acceptable performance, while not necessarily state of the art. - Utilizing hardware intrinsics AVX512, AvdSimd (ARM) etc.
* Able to perform deferred calculations (graph based non-destructive tensor operations).

## Why would anyone do this?

1. To learn more about the logic and math behind libraries Numpy and Tensorflow.
2. To experiment with new .NET 7.0 generic math.
3. To see how far .NET performance can be pushed.

## Status

Very experimental.

## How to contribute

Grab the code and play, you will probably need [Visual Studio 2022]() and [.NET 7 (7.0.0-preview.6 at the time of writing)](https://dotnet.microsoft.com/en-us/download/dotnet/7.0).

