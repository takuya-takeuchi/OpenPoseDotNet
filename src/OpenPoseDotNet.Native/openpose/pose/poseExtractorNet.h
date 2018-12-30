#ifndef _CPP_OP_POSE_POSE_EXTRACTOR_NET_H_
#define _CPP_OP_POSE_POSE_EXTRACTOR_NET_H_

#include "../shared.h"

DLLEXPORT void op_PoseExtractorNet_initializationOnThread(op::PoseExtractorNet* net)
{
    net->initializationOnThread();
}

DLLEXPORT op::Array<float>* op_PoseExtractorNet_getPoseKeypoints(const op::PoseExtractorNet* net)
{
    const auto ret = net->getPoseKeypoints();
    return new op::Array<float>(ret);
}

#endif