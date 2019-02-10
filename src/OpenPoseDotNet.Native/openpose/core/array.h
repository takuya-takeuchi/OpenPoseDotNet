#ifndef _CPP_OP_CORE_ARRAY_H_
#define _CPP_OP_CORE_ARRAY_H_

#include "../shared.h"

#pragma region template

#define MAKE_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT void op_core_Array_##__TYPENAME__##_delete(op::Array<__TYPE__>* array)\
{\
    delete array;\
}\
\
DLLEXPORT std::string* op_core_Array_##__TYPENAME__##_toString(op::Array<__TYPE__>* array)\
{\
    auto ret = array->toString();\
    return new std::string(ret);\
}\
\
DLLEXPORT std::vector<__TYPE__>* op_core_Array_##__TYPENAME__##_gets(op::Array<__TYPE__>* array, const int index)\
{\
    const auto size = (int)array->getNumberDimensions();\
    auto vector = new std::vector<__TYPE__>();\
    vector->reserve(size);\
    for (auto i = index * size, end = index * size + size; i < end; i++) vector->push_back(array->at(i));\
\
    return vector;\
}\
\
DLLEXPORT int op_core_Array_##__TYPENAME__##_getSize(op::Array<__TYPE__>* array, const int index)\
{\
    return array->getSize(index);\
}\
\
DLLEXPORT std::vector<int>* op_core_Array_##__TYPENAME__##_getSize2(op::Array<__TYPE__>* array)\
{\
    const auto ret = array->getSize();\
    return new std::vector<int>(ret);\
}\
\
DLLEXPORT size_t op_core_Array_##__TYPENAME__##_getNumberDimensions(op::Array<__TYPE__>* array)\
{\
    return array->getNumberDimensions();\
}\
\
DLLEXPORT size_t op_core_Array_##__TYPENAME__##_getVolume(op::Array<__TYPE__>* array)\
{\
    return array->getVolume();\
}\
\
DLLEXPORT bool op_core_Array_##__TYPENAME__##_empty(op::Array<__TYPE__>* array)\
{\
    return array->empty();\
}\
\
DLLEXPORT __TYPE__* op_core_Array_##__TYPENAME__##_getPtr(op::Array<__TYPE__>* array)\
{\
    return array->getPtr();\
}\
\
DLLEXPORT __TYPE__ op_core_Array_##__TYPENAME__##_operator_indexes(op::Array<__TYPE__>* array, std::vector<int>* indexes)\
{\
    auto& tmp = *array;\
    auto& tmp_indexes = *indexes;\
    return tmp[tmp_indexes];\
}\

#pragma endregion template

MAKE_FUNC(float, float)
MAKE_FUNC(double, double)

#endif