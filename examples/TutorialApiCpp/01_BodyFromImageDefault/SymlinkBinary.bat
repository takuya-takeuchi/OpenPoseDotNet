@echo off
@rem ***************************************
@rem Arguments
@rem %1: Build Configuration (Release/Debug)
@rem ***************************************

if "%1"=="" ( 
@echo Error: Specify build_win configuration [Release/Debug]
@exit /B
)

if "%2"=="" ( 
@echo Error: Specify build directory of OpenPoseDotNet.Native [build_win_desktop_<cpu/cuda>_x64]
@exit /B
)

@set ROOT=%~dp0
@for %%a in ("%ROOT%") do set "p_dir=%%~dpa"
@for %%a in (%p_dir:~0,-1%) do set "p_dir=%%~dpa"
@for %%a in (%p_dir:~0,-1%) do set "p_dir=%%~dpa"
@for %%a in (%p_dir:~0,-1%) do set "p_dir=%%~dpa"
@set ROOT=%p_dir%
@set BIN_DIR=%ROOT%\src\OpenPoseDotNet.Native\%2\%1
@set NATIVE_DIR=%BIN_DIR%
@set OP_ROOT=%ROOT%src\openpose
@set OP_DIR=%ROOT%src\OpenPoseDotNet.Native\%2\%1
@set DIR=bin\%1\netcoreapp2.0

@mkdir %DIR%

@del "%DIR%\openpose.dll"
@del "%DIR%\OpenPoseDotNetNative.dll"
@rmdir models
@rmdir examples
@del "%DIR%\boost_chrono-vc140-mt-1_61.dll"
@del "%DIR%\boost_filesystem-vc140-mt-1_61.dll"
@del "%DIR%\boost_filesystem-vc141-mt-x64-1_69.dll"
@del "%DIR%\boost_python-vc140-mt-1_61.dll"
@del "%DIR%\boost_system-vc140-mt-1_61.dll"
@del "%DIR%\boost_thread-vc140-mt-1_61.dll"
@del "%DIR%\boost_thread-vc141-mt-x64-1_69.dll"
@del "%DIR%\caffe.dll"
@del "%DIR%\caffehdf5.dll"
@del "%DIR%\caffehdf5_hl.dll"
@del "%DIR%\caffezlib1.dll"
@del "%DIR%\cublas64_80.dll"
@del "%DIR%\cublas64_100.dll"
@del "%DIR%\cudart64_80.dll"
@del "%DIR%\cudart64_100.dll"
@del "%DIR%\cudnn64_5.dll"
@del "%DIR%\cudnn64_7.dll"
@del "%DIR%\curand64_80.dll"
@del "%DIR%\curand64_100.dll"
@del "%DIR%\gflags.dll"
@del "%DIR%\gflagsd.dll"
@del "%DIR%\glog.dll"
@del "%DIR%\glogd.dll"
@del "%DIR%\libgcc_s_seh-1.dll"
@del "%DIR%\libgfortran-3.dll"
@del "%DIR%\libopenblas.dll"
@del "%DIR%\libquadmath-0.dll"
@del "%DIR%\opencv_ffmpeg401_64.dll"
@del "%DIR%\opencv_videoio_ffmpeg411_64.dll"
@del "%DIR%\opencv_world401.dll"
@del "%DIR%\opencv_world401d.dll"
@del "%DIR%\opencv_world411.dll"
@del "%DIR%\opencv_world411d.dll"
@del "%DIR%\python27.dll"
@del "%DIR%\VCRUNTIME140.dll"

