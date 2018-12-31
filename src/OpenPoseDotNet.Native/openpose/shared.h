#ifndef _CPP_SHARED_H_
#define _CPP_SHARED_H_

#include <openpose/headers.hpp>

#include "export.h"

enum struct array_element_type : int
{
    Float = 0,
};

enum struct data_type : int
{
    Default = 0,
    Custom  = 1,
};

#define ERR_OK                                                            0x00000000

// common
#define ERR_COMMON_ERROR                                                  0x70000000
#define ERR_COMMON_TYPE_NOT_SUPPORT                  -(ERR_COMMON_ERROR | 0x00000001)

#endif