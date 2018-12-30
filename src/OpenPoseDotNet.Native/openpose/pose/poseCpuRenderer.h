#ifndef _CPP_OP_POSE_POSE_CPU_RENDERER_H_
#define _CPP_OP_POSE_POSE_CPU_RENDERER_H_

#include "../shared.h"

DLLEXPORT op::PoseCpuRenderer* op_PoseCpuRenderer_new(const op::PoseModel poseModel,
                                                      const float renderThreshold,
                                                      const bool blendOriginalFrame,
                                                      const float alphaKeypoint,
                                                      const float alphaHeatMap,
                                                      const unsigned int elementToRender)
{
    return new op::PoseCpuRenderer(poseModel,
                                   renderThreshold,
                                   blendOriginalFrame,
                                   alphaKeypoint,
                                   alphaHeatMap,
                                   elementToRender);
}

DLLEXPORT void op_PoseCpuRenderer_delete(op::PoseCpuRenderer* renderer)
{
    delete renderer;
}

DLLEXPORT void op_PoseCpuRenderer_initializationOnThread(op::PoseCpuRenderer* renderer)
{
    renderer->initializationOnThread();
}

DLLEXPORT void op_PoseCpuRenderer_renderPose(op::PoseCpuRenderer* renderer,
                                             op::Array<float>* outputData,
                                             const op::Array<float>* poseKeypoints,
                                             const float scaleInputToOutput,
                                             const float scaleNetToOutput,
                                             int* item1,
                                             std::string** item2)
{
    auto& tmp_outputData = *outputData;
    const auto& tmp_poseKeypoints = *poseKeypoints;
    const auto ret = renderer->renderPose(tmp_outputData, tmp_poseKeypoints, scaleInputToOutput, scaleNetToOutput);
    *item1 = ret.first;
    *item2 = new std::string(ret.second);
}

#endif