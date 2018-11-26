#ifndef _CPP_OP_UTILITIES_FLAGSTOOPENPOSE_H_
#define _CPP_OP_UTILITIES_FLAGSTOOPENPOSE_H_

#include "../shared.h"

DLLEXPORT op::Point<int>* op_flagsToPoint(const char* pointString, const char* pointExample)
{
    const std::string str_pointString(pointString);
    const std::string str_pointExample(pointExample);
    const auto ret = op::flagsToPoint(str_pointString, str_pointExample);
    return new op::Point<int>(ret);
}

DLLEXPORT void op_flagsToPoint_xy(const char* pointString, const char* pointExample, int* x, int* y)
{
    const std::string str_pointString(pointString);
    const std::string str_pointExample(pointExample);
    const auto ret = op::flagsToPoint(str_pointString, str_pointExample);
    *x = ret.x;
    *y = ret.y;
}

DLLEXPORT op::RenderMode op_flagsToRenderMode(const int renderFlag, const bool gpuBuggy, const int renderPoseFlag)
{
    return op::flagsToRenderMode(renderFlag, gpuBuggy, renderPoseFlag);
}

DLLEXPORT op::PoseModel op_flagsToPoseModel(const char* poseModeString)
{
    const std::string str(poseModeString);
    return op::flagsToPoseModel(str);
}

DLLEXPORT op::ScaleMode op_flagsToScaleMode(const int keypointScale)
{
    return op::flagsToScaleMode(keypointScale);
}

DLLEXPORT std::vector<op::HeatMapType>* op_flagsToHeatMaps(const bool heatMapsAddParts,
                                                           const bool heatMapsAddBkg,
                                                           const bool heatMapsAddPAFs)
{
    const auto ret = op::flagsToHeatMaps(heatMapsAddParts, heatMapsAddBkg, heatMapsAddPAFs);
    return new std::vector<op::HeatMapType>(ret);
}

DLLEXPORT op::ScaleMode op_flagsToHeatMapScaleMode(const int heatMapScale)
{
    return op::flagsToHeatMapScaleMode(heatMapScale);
}

DLLEXPORT void op_flagsToProducer(const char* imageDirectory,
                                  const char* videoPath,
                                  const char* ipCameraPath,
                                  const int webcamIndex,
                                  const bool flirCamera,
                                  const int flirCameraIndex,
                                  op::ProducerType* item1,
                                  std::string** item2)
{
    const std::string str_imageDirectory(imageDirectory);
    const std::string str_videoPath(videoPath);
    const std::string str_ipCameraPath(ipCameraPath);

    const auto ret = op::flagsToProducer(str_imageDirectory,
                                         str_videoPath,
                                         str_ipCameraPath,
                                         webcamIndex,
                                         flirCamera,
                                         flirCameraIndex);
    *item1 = ret.first;
    *item2 = new std::string(ret.second);
}

DLLEXPORT op::DisplayMode op_flagsToDisplayMode(const int display, const bool enabled3d)
{
    return op::flagsToDisplayMode(display, enabled3d);
}

#endif