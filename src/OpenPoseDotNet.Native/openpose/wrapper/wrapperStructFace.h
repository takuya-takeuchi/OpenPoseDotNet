#ifndef _CPP_OP_WRAPPER_WRAPPERSTRUCTFACE_H_
#define _CPP_OP_WRAPPER_WRAPPERSTRUCTFACE_H_

#include "../shared.h"

DLLEXPORT op::WrapperStructFace* op_wrapperStructFace_new(const bool enable,
                                                          const op::Detector detector,
                                                          const op::Point<int>* netInputSize,
                                                          const op::RenderMode renderMode,
                                                          const float alphaKeypoint,
                                                          const float alphaHeatMap,
                                                          const float renderThreshold)
{
    return new op::WrapperStructFace(enable,
                                     detector,
                                     *netInputSize,
                                     renderMode,
                                     alphaKeypoint,
                                     alphaHeatMap,
                                     renderThreshold);
}

DLLEXPORT void op_wrapperStructFace_delete(op::WrapperStructFace* face)
{
    delete face;
}

DLLEXPORT bool op_wrapperStructFace_get_enable(op::WrapperStructFace* face)
{
    return face->enable;
}

DLLEXPORT void op_wrapperStructFace_set_enable(op::WrapperStructFace* face, const bool enable)
{
    face->enable = enable;
}

#endif