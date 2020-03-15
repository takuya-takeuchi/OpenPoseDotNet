#ifndef _CPP_OP_3RDPARTY_OPENCV_MATEXPR_H_
#define _CPP_OP_3RDPARTY_OPENCV_MATEXPR_H_

#include "../../shared.h"

DLLEXPORT void op_3rdparty_cv_MatExpr_delete(cv::MatExpr* expr)
{
    delete expr;
}

DLLEXPORT cv::Mat* op_3rdparty_cv_MatExpr_toMat(cv::MatExpr *self)
{
    auto& ret = *static_cast<cv::MatExpr*>(self);
    return new cv::Mat(ret);
}

#pragma region operators

DLLEXPORT cv::MatExpr* op_3rdparty_cv_MatExpr_operator_add(const cv::MatExpr* lhs, const double rhs)
{
    const auto& l = *static_cast<const cv::MatExpr*>(lhs);
    const auto ret = l + rhs;
    return new cv::MatExpr(ret);
}

DLLEXPORT cv::MatExpr* op_3rdparty_cv_MatExpr_operator_multiply_int32_t(const cv::MatExpr* lhs, const int rhs)
{
    const auto& l = *static_cast<const cv::MatExpr*>(lhs);
    const auto ret = l * rhs;
    return new cv::MatExpr(ret);
}

DLLEXPORT cv::MatExpr* op_3rdparty_cv_MatExpr_operator_multiply_double(const cv::MatExpr* lhs, const double rhs)
{
    const auto& l = *static_cast<const cv::MatExpr*>(lhs);
    const auto ret = l * rhs;
    return new cv::MatExpr(ret);
}

#pragma endregion operators

#endif
