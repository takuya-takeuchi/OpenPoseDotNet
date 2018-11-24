#ifndef _CPP_SHARED_H_
#define _CPP_SHARED_H_

#include <openpose/headers.hpp>

#include "export.h"

enum struct array_element_type : int
{
    Float = 0,
};

#define ERR_OK                                                            0x00000000

#pragma region template

#define MAKE_SHARED_PTR_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT void op_shared_ptr_##__TYPENAME__##_delete(std::shared_ptr<__TYPE__>* ptr)\
{\
    delete ptr;\
}\
\
DLLEXPORT __TYPE__* op_shared_ptr_##__TYPENAME__##_getter(std::shared_ptr<__TYPE__>* ptr)\
{\
    return ptr->get();\
}\

#pragma endregion template

#endif