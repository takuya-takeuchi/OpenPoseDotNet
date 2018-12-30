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

#endif