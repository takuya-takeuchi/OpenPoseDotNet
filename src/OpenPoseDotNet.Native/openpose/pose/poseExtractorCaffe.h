#ifndef _CPP_OP_POSE_POSE_EXTRACTOR_CAFFE_H_
#define _CPP_OP_POSE_POSE_EXTRACTOR_CAFFE_H_

#include "../shared.h"

DLLEXPORT op::PoseExtractorCaffe* op_PoseExtractorCaffe_new(const op::PoseModel poseModel,
                                                            const char* modelFolder,
                                                            const int gpuId,
                                                            const std::vector<op::HeatMapType>* heatMapTypes,
                                                            const op::ScaleMode heatMapScale,
                                                            const bool addPartCandidates,
                                                            const bool maximizePositives,
                                                            const char* protoTxtPath,
                                                            const char* caffeModelPath,
                                                            const bool enableGoogleLogging)
{
    return new op::PoseExtractorCaffe(poseModel,
                                      std::string(modelFolder),
                                      gpuId,
                                      *heatMapTypes,
                                      heatMapScale,
                                      addPartCandidates,
                                      maximizePositives,
                                      std::string(protoTxtPath),
                                      std::string(caffeModelPath),
                                      enableGoogleLogging);
}

DLLEXPORT void op_PoseExtractorCaffe_delete(op::PoseExtractorCaffe* caffe)
{
    delete caffe;
}

DLLEXPORT void op_PoseExtractorCaffe_forwardPass(op::PoseExtractorCaffe* caffe,
                                                 const std::vector<op::Array<float>>* inputNetData,
                                                 const op::Point<int>* inputDataSize,
                                                 const std::vector<double>* scaleRatios)
{
    caffe->forwardPass(*inputNetData, *inputDataSize, *scaleRatios);
}

#endif