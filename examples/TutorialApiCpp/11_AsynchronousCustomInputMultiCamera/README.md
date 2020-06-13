# Asynchronous Custom Input Multi Camera

:warning: CAUSION

This demo does not work. 
C++ 11_asynchronous_custom_input_multi_camera.exe also does not work. 
Maybe there is lack or parameter files.

## Quick Start

#### 1. Build OpenPose

````dos
> cd <OpenPoseDotNet_dir>
> git submodule update --init --recursive
> cd src\OpenPoseDotNet.Native
> pwsh Build.ps1 <Debug/Release> <cpu/cuda> 64 desktop <2015/2017/2019> <92/100/101>
````

#### 2. Try Tutorial

````dos
> cd <OpenPoseDotNet_dir>\examples\TutorialApiCpp\11_AsynchronousCustomInputMultiCamera
> pwsh SymlinkBinary.ps1 <Debug/Release> build_win_desktop_<cpu/cuda>_x64
> dotnet run -c Release -- -v=examples\media\video.avi -d=2
Starting OpenPose demo...
Configuring OpenPose...
Starting thread(s)...
Auto-detecting all available GPUs... Detected 1 GPU(s), using 1 of them starting at GPU 0.

Error:
There is less than 2 camera parameter matrices.

Coming from:
- D:\Works\OpenSource\OpenPoseDotNet\src\openpose\include\openpose/wrapper/wrapperAuxiliary.hpp:op::createMultiviewTDatum():1244
- D:\Works\OpenSource\OpenPoseDotNet\src\openpose\include\openpose/wrapper/wrapperAuxiliary.hpp:op::createMultiviewTDatum():1271
````

<img src="images/example_turorial_6.gif"/>