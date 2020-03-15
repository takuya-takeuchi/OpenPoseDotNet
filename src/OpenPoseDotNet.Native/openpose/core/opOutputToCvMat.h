#ifndef _CPP_OP_CORE_OP_OUTPUT_TO_CV_MAT_HPP
#define _CPP_OP_CORE_OP_OUTPUT_TO_CV_MAT_HPP

#include "../shared.h"

DLLEXPORT op::OpOutputToCvMat* op_core_OpOutputToCvMat_new()
{
    return new op::OpOutputToCvMat();
}

DLLEXPORT void op_core_OpOutputToCvMat_delete(op::OpOutputToCvMat* mat)
{
    delete mat;
}

DLLEXPORT op::Matrix* op_core_OpOutputToCvMat_formatToCvMat(op::OpOutputToCvMat* mat, const op::Array<float>* outputData)
{
    const auto& tmp = *outputData;
    const auto ret = mat->formatToCvMat(tmp);
    return new op::Matrix(ret);
}

#endif