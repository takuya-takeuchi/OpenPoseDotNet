cmake_minimum_required(VERSION 3.0.0)
set(PROJ_NAME OpenPoseDotNetNative)

project(${PROJ_NAME} VERSION 0.0.0)

# Version info
set(VERSION_MAJOR 1)
set(VERSION_MINOR 5)
set(VERSION_PATCH 1)
set(VERSION_DATE 20191116)

# Only GCC requires -fPIC
if ("${CMAKE_CXX_COMPILER_ID}" STREQUAL "GNU")
	set(CMAKE_CXX_FLAGS "-fPIC")
endif()

if (CMAKE_GENERATOR MATCHES "Visual Studio")
	# C4819: The file contains a character that cannot be represented in the current code page
	# C4503: identifier' : decorated name length exceeded, name was truncated
	set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} /wd4819 /wd4503")
endif()

# Select the release build type by default
if (NOT CMAKE_BUILD_TYPE)
    set(CMAKE_BUILD_TYPE "Release")
endif()

# get root directory path
get_filename_component(OPENPOSEDOTNET_ROOT_DIR "../.." ABSOLUTE)

# include 3rdparty libraries
if (MSVC OR MSYS OR MINGW)
    include_directories("${OPENPOSEDOTNET_ROOT_DIR}/openpose/include"
                        "${OPENPOSEDOTNET_ROOT_DIR}/openpose/3rdparty/windows/opencv/include"
                        "${OPENPOSEDOTNET_ROOT_DIR}/openpose/3rdparty/windows/caffe3rdparty/include")
else()
    find_package( GFlags REQUIRED )
    find_package( OpenCV REQUIRED )
    include_directories("${OPENPOSEDOTNET_ROOT_DIR}/openpose/include")
endif()

FILE(GLOB_RECURSE HEADERS ${PROJECT_SOURCE_DIR}/openpose/*.h)
FILE(GLOB_RECURSE SOURCES ${PROJECT_SOURCE_DIR}/openpose/*.cpp)

configure_file(
    ${CMAKE_CURRENT_SOURCE_DIR}/version.rc.in
    ${CMAKE_CURRENT_BINARY_DIR}/version.rc
    @ONLY)

# include 3rdparty libraries
if (MSVC OR MSYS OR MINGW)
    set(STATIC_LIBRARIES
        ${OPENPOSEDOTNET_ROOT_DIR}/openpose/3rdparty/windows/opencv/x64/vc14/lib/opencv_world411.lib
        optimized ${OPENPOSEDOTNET_ROOT_DIR}/openpose/3rdparty/windows/caffe3rdparty/lib/gflags.lib
        optimized ${OPENPOSEDOTNET_ROOT_DIR}/openpose/build/src/openpose/Release/openpose.lib
        debug ${OPENPOSEDOTNET_ROOT_DIR}/openpose/3rdparty/windows/caffe3rdparty/lib/gflagsd.lib
        debug ${OPENPOSEDOTNET_ROOT_DIR}/openpose/build/src/openpose/Debug/openposed.lib
    )
elseif(APPLE)
    set(STATIC_LIBRARIES
        opencv_imgproc
        opencv_imgcodecs
        opencv_highgui
        optimized gflags
        optimized ${OPENPOSEDOTNET_ROOT_DIR}/openpose/build_osx/src/openpose/libopenpose.dylib
        debug gflagsd
        debug ${OPENPOSEDOTNET_ROOT_DIR}/openpose/build_osx/src/openpose/libopenposed.dylib
    )
elseif(UNIX AND NOT APPLE)
    set(STATIC_LIBRARIES
        opencv_imgproc
        optimized gflags
        optimized ${OPENPOSEDOTNET_ROOT_DIR}/openpose_linux/build/src/openpose/libopenpose.so
        debug gflagsd
        debug ${OPENPOSEDOTNET_ROOT_DIR}/openpose_linux/build/src/openpose/libopenposed.so
    )
else()
    message(FATAL_ERROR "Failed to link library")
endif()

add_library(${PROJ_NAME} SHARED ${HEADERS}
                                ${SOURCES}
                                ${CMAKE_CURRENT_BINARY_DIR}/version.rc)

target_link_libraries(${PROJ_NAME} ${STATIC_LIBRARIES})


enable_language(CXX)
if(APPLE)
   set(CMAKE_CXX_FLAGS "-std=c++11 -stdlib=libc++")
elseif(UNIX AND NOT APPLE)
   set(CMAKE_CXX_FLAGS "-std=c++11")
endif()
set(CMAKE_CXX_STANDARD 11)
set(CMAKE_CXX_STANDARD_REQUIRED ON)

set(CompilerFlags
    CMAKE_CXX_FLAGS
    CMAKE_CXX_FLAGS_DEBUG
    CMAKE_CXX_FLAGS_RELEASE
    CMAKE_C_FLAGS
    CMAKE_C_FLAGS_DEBUG
    CMAKE_C_FLAGS_RELEASE
)

# Replace /MDd with /MD. openposed is debug library but it does not depend on non debug runtime library
foreach(CompilerFlag ${CompilerFlags})
  string(REPLACE "/MDd" "/MD" ${CompilerFlag} "${${CompilerFlag}}")
endforeach()

set(CPACK_PROJECT_NAME ${PROJECT_NAME})
set(CPACK_PROJECT_VERSION ${PROJECT_VERSION})
include(CPack)
