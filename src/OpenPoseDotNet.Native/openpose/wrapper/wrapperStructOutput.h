#ifndef _CPP_OP_WRAPPER_WRAPPERSTRUCTOUTPUT_H_
#define _CPP_OP_WRAPPER_WRAPPERSTRUCTOUTPUT_H_

#include "../shared.h"

DLLEXPORT op::WrapperStructOutput* op_wrapperStructOutput_new(const double verbose,
                                                              const char* writeKeypoint,
                                                              const op::DataFormat writeKeypointFormat,
                                                              const char* writeJson,
                                                              const char* writeCocoJson,
                                                              const char* writeCocoFootJson,
                                                              const int writeCocoJsonVariant,
                                                              const char* writeImages,
                                                              const char* writeImagesFormat,
                                                              const char* writeVideo,
                                                              const bool writeVideoWithAudio,
                                                              const double writeVideoFps,
                                                              const char* writeHeatMaps,
                                                              const char* writeHeatMapsFormat,
                                                              const char* writeVideoAdam,
                                                              const char* writeBvh,
                                                              const char* udpHost,
                                                              const char* udpPort)
{
    return new op::WrapperStructOutput(verbose,
                                       std::string(writeKeypoint),
                                       writeKeypointFormat,
                                       std::string(writeJson),
                                       std::string(writeCocoJson),
                                       std::string(writeCocoFootJson),
                                       writeCocoJsonVariant,
                                       std::string(writeImages),
                                       std::string(writeImagesFormat),
                                       std::string(writeVideo),
                                       writeVideoWithAudio,
                                       writeVideoFps,
                                       std::string(writeHeatMaps),
                                       std::string(writeHeatMapsFormat),
                                       std::string(writeVideoAdam),
                                       std::string(writeBvh),
                                       std::string(udpHost),
                                       std::string(udpPort));
}

DLLEXPORT void op_wrapperStructOutput_delete(op::WrapperStructOutput* output)
{
    delete output;
}

#endif