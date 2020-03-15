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
OUTPUT=build_osx

mkdir -p ${OUTPUT} && cd ${OUTPUT}
cmake ..
cmake --build . --config $1
cd  ${CURDIR}
