#ifndef _CPP_STD_SHARED_PTR_H_
#define _CPP_STD_SHARED_PTR_H_

#include "../shared.h"
#include <memory>
#include "../defines.h"
#include "../user/userWorker.h"
#include "../user/userWorkerConsumer.h"
#include "../user/userWorkerProducer.h"

#pragma region template

#define MAKE_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT std::shared_ptr<__TYPE__>* std_shared_ptr_##__TYPENAME__##_new(__TYPE__* ptr)\
{\
    return new std::shared_ptr<__TYPE__>(ptr);\
}\
\
DLLEXPORT void std_shared_ptr_##__TYPENAME__##_delete(std::shared_ptr<__TYPE__>* p)\
{\
    delete p;\
}\
\
DLLEXPORT __TYPE__* std_shared_ptr_##__TYPENAME__##_get(std::shared_ptr<__TYPE__>* p)\
{\
    return p->get();\
}\

#pragma endregion template

MAKE_FUNC(std::vector<op::Datum>, StdVectorOfDatum)
MAKE_FUNC(std::vector<CustomDatum>, StdVectorOfCustomDatum)
MAKE_FUNC(op::PoseExtractorCaffe, op_PoseExtractorCaffe)
MAKE_FUNC(op::Producer, op_Producer)
MAKE_FUNC(DefaultDatumProducer, op_DatumProducerOfDatum)
MAKE_FUNC(DefaultWDatumProducer, op_WDatumProducerOfDatum)
MAKE_FUNC(op::Gui, op_Gui)
MAKE_FUNC(DefaultWGui, op_WGui)
MAKE_FUNC(DefaultUserWorker, op_UserWorkerOfDefault)
MAKE_FUNC(CustomUserWorker, op_UserWorkerOfCustom)
MAKE_FUNC(DefaultUserWorkerConsumer, op_UserWorkerConsumerOfDefault)
MAKE_FUNC(CustomUserWorkerConsumer, op_UserWorkerConsumerOfCustom)
MAKE_FUNC(DefaultUserWorkerProducer, op_UserWorkerProducerOfDefault)
MAKE_FUNC(CustomUserWorkerProducer, op_UserWorkerProducerOfCustom)

DLLEXPORT void* std_shared_ptr_TDatum_get(const data_type dataType, void* p)
{
    void* ret = nullptr;

    switch(dataType)
    {
        case data_type::Default:
            ret = ((DefaultDatums*)p)->get();
            break;
        case data_type::Custom:
            ret = ((CustomDatums*)p)->get();
            break;
    }

    return ret;
}

#endif