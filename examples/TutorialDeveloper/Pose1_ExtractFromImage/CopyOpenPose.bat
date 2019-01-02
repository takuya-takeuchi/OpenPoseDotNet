@echo off
@rem ***************************************
@rem Arguments
@rem %1: Build Configuration (Release/Debug)
@rem ***************************************

if "%1"=="" ( 
@echo Error: Speficy build configuration [Release/Debug]
@exit /B
)

mkdir bin\%1\netcoreapp2.0

if "%1"=="Release" (
  copy ..\..\..\openpose\build\x64\%1\openpose.dll bin\%1\netcoreapp2.0\openpose.dll /y
) else if "%1"=="Debug" (
  copy ..\..\..\openpose\build\x64\%1\openposed.dll bin\%1\netcoreapp2.0\openposed.dll /y
  copy ..\..\..\openpose\build\x64\%1\openposed.pdb bin\%1\netcoreapp2.0\openposed.pdb /y
)

xcopy ..\..\..\openpose\build\bin\*  bin\%1\netcoreapp2.0 /q /y

if "%1"=="Release" (
  copy ..\..\..\src\OpenPoseDotNet.Native\build\%1\OpenPoseDotNet.Native.dll bin\%1\netcoreapp2.0 /y
) else if "%1"=="Debug" (
  copy ..\..\..\src\OpenPoseDotNet.Native\build\%1\OpenPoseDotNet.Native.dll bin\%1\netcoreapp2.0 /y
  copy ..\..\..\src\OpenPoseDotNet.Native\build\%1\OpenPoseDotNet.Native.pdb bin\%1\netcoreapp2.0 /y
)

mkdir examples\media
copy ..\..\..\openpose\examples\media\COCO_val2014_000000000192.jpg examples\media /y

mkdir models\pose\body_25
copy ..\..\..\openpose\models\pose\body_25\pose_deploy.prototxt models\pose\body_25 /y
copy ..\..\..\openpose\models\pose\body_25\pose_iter_584000.caffemodel models\pose\body_25 /y

mkdir models\face
copy ..\..\..\openpose\models\face\pose_deploy.prototxt models\face /y
copy ..\..\..\openpose\models\face\pose_iter_116000.caffemodel models\face /y

mkdir models\hand
copy ..\..\..\openpose\models\hand\pose_deploy.prototxt models\hand /y
copy ..\..\..\openpose\models\hand\pose_iter_102000.caffemodel models\hand /y

mkdir models\cameraParameters
mkdir models\cameraParameters\flir
copy ..\..\..\openpose\models\cameraParameters\flir\17012332.xml.example models\cameraParameters\flir /y

mkdir bin\%1\netcoreapp2.0\models
xcopy models bin\%1\netcoreapp2.0\models /y /s

mkdir bin\%1\netcoreapp2.0\examples
xcopy examples bin\%1\netcoreapp2.0\examples /y /s