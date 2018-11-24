#ifndef _CPP_OP_FLAGS_H_
#define _CPP_OP_FLAGS_H_

#include "shared.h"
#include <openpose/flags.hpp>

DLLEXPORT bool op_flags_get_disable_multi_thread()
{
    return FLAGS_disable_multi_thread;
}

DLLEXPORT void op_flags_set_disable_multi_thread(bool value)
{
    FLAGS_disable_multi_thread = value;
}

#endif