#ifndef _CPP_OP_PRODUCER_PRODUCER_H_
#define _CPP_OP_PRODUCER_PRODUCER_H_

#include "../shared.h"

DLLEXPORT double op_Producer_get(op::Producer* producer, const int capProperty)
{
    return producer->get(capProperty);
}

DLLEXPORT bool op_Producer_isOpened(op::Producer* producer)
{
    return producer->isOpened();
}

DLLEXPORT void op_Producer_release(op::Producer* producer)
{
    return producer->release();
}

DLLEXPORT void op_Producer_setProducerFpsMode(op::Producer* producer, const op::ProducerFpsMode fpsMode)
{
    producer->setProducerFpsMode(fpsMode);
}

DLLEXPORT std::shared_ptr<op::Producer>* op_createProducer(const op::ProducerType type, 
                                                           const char* producerString,
                                                           const op::Point<int>* cameraResolution,
                                                           const char* cameraParameterPath,
                                                           const bool undistortImage,
                                                           const int mNumberViews)
{
    const auto ret = op::createProducer(type,
                                        std::string(producerString),
                                        *cameraResolution,
                                        std::string(cameraParameterPath),
                                        undistortImage,
                                        mNumberViews);
    return new std::shared_ptr<op::Producer>(ret);
}

#endif