cmake_minimum_required(VERSION 3.0.0)
set(PROJ_NAME OpenPoseDotNet.Native)

project(${PROJ_NAME} VERSION 0.0.0)

# Version info
set(VERSION_MAJOR 0)
set(VERSION_MINOR 1)
set(VERSION_PATCH 0)
set(VERSION_DATE 20181124)

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

include_directories("../../openpose/include",
                    "../../openpose/3rdparty/windows/opencv/include",
                    "../../openpose/3rdparty/windows/caffe3rdparty/include")

FILE(GLOB_RECURSE HEADERS ${PROJECT_SOURCE_DIR}/openpose/*.h)
FILE(GLOB_RECURSE SOURCES ${PROJECT_SOURCE_DIR}/openpose/*.cpp)

configure_file(
    ${CMAKE_CURRENT_SOURCE_DIR}/version.rc.in
    ${CMAKE_CURRENT_BINARY_DIR}/version.rc
    @ONLY)

set(STATIC_LIBRARIES
    optimized ../../../openpose/3rdparty/windows/opencv/x64/vc14/lib/opencv_world310
    optimized ../../../openpose/3rdparty/windows/caffe3rdparty/lib/gflags
    optimized ../../../openpose/build/src/openpose/Release/openpose
    debug ../../../openpose/3rdparty/windows/opencv/x64/vc14/lib/opencv_world310d
    debug ../../../openpose/3rdparty/windows/caffe3rdparty/lib/gflagsd
    debug ../../../openpose/build/src/openpose/Debug/openposed
)

add_library(${PROJ_NAME} SHARED ${HEADERS}
                                ${SOURCES}
                                ${CMAKE_CURRENT_BINARY_DIR}/version.rc)

target_link_libraries(${PROJ_NAME} ${STATIC_LIBRARIES})


enable_language(CXX)
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