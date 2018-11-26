#ifndef _CPP_OP_WRAPPER_WRAPPERSTRUCTINPUT_H_
#define _CPP_OP_WRAPPER_WRAPPERSTRUCTINPUT_H_

#include "../shared.h"

DLLEXPORT op::WrapperStructInput* op_wrapperStructInput_new(const op::ProducerType producerType,
                                                            const char* producerString,
                                                            const unsigned long long frameFirst,
                                                            const unsigned long long frameStep,
                                                            const unsigned long long frameLast,
                                                            const bool realTimeProcessing,
                                                            const bool frameFlip,
                                                            const int frameRotate,
                                                            const bool framesRepeat,
                                                            const op::Point<int>* cameraResolution,
                                                            const char* cameraParameterPath,
                                                            const bool undistortImage,
                                                            const unsigned int imageDirectoryStereo)
{
    return new op::WrapperStructInput(producerType,
                                      std::string(producerString),
                                      frameFirst,
                                      frameStep,
                                      frameLast,
                                      realTimeProcessing,
                                      frameFlip,
                                      frameRotate,
                                      framesRepeat,
                                      *cameraResolution,
                                      std::string(cameraParameterPath),
                                      undistortImage,
                                      imageDirectoryStereo);
}

DLLEXPORT void op_wrapperStructInput_delete(op::WrapperStructInput* input)
{
    delete input;
}

#endif