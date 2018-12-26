#ifndef _CPP_OP_POSE_POSEPARAMETERS_H_
#define _CPP_OP_POSE_POSEPARAMETERS_H_

#include "../shared.h"

DLLEXPORT std::string* op_getPoseProtoTxt(const op::PoseModel poseModel)
{
    const auto tmp = op::getPoseProtoTxt(poseModel);
    return new std::string(tmp);
}

DLLEXPORT std::string* op_getPoseTrainedModel(const op::PoseModel poseModel)
{
    const auto tmp = op::getPoseTrainedModel(poseModel);
    return new std::string(tmp);
}

DLLEXPORT unsigned int op_getPoseNumberBodyParts(const op::PoseModel poseModel)
{
    return op::getPoseNumberBodyParts(poseModel);
}

DLLEXPORT std::vector<unsigned int>* op_getPosePartPairs(const op::PoseModel poseModel)
{
    const auto tmp = op::getPosePartPairs(poseModel);
    return new std::vector<unsigned int>(tmp);
}

DLLEXPORT std::vector<unsigned int>* op_getPoseMapIndex(const op::PoseModel poseModel)
{
    const auto tmp = op::getPoseMapIndex(poseModel);
    return new std::vector<unsigned int>(tmp);
}

DLLEXPORT unsigned int op_getPoseMaxPeaks()
{
    return op::getPoseMaxPeaks();
}

DLLEXPORT float op_getPoseNetDecreaseFactor(const op::PoseModel poseModel)
{
    return op::getPoseNetDecreaseFactor(poseModel);
}

DLLEXPORT float op_getPoseDefaultConnectInterMinAboveThreshold(const bool maximizePositives)
{
    return op::getPoseDefaultConnectInterMinAboveThreshold(maximizePositives);
}

DLLEXPORT float op_getPoseDefaultConnectInterThreshold(const op::PoseModel poseModel, const bool maximizePositives)
{
    return op::getPoseDefaultConnectInterThreshold(poseModel);
}

DLLEXPORT unsigned int op_getPoseDefaultMinSubsetCnt(const bool maximizePositives)
{
    return op::getPoseDefaultMinSubsetCnt(maximizePositives);
}

DLLEXPORT float op_getPoseDefaultConnectMinSubsetScore(const bool maximizePositives)
{
    return op::getPoseDefaultConnectMinSubsetScore(maximizePositives);
}

DLLEXPORT bool op_addBkgChannel(const op::PoseModel poseModel)
{
    return op::addBkgChannel(poseModel);
}

#endif