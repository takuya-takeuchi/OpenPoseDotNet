# ![Alt text](nuget/pose48.png "OpenPose.Net") OpenPose.Net [![GitHub license](https://img.shields.io/github/license/mashape/apistatus.svg)]()

OpenPose wrapper written in C++ and C# for Windows  
OpenPoseDotNet is .NET Standard library. It could work on Mac and Linux.

### :warning: Warning

OpenPoseDotNet adopts MIT license but OpenPose doesn't.
OpenPose adopts other license and it allows to use for only **ACADEMIC OR NON-PROFIT ORGANIZATION NONCOMMERCIAL RESEARCH**.  
I never guarantee that the license issue will not occur by using OpenPoseDotNet.

## Package

|Package|NuGet|
|---|---|
|OpenPoseDotNet|[![NuGet version](https://img.shields.io/nuget/v/OpenPoseDotNet.svg)](https://www.nuget.org/packages/OpenPoseDotNet)|

## Quick Start

#### 1. Build

You can sepcify Visual Studio vesion and CUDA version. 

````dos
> cd <OpenPoseDotNet_dir>
> git submodule update --init --recursive
> cd src\OpenPoseDotNet.Native
> pwsh Build.ps1 <Debug/Release> <cpu/cuda> 64 desktop <2015/2017/2019> <92/100/101/102/110/111/112/113/114/115/116>
````

After build, you should see artifacts in src\OpenPoseDotNet.Native\build_win_desktop_<cpu/cuda>_x64\<Debug/Release>.

#### 2. Try Tutorial

````dos
> cd examples
> pwsh SymlinkBinary.ps1 <Debug/Release> build_win_desktop_<cpu/cudaxxx>_x64
> cd TutorialApiCpp\01_BodyFromImageDefault
> dotnet run -c Release  -i "examples\media\COCO_val2014_000000000192.jpg"
````

<img src="images/example_turorial_1.png"/>

### :bulb: NOTE

Currently, Windows prebuild binary is not available.

## Dependencies Libraries and Products

#### [gflags](https://github.com/gflags/gflags)

> **License:** The 3-clause BSD License
>
> **Author:** Google
> 
> **Principal Use:** The commandline flags processing for OpenPose and OpenPoseDotNet.

#### [OpenPose](https://github.com/CMU-Perceptual-Computing-Lab/openpose)

> **License:** ACADEMIC OR NON-PROFIT ORGANIZATION NONCOMMERCIAL RESEARCH USE ONLY
>
> **Author:** Carnegie Mellon University Perceptual Computing Lab
> 
> **Principal Use:** A toolkit for Real-time multi-person keypoint detection library for body, face, hands, and foot estimation. Main goal of OpenPoseDotNet is what wraps OpenPose by C#.

#### [Microsoft.Extensions.CommandLineUtils](https://www.asp.net/)

> **License:** MS-.NET-Library-JS License
>
> **Author:** Microsoft
> 
> **Principal Use:** Command-line parsing for example application

#### [OpenCV](https://opencv.org/)

> **License:** The 3-clause BSD License
>
> **Author:** Intel Corporation, Willow Garage, Itseez
> 
> **Principal Use:** OpenPose and OpenPoseDotNet uses to read and show image data.