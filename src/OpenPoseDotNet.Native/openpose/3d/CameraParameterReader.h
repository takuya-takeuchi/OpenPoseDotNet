#ifndef _CPP_OP_3D_CAMERAPARAMETERREADER_H_
#define _CPP_OP_3D_CAMERAPARAMETERREADER_H_

#include "../shared.h"

DLLEXPORT op::CameraParameterReader* op_CameraParameterReader_new()
{
    return new op::CameraParameterReader();
}

DLLEXPORT void op_CameraParameterReader_delete(op::CameraParameterReader* parameter)
{
    delete parameter;
}

DLLEXPORT unsigned long long op_CameraParameterReader_getNumberCameras(op::CameraParameterReader* parameter)
{
    return parameter->getNumberCameras();
}

DLLEXPORT bool op_CameraParameterReader_getUndistortImage(op::CameraParameterReader* parameter)
{
    return parameter->getUndistortImage();
}

DLLEXPORT void op_CameraParameterReader_setUndistortImage(op::CameraParameterReader* parameter, const bool undistortImage)
{
    parameter->setUndistortImage(undistortImage);
}

DLLEXPORT void op_CameraParameterReader_readParameters(op::CameraParameterReader* parameter,
                                                       const char* cameraParameterPath,
                                                       const int32_t cameraParameterPath_len,
                                                       std::vector<std::string*>* serialNumbers)
{
    std::string str(cameraParameterPath, cameraParameterPath_len);

    std::vector<std::string> vec;
    if (serialNumbers != nullptr)
    {
        auto& tmp = *serialNumbers;
        const size_t size = serialNumbers->size();
        vec.resize(size);
        for (size_t i = 0; i < size; i++)
            vec[i] = *tmp[i];
    }

    parameter->readParameters(str, vec);
}

#endif