#ifndef _CPP_OP_CORE_CV_MAT_TO_OP_INPUT_HPP
#define _CPP_OP_CORE_CV_MAT_TO_OP_INPUT_HPP

#include "../shared.h"

DLLEXPORT op::CvMatToOpInput* op_core_CvMatToOpInput_new(const op::PoseModel poseModel)
{
    return new op::CvMatToOpInput(poseModel);
}

DLLEXPORT void op_core_CvMatToOpInput_delete(op::CvMatToOpInput* input)
{
    delete input;
}

DLLEXPORT std::vector<op::Array<float>>* op_core_CvMatToOpInput_createArray(op::CvMatToOpInput* input,
                                                                            const cv::Mat* cvInputData,
                                                                            const std::vector<double>* scaleInputToNetInputs,
                                                                            const std::vector<op::Point<int>>* netInputSizes)
{
    const auto& inputData = *cvInputData;
    const auto& scale = *scaleInputToNetInputs;
    const auto& sizes = *netInputSizes;
    const auto ret = input->createArray(inputData, scale, sizes);
    const auto vector = new std::vector<op::Array<float>>(ret);
    return vector;
}

#endif