#ifndef _CPP_OP_PRODUCER_W_DATUM_PRODUCER_H_
#define _CPP_OP_PRODUCER_W_DATUM_PRODUCER_H_

#include "../shared.h"
#include "../defines.h"

DLLEXPORT void* op_WDatumProducer_new(const data_type dataType,
                                      void* datumProducer)
{
    switch(dataType)
    {
        case data_type::Default:
            {
                auto& d = *static_cast<std::shared_ptr<DefaultDatumProducer>*>(datumProducer);
                return new DefaultWDatumProducer(d);
            }
        case data_type::Custom:
            {
                auto& d = *static_cast<std::shared_ptr<CustomDatumProducer>*>(datumProducer);
                return new CustomWDatumProducer(d);
            }
    }

    return nullptr;
}

DLLEXPORT void op_WDatumProducer_delete(const data_type dataType, void* producer)
{
    switch(dataType)
    {
        case data_type::Default:
            delete ((DefaultWDatumProducer*)producer);
            break;
        case data_type::Custom:
            delete ((CustomWDatumProducer*)producer);
            break;
    }
}

#endif