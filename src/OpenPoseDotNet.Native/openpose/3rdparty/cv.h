#ifndef _CPP_OP_3RDPARTY_CV_H_
#define _CPP_OP_3RDPARTY_CV_H_

#include "./../shared.h"

#pragma region cv

DLLEXPORT void op_3rdparty_cv_bitwise_not(cv::Mat* src, cv::Mat* dst)
{
    auto& s = *src;
    auto& d = *dst;
    cv::bitwise_not(s, d);
}

DLLEXPORT cv::Mat* op_3rdparty_cv_imread(const char* path, const int flags)
{
    std::string str(path);
    auto& ret = cv::imread(str, flags);
    return new cv::Mat(ret);
}

DLLEXPORT void op_3rdparty_cv_imshow(const char* winname, cv::Mat* mat)
{
    std::string str(winname);
    const auto& m = *mat;
    cv::imshow(str, m);
}

DLLEXPORT int op_3rdparty_cv_waitKey(const int delay)
{
    return cv::waitKey(delay);
}

#pragma endregion cv

#pragma region cv::Mat

DLLEXPORT void op_3rdparty_cv_mat_delete(cv::Mat* mat)
{
    delete mat;
}

DLLEXPORT int op_3rdparty_cv_mat_rows(cv::Mat* mat)
{
    return mat->rows;
}

DLLEXPORT int op_3rdparty_cv_mat_cols(cv::Mat* mat)
{
    return mat->cols;
}

DLLEXPORT int op_3rdparty_cv_mat_channels(cv::Mat* mat)
{
    return mat->channels();
}

#pragma endregion cv::Mat

#endif