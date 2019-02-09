#ifndef _CPP_OP_GPU_GPU_H_
#define _CPP_OP_GPU_GPU_H_

#include "../shared.h"

DLLEXPORT int op_getGpuNumber()
{
    return op::getGpuNumber();
}

DLLEXPORT op::GpuMode op_getGpuMode()
{
    return op::getGpuMode();
}

#endif