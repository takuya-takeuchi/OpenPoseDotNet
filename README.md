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

#### 1. Build OpenPose

````dos
> BuildWindowsVS2015.bat <Debug/Release>
````

#### 2. Build OpenPoseDotNet

````dos
> cd src\OpenPoseDotNet.Native
> BuildWindowsVS2015.bat <Debug/Release>
````

#### 3. Try Tutorial

````dos
> cd examples\TutorialApiCpp\01_BodyFromImageDefault
> SymlinkBinary.bat <Debug/Release>
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