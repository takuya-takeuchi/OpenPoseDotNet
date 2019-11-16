#ifndef _CPP_OP_WRAPPER_WRAPPERSTRUCTOUTPUT_H_
#define _CPP_OP_WRAPPER_WRAPPERSTRUCTOUTPUT_H_

#include "../shared.h"

DLLEXPORT op::WrapperStructOutput* op_wrapperStructOutput_new(const double verbose,
                                                              const char* writeKeypoint,
                                                              const op::DataFormat writeKeypointFormat,
                                                              const char* writeJson,
                                                              const char* writeCocoJson,
                                                              const int writeCocoJsonVariants,
                                                              const int writeCocoJsonVariant,
                                                              const char* writeImages,
                                                              const char* writeImagesFormat,
                                                              const char* writeVideo,
                                                              const double writeVideoFps,
                                                              const bool writeVideoWithAudio,
                                                              const char* writeHeatMaps,
                                                              const char* writeHeatMapsFormat,
                                                              const char* writeVideoAdam,
                                                              const char* writeBvh,
                                                              const char* udpHost,
                                                              const char* udpPort)
{
    return new op::WrapperStructOutput(verbose,
                                       op::String(writeKeypoint),
                                       writeKeypointFormat,
                                       op::String(writeJson),
                                       op::String(writeCocoJson),
                                       writeCocoJsonVariants,
                                       writeCocoJsonVariant,
                                       op::String(writeImages),
                                       op::String(writeImagesFormat),
                                       op::String(writeVideo),
                                       writeVideoFps,
                                       writeVideoWithAudio,
                                       op::String(writeHeatMaps),
                                       op::String(writeHeatMapsFormat),
                                       op::String(writeVideoAdam),
                                       op::String(writeBvh),
                                       op::String(udpHost),
                                       op::String(udpPort));
}

DLLEXPORT void op_wrapperStructOutput_delete(op::WrapperStructOutput* output)
{
    delete output;
}

#endif