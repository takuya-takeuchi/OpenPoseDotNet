#ifndef _CPP_STD_SHARED_PTR_H_
#define _CPP_STD_SHARED_PTR_H_

#include "../shared.h"
#include <memory>

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

#endif