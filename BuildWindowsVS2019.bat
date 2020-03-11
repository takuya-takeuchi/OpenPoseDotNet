@echo off
@rem ***************************************
@rem Arguments
@rem %1: Build Configuration (Release/Debug)
@rem ***************************************

if "%1"=="" ( 
@echo Error: Specify build configuration [Release/Debug]
@exit /B
)

git submodule update --init --recursive

set CURDIR=%cd%
set OUTPUT=build
cd openpose
mkdir %OUTPUT%
cd %OUTPUT%
cmake -G "Visual Studio 16 2019" -A x64 ^
      ..
cmake --build . --config %1
cd %CURDIR%