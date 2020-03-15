# Body From Image Default

## Quick Start

#### 1. Build OpenPose

````dos
> cd <OpenPoseDotNet_dir>
> git submodule update --inti --recursive
> cd src\OpenPoseDotNet.Native
> pwsh Build.ps1 <Debug/Release> <cpu/cuda> 64 desktop <2015/2017/2019> <92/100/101>
````

#### 2. Try Tutorial

````dos
> cd <OpenPoseDotNet_dir>\examples\TutorialApiCpp\01_BodyFromImageDefault
> SymlinkBinary.bat <Debug/Release> build_win_desktop_<cpu/cuda>_x64
> dotnet run -c Release  -i "examples\media\COCO_val2014_000000000192.jpg"
````

<img src="images/example_turorial_1.png"/>