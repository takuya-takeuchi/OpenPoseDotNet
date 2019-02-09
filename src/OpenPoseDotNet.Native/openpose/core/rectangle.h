#ifndef _CPP_OP_CORE_RECTANGLE_H_
#define _CPP_OP_CORE_RECTANGLE_H_

#include "../shared.h"

#pragma region template

#define MAKE_FUNC(__NAME__, __TYPE__)\
DLLEXPORT op::Rectangle<__TYPE__>* op_core_rectangle_##__NAME__##_new(__TYPE__ x, __TYPE__ y, __TYPE__ width, __TYPE__ height)\
{\
    return new op::Rectangle<__TYPE__>(x, y, width, height);\
}\
\
DLLEXPORT void op_core_rectangle_##__NAME__##_delete(op::Rectangle<__TYPE__>* rectangle)\
{\
    delete rectangle;\
}\

#pragma endregion template

MAKE_FUNC(float, float)

#endif