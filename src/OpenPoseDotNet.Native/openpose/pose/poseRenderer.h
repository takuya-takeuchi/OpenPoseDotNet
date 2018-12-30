#ifndef _CPP_OP_POSE_POSE_RENDERER_H_
#define _CPP_OP_POSE_POSE_RENDERER_H_

#include "../shared.h"

DLLEXPORT void op_PoseRenderer_initializationOnThread(op::PoseRenderer* renderer)
{
    renderer->initializationOnThread();
}

#endif