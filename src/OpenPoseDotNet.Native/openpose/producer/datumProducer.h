#ifndef _CPP_OP_PRODUCER_DATUM_PRODUCER_H_
#define _CPP_OP_PRODUCER_DATUM_PRODUCER_H_

#include "../shared.h"
#include "../defines.h"

DLLEXPORT void* op_DatumProducer_new(const data_type dataType,
                                     const std::shared_ptr<op::Producer>* producerSharedPtr,
                                     const unsigned long long frameFirst,
                                     const unsigned long long frameStep,
                                     const unsigned long long frameLast,
                                     const std::shared_ptr<std::pair<std::atomic<bool>,
                                                           std::atomic<int>>>* videoSeekSharedPtr)
{
    // ToDo: handle videoSeekSharedPtr appropriately
    const auto& tmp_producerSharedPtr = *producerSharedPtr;
	const std::shared_ptr<std::pair<std::atomic<bool>, std::atomic<int>>> tmp_videoSeekSharedPtr(nullptr);

    switch(dataType)
    {
        case data_type::Default:
            return new DefaultDatumProducer(tmp_producerSharedPtr, frameFirst, frameStep, frameLast, tmp_videoSeekSharedPtr);
        case data_type::Custom:
            return new CustomDatumProducer(tmp_producerSharedPtr, frameFirst, frameStep, frameLast, tmp_videoSeekSharedPtr);
    }

    return nullptr;
}

DLLEXPORT void op_DatumProducer_delete(const data_type dataType, void* producer)
{
    switch(dataType)
    {
        case data_type::Default:
            delete ((DefaultDatumProducer*)producer);
            break;
        case data_type::Custom:
            delete ((CustomDatumProducer*)producer);
            break;
    }
}

#endif