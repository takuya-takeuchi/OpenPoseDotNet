#ifndef _CPP_OP_GUI_GUI_H_
#define _CPP_OP_GUI_GUI_H_

#include "../shared.h"

DLLEXPORT op::Gui* op_Gui_new(const op::Point<int>* outputSize,
                              const bool fullScreen,
                              const std::shared_ptr<std::atomic<bool>>* isRunningSharedPtr,
                              const std::shared_ptr<std::pair<std::atomic<bool>, std::atomic<int>>>* videoSeekSharedPtr,
                              const std::vector<std::shared_ptr<op::PoseExtractorNet>>* poseExtractorNets,
                              const std::vector<std::shared_ptr<op::FaceExtractorNet>>* faceExtractorNets,
                              const std::vector<std::shared_ptr<op::HandExtractorNet>>* handExtractorNets,
                              const std::vector<std::shared_ptr<op::Renderer>>* renderers,
                              const op::DisplayMode displayMode)
{
    std::vector<std::shared_ptr<op::PoseExtractorNet>> def_poseExtractorNets;
    std::vector<std::shared_ptr<op::FaceExtractorNet>> def_faceExtractorNets;
    std::vector<std::shared_ptr<op::HandExtractorNet>> def_handExtractorNets;
    std::vector<std::shared_ptr<op::Renderer>> def_renderers;

    const auto& tmp_outputSize = *outputSize;
    const auto& tmp_isRunningSharedPtr = *isRunningSharedPtr;
    const auto& tmp_videoSeekSharedPtr = *videoSeekSharedPtr;
    const auto& tmp_poseExtractorNets = poseExtractorNets == nullptr ? def_poseExtractorNets : *poseExtractorNets;
    const auto& tmp_faceExtractorNets = faceExtractorNets == nullptr ? def_faceExtractorNets : *faceExtractorNets;
    const auto& tmp_handExtractorNets = handExtractorNets == nullptr ? def_handExtractorNets : *handExtractorNets;
    const auto& tmp_renderers= renderers == nullptr ? def_renderers : *renderers;

    return new op::Gui(tmp_outputSize,
                       fullScreen,
                       tmp_isRunningSharedPtr,
                       nullptr,
                       tmp_poseExtractorNets,
                       tmp_faceExtractorNets,
                       tmp_handExtractorNets,
                       tmp_renderers,
                       displayMode);
}

DLLEXPORT void op_Gui_delete(op::Gui* gui)
{
    delete gui;
}

#endif