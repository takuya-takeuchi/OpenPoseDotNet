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
OUTPUT=build_linux
cd openpose

# *******************************************************************
# https://github.com/CMU-Perceptual-Computing-Lab/openpose/issues/939
# remove modification
cd 3rdparty/caffe
git checkout .
git checkout master
cd ../..

# suppress checkout caffe repository
cat CMakeLists.txt | (rm CMakeLists.txt; sed -e 's@ execute_process(COMMAND git checkout master WORKING_DIRECTORY ${CMAKE_SOURCE_DIR}/3rdparty/caffe)@#execute_process(COMMAND git checkout master WORKING_DIRECTORY ${CMAKE_SOURCE_DIR}/3rdparty/caffe)@g' > CMakeLists.txt)

# remove clip_layer
CAFFEPROTO=3rdparty/caffe/src/caffe/proto/caffe.proto
LAYERFACTORY=3rdparty/caffe/src/caffe/layer_factory.cpp
cat ${CAFFEPROTO} | (rm ${CAFFEPROTO}; sed -e 's/optional ClipParameter clip_param/\/\/optional ClipParameter clip_param/g' > ${CAFFEPROTO})
cat ${LAYERFACTORY} | (rm ${LAYERFACTORY}; sed -e 's@#include "caffe/layers/clip_layer.hpp"@//#include "caffe/layers/clip_layer.hpp"@g' > ${LAYERFACTORY})
rm 3rdparty/caffe/src/caffe/layers/clip_layer.cpp
rm 3rdparty/caffe/src/caffe/layers/clip_layer.cu
rm 3rdparty/caffe/include/caffe/layers/clip_layer.hpp
# *******************************************************************

mkdir ${OUTPUT}
cd ${OUTPUT}
cmake ..
cmake --build . --config Release
cd ${CURDIR}
