@echo off
@rem ***************************************
@rem Arguments
@rem %1: Build Configuration (Release/Debug)
@rem ***************************************

if "%1"=="" ( 
@echo Error: Specify build configuration [Release/Debug]
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

copy ..\..\..\src\OpenPoseDotNet.Native\build\%1\OpenPoseDotNetNative.dll bin\%1\netcoreapp2.0 /y
copy ..\..\..\src\OpenPoseDotNet.Native\build\%1\OpenPoseDotNetNative.pdb bin\%1\netcoreapp2.0 /y

mkdir models\pose\body_25
copy ..\..\..\openpose\models\pose\body_25\pose_deploy.prototxt models\pose\body_25 /y
copy ..\..\..\openpose\models\pose\body_25\pose_iter_584000.caffemodel models\pose\body_25 /y

mkdir bin\%1\netcoreapp2.0\models
xcopy models bin\%1\netcoreapp2.0\models /y /s