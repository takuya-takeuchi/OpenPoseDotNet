#ifndef _CPP_OP_3RDPARTY_OPENCV_CV_H_
#define _CPP_OP_3RDPARTY_OPENCV_CV_H_

#include "../../shared.h"

DLLEXPORT void op_3rdparty_cv_bitwise_not(cv::Mat* src, cv::Mat* dst)
{
    auto& s = *src;
    auto& d = *dst;
    cv::bitwise_not(s, d);
}

DLLEXPORT cv::Mat* op_3rdparty_cv_imread(const char* path, const int flags)
{
    std::string str(path);
    const auto& ret = cv::imread(str, flags);
    return new cv::Mat(ret);
}

DLLEXPORT void op_3rdparty_cv_imwrite(const char* path, const cv::Mat* mat)
{
    std::string str(path);
    const auto& m = *static_cast<const cv::Mat*>(mat);
    cv::imwrite(str, m);
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

DLLEXPORT void op_3rdparty_cv_merge(std::vector<cv::Mat*>* mv, cv::Mat* dst)
{
    auto& d = *static_cast<cv::Mat*>(dst);
    auto& input = std::vector<cv::Mat>();
    auto& src = *static_cast<std::vector<cv::Mat*>*>(mv);
    for (auto index = 0; index < src.size(); index++)
    {
        auto& m = *src[index];
        input.push_back(m);
    }

    cv::merge(input, d);
}

DLLEXPORT void op_3rdparty_addWeighted(const cv::Mat* src1,
                                       const double alpha,
                                       const cv::Mat* src2,
                                       const double beta,
                                       const double gamma,
                                       cv::Mat* dst)
{
    const auto& s1 = *static_cast<const cv::Mat*>(src1);
    const auto& s2 = *static_cast<const cv::Mat*>(src2);
    auto& d = *static_cast<cv::Mat*>(dst);
    cv::addWeighted(s1, alpha, s2, beta, gamma, d);
}

DLLEXPORT void op_3rdparty_applyColorMap(cv::Mat* src, cv::Mat* dst, const int colormap)
{
    auto& s = *static_cast<cv::Mat*>(src);
    auto& d = *static_cast<cv::Mat*>(dst);
    cv::applyColorMap(s, d, colormap);
}

#endif
