#ifndef _CPP_OP_CORE_MACROS_H_
#define _CPP_OP_CORE_MACROS_H_

#include "../shared.h"

DLLEXPORT std::string* op_core_macros_get_OPEN_POSE_NAME_STRING()
{
    return new std::string(OPEN_POSE_NAME_STRING.c_str());
}

DLLEXPORT std::string* op_core_macros_get_OPEN_POSE_VERSION_STRING()
{
    return new std::string(OPEN_POSE_VERSION_STRING.c_str());
}

DLLEXPORT std::string* op_core_macros_get_OPEN_POSE_NAME_AND_VERSION()
{
    return new std::string(OPEN_POSE_NAME_AND_VERSION.c_str());
}

#endif