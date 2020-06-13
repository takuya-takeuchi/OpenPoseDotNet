#ifndef _CPP_OP_WRAPPER_WRAPPERAUXILIARY_H_
#define _CPP_OP_WRAPPER_WRAPPERAUXILIARY_H_

#include "../shared.h"
#include "../defines.h"

DLLEXPORT void op_createMultiviewTDatum(const data_type dataType,
                                        void* tDatumsSP,
                                        uint64_t* frameCounter,
                                        op::CameraParameterReader* cameraParameterReader,
                                        const void* const cvMatPtr)
{
    switch(dataType)
    {
        case data_type::Default:
            {
                auto& tmp = *(static_cast<DefaultDatums*>(tDatumsSP));
                uint64_t fc = *frameCounter;
                const auto& cpr = *cameraParameterReader;
                op::createMultiviewTDatum<op::Datum>(tmp,
                                                     fc,
                                                     cpr,
                                                     cvMatPtr);
                *frameCounter = fc;
            }
            break;
        case data_type::Custom:
            {
                // ToDo: not copmpilable
                // auto& tmp = *(static_cast<CustomDatums*>(tDatumsSP));
                // uint64_t fc = *frameCounter;
                // const auto& cpr = *cameraParameterReader;
                // op::createMultiviewTDatum<CustomDatum>(tmp,
                //                                        fc,
                //                                        cpr,
                //                                        cvMatPtr);
                // *frameCounter = fc;
            }
            break;
    }
}

#endif