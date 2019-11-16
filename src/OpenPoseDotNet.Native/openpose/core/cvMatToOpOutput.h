#ifndef _CPP_OP_CORE_CV_MAT_TO_OP_OUTPUT_HPP
#define _CPP_OP_CORE_CV_MAT_TO_OP_OUTPUT_HPP

#include "../shared.h"

DLLEXPORT op::CvMatToOpOutput* op_core_CvMatToOpOutput_new()
{
    return new op::CvMatToOpOutput();
}

DLLEXPORT void op_core_CvMatToOpOutput_delete(op::CvMatToOpOutput* output)
{
    delete output;
}

DLLEXPORT op::Array<float>* op_core_CvMatToOpOutput_createArray(op::CvMatToOpOutput* output,
                                                                const op::Matrix* cvInputData,
                                                                const double scaleInputToOutput,
                                                                const op::Point<int>* outputResolution)
{
    const auto& inputData = *cvInputData;
    const auto& resolution = *outputResolution;
    const auto ret = output->createArray(inputData, scaleInputToOutput, resolution);
    return new op::Array<float>(ret);
}

#endif