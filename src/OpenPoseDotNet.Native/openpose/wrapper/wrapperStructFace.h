#ifndef _CPP_OP_WRAPPER_WRAPPERSTRUCTFACE_H_
#define _CPP_OP_WRAPPER_WRAPPERSTRUCTFACE_H_

#include "../shared.h"

DLLEXPORT op::WrapperStructFace* op_wrapper_wrapperStructFace_new(const bool enable)
{
    return new op::WrapperStructFace(enable);
}

DLLEXPORT void op_wrapper_wrapperStructFace_delete(op::WrapperStructFace* face)
{
    delete face;
}

DLLEXPORT bool op_wrapper_wrapperStructFace_get_enable(op::WrapperStructFace* face)
{
    return face->enable;
}

DLLEXPORT void op_wrapper_wrapperStructFace_set_enable(op::WrapperStructFace* face, const bool enable)
{
    face->enable = enable;
}

#endif