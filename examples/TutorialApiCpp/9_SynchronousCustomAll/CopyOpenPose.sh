#!/bin/bash

# ***************************************
# Arguments
# $1: Build Configuration (Release/Debug)
# ***************************************
if [ $# -ne 1 ]; then
  echo "Error: Specify build configuration [Release/Debug]"
  exit 1
fi

mkdir -p bin/$1/netcoreapp2.0

if [ $1 = "Release" ]; then
  cp ../../../openpose/build/src/openpose/libopenpose.so bin/$1/netcoreapp2.0
elif [ $1 = "Debug" ]; then
  cp ../../../openpose/build/src/openpose/libopenposed.so bin/$1/netcoreapp2.0
fi

if [ $1 = "Release" ]; then
  cp ../../../src/OpenPoseDotNet.Native/build/libOpenPoseDotNet.Native.so bin/$1/netcoreapp2.0
elif [ $1 = "Debug" ]; then
  cp ../../../src/OpenPoseDotNet.Native/build/libOpenPoseDotNet.Native.so bin/$1/netcoreapp2.0
fi

mkdir -p examples/media
cp ../../../openpose/examples/media/*.jpg examples/media

mkdir -p models/pose/body_25
cp ../../../openpose/models/pose/body_25/pose_deploy.prototxt models/pose/body_25
cp ../../../openpose/models/pose/body_25/pose_iter_584000.caffemodel models/pose/body_25

mkdir -p bin/$1/netcoreapp2.0/models
cp -Rf models bin/$1/netcoreapp2.0/models

mkdir -p bin/$1/netcoreapp2.0/examples
cp -Rf examples bin/$1/netcoreapp2.0/examples
