#ifndef _CPP_OP_CORE_POINT_H_
#define _CPP_OP_CORE_POINT_H_

#include "../shared.h"

#pragma region template

#define MAKE_FUNC(__NAME__, __TYPE__)\
DLLEXPORT op::Point<__TYPE__>* op_core_point_##__NAME__##_new(__TYPE__ x, __TYPE__ y)\
{\
    return new op::Point<__TYPE__>(x, y);\
}\
\
DLLEXPORT void op_core_point_##__NAME__##_delete(op::Point<__TYPE__>* point)\
{\
    delete point;\
}\

#pragma endregion template

MAKE_FUNC(int, int)
MAKE_FUNC(float, float)
MAKE_FUNC(double, double)

#endif