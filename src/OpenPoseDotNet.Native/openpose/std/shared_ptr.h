#ifndef _CPP_STD_SHARED_PTR_H_
#define _CPP_STD_SHARED_PTR_H_

#include "../shared.h"
#include <memory>
#include "../defines.h"
#include "../user/userWorker.h"

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

MAKE_FUNC(op::PoseExtractorCaffe, op_PoseExtractorCaffe)
MAKE_FUNC(op::Producer, op_Producer)
MAKE_FUNC(DefaultDatumProducer, op_DatumProducerOfDatum)
MAKE_FUNC(DefaultWDatumProducer, op_WDatumProducerOfDatum)
MAKE_FUNC(op::Gui, op_Gui)
MAKE_FUNC(DefaultWGui, op_WGui)
MAKE_FUNC(DefaultUserWorker, op_UserWorkerOfDefault)
MAKE_FUNC(CustomUserWorker, op_UserWorkerOfCustom)

#endif