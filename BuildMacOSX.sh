#!/bin/bash

# ***************************************
# Arguments
# $1: Build Configuration (Release/Debug)
# ***************************************
if [ $# -ne 1 ]; then
  echo "Error: Specify build configuration [Release/Debug]"
  exit 1
fi

CUDDIR=`pwd`
OUTPUT=build
cd openpose
mkdir ${OUTPUT}
cd ${OUTPUT}
cmake -D GPU_MODE=CPU_ONLY ..
cmake --build . --config Release
cd ${CURDIR}