@mklink "%DIR%\openpose.dll" "%OP_DIR%\openpose.dll"
@mklink "%DIR%\OpenPoseDotNetNative.dll" "%NATIVE_DIR%\OpenPoseDotNetNative.dll"
@mklink /d models "%OP_ROOT%"\models
@mklink /d examples "%OP_ROOT%"\examples
@mklink "%DIR%\boost_chrono-vc140-mt-1_61.dll" "%BIN_DIR%\boost_chrono-vc140-mt-1_61.dll"
@mklink "%DIR%\boost_filesystem-vc140-mt-1_61.dll" "%BIN_DIR%\boost_filesystem-vc140-mt-1_61.dll"
@mklink "%DIR%\boost_filesystem-vc141-mt-x64-1_69.dll" "%BIN_DIR%\boost_filesystem-vc141-mt-x64-1_69.dll"
@mklink "%DIR%\boost_python-vc140-mt-1_61.dll" "%BIN_DIR%\boost_python-vc140-mt-1_61.dll"
@mklink "%DIR%\boost_system-vc140-mt-1_61.dll" "%BIN_DIR%\boost_system-vc140-mt-1_61.dll"
@mklink "%DIR%\boost_thread-vc140-mt-1_61.dll" "%BIN_DIR%\boost_thread-vc140-mt-1_61.dll"
@mklink "%DIR%\boost_thread-vc141-mt-x64-1_69.dll" "%BIN_DIR%\boost_thread-vc141-mt-x64-1_69.dll"
@mklink "%DIR%\caffe.dll" "%BIN_DIR%\caffe.dll"
@mklink "%DIR%\caffehdf5.dll" "%BIN_DIR%\caffehdf5.dll"
@mklink "%DIR%\caffehdf5_hl.dll" "%BIN_DIR%\caffehdf5_hl.dll"
@mklink "%DIR%\caffezlib1.dll" "%BIN_DIR%\caffezlib1.dll"
@mklink "%DIR%\cublas64_80.dll" "%BIN_DIR%\cublas64_80.dll"
@mklink "%DIR%\cublas64_100.dll" "%BIN_DIR%\cublas64_100.dll"
@mklink "%DIR%\cudart64_80.dll" "%BIN_DIR%\cudart64_80.dll"
@mklink "%DIR%\cudart64_100.dll" "%BIN_DIR%\cudart64_100.dll"
@mklink "%DIR%\cudnn64_5.dll" "%BIN_DIR%\cudnn64_5.dll"
@mklink "%DIR%\cudnn64_7.dll" "%BIN_DIR%\cudnn64_7.dll"
@mklink "%DIR%\curand64_80.dll" "%BIN_DIR%\curand64_80.dll"
@mklink "%DIR%\curand64_100.dll" "%BIN_DIR%\curand64_100.dll"
@mklink "%DIR%\gflags.dll" "%BIN_DIR%\gflags.dll"
@mklink "%DIR%\gflagsd.dll" "%BIN_DIR%\gflagsd.dll"
@mklink "%DIR%\glog.dll" "%BIN_DIR%\glog.dll"
@mklink "%DIR%\glogd.dll" "%BIN_DIR%\glogd.dll"
@mklink "%DIR%\libgcc_s_seh-1.dll" "%BIN_DIR%\libgcc_s_seh-1.dll"
@mklink "%DIR%\libgfortran-3.dll" "%BIN_DIR%\libgfortran-3.dll"
@mklink "%DIR%\libopenblas.dll" "%BIN_DIR%\libopenblas.dll"
@mklink "%DIR%\libquadmath-0.dll" "%BIN_DIR%\libquadmath-0.dll"
@mklink "%DIR%\opencv_ffmpeg401_64.dll" "%BIN_DIR%\opencv_ffmpeg401_64.dll"
@mklink "%DIR%\opencv_videoio_ffmpeg411_64.dll" "%BIN_DIR%\opencv_videoio_ffmpeg411_64.dll"
@mklink "%DIR%\opencv_world401.dll" "%BIN_DIR%\opencv_world401.dll"
@mklink "%DIR%\opencv_world401d.dll" "%BIN_DIR%\opencv_world401d.dll"
@mklink "%DIR%\opencv_world411.dll" "%BIN_DIR%\opencv_world411.dll"
@mklink "%DIR%\opencv_world411d.dll" "%BIN_DIR%\opencv_world411d.dll"
@mklink "%DIR%\python27.dll" "%BIN_DIR%\python27.dll"
@mklink "%DIR%\VCRUNTIME140.dll" "%BIN_DIR%\VCRUNTIME140.dll"