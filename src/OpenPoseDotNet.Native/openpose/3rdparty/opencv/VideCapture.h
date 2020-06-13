#ifndef _CPP_OP_3RDPARTY_OPENCV_VIDEOCAPTURE_H_
#define _CPP_OP_3RDPARTY_OPENCV_VIDEOCAPTURE_H_

#include "../../shared.h"

DLLEXPORT cv::VideoCapture* op_3rdparty_cv_VideoCapture_new(const char* path, const int32_t path_len)
{
    std::string str(path, path_len);
    return new cv::VideoCapture(str);
}

DLLEXPORT void op_3rdparty_cv_VideoCapture_delete(cv::VideoCapture* videoCapture)
{
    delete videoCapture;
}

DLLEXPORT bool op_3rdparty_cv_VideoCapture_isOpened(cv::VideoCapture* videoCapture)
{
    return videoCapture->isOpened();
}

DLLEXPORT bool op_3rdparty_cv_VideoCapture_grab(cv::VideoCapture* videoCapture)
{
    return videoCapture->grab();
}

DLLEXPORT bool op_3rdparty_cv_VideoCapture_retrieve(cv::VideoCapture* videoCapture,
                                                    cv::Mat* image,
                                                    const int32_t channel = 0)
{
    auto& mat = *image;
    return videoCapture->retrieve(mat, channel);
}

#pragma endregion operators

#endif
