#ifndef _CPP_OP_CORE_MATRIX_H_
#define _CPP_OP_CORE_MATRIX_H_

#include "../shared.h"

DLLEXPORT void op_core_Matrix_delete(op::Matrix* matrix)
{
    delete matrix;
}

DLLEXPORT bool op_core_Matrix_empty(op::Matrix* mat)
{
    return mat->empty();
}

DLLEXPORT cv::Mat* op_core_Matrix_OP_OP2CVCONSTMAT(op::Matrix* matrix)
{
    auto& opMat = *matrix;
    const auto ret = OP_OP2CVCONSTMAT(opMat);
    return new cv::Mat(ret);
}

DLLEXPORT cv::Mat* op_core_Matrix_OP_OP2CVMAT(op::Matrix* matrix)
{
    auto& opMat = *matrix;
    const auto ret = OP_OP2CVMAT(opMat);
    return new cv::Mat(ret);
}

DLLEXPORT op::Matrix* op_core_Matrix_OP_CV2OPCONSTMAT(cv::Mat* matrix)
{
    auto& opMat = *matrix;
    const auto ret = OP_CV2OPCONSTMAT(opMat);
    return new op::Matrix(ret);
}

#endif