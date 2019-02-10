#ifndef _CPP_OP_3RDPARTY_OPENCV_MAT_H_
#define _CPP_OP_3RDPARTY_OPENCV_MAT_H_

#include "../../shared.h"

DLLEXPORT cv::Mat* op_3rdparty_cv_Mat_new()
{
    return new cv::Mat();
}

DLLEXPORT cv::Mat* op_3rdparty_cv_Mat_new2(const int rows, const int cols, const int type, void* data)
{
    return new cv::Mat(rows, cols, type, data);
}

DLLEXPORT void op_3rdparty_cv_Mat_delete(cv::Mat* mat)
{
    delete mat;
}

DLLEXPORT int op_3rdparty_cv_Mat_rows(cv::Mat* mat)
{
    return mat->rows;
}

DLLEXPORT int op_3rdparty_cv_Mat_cols(cv::Mat* mat)
{
    return mat->cols;
}

DLLEXPORT int op_3rdparty_cv_Mat_channels(cv::Mat* mat)
{
    return mat->channels();
}

DLLEXPORT bool op_3rdparty_cv_Mat_empty(cv::Mat* mat)
{
    return mat->empty();
}

DLLEXPORT void* op_3rdparty_cv_Mat_data(cv::Mat* mat)
{
    return mat->data;
}

DLLEXPORT int op_3rdparty_cv_Mat_type(const cv::Mat* mat)
{
    return mat->type();
}

DLLEXPORT void op_3rdparty_cv_Mat_convertTo(const cv::Mat* mat, cv::Mat* dst, int rtype, double alpha, double beta)
{
    auto& d = *static_cast<cv::Mat*>(dst);
    mat->convertTo(d, rtype, alpha, beta);
}

#pragma region operators

DLLEXPORT cv::MatExpr* op_3rdparty_cv_Mat_operator_add(const cv::Mat* lhs, const double rhs)
{
    const auto& l = *static_cast<const cv::Mat*>(lhs);
    const auto ret = l + rhs;
    return new cv::MatExpr(ret);
}

DLLEXPORT cv::MatExpr* op_3rdparty_cv_Mat_operator_multiply_int32_t(const cv::Mat* lhs, const int rhs)
{
    const auto& l = *static_cast<const cv::Mat*>(lhs);
    const auto ret = l * rhs;
    return new cv::MatExpr(ret);
}

DLLEXPORT cv::MatExpr* op_3rdparty_cv_Mat_operator_multiply_double(const cv::Mat* lhs, const double rhs)
{
    const auto& l = *static_cast<const cv::Mat*>(lhs);
    const auto ret = l * rhs;
    return new cv::MatExpr(ret);
}

#pragma endregion operators

#endif
