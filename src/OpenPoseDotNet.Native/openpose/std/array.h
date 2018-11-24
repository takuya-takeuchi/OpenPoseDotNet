#ifndef _CPP_STD_ARRAY_H_
#define _CPP_STD_ARRAY_H_

#include "../shared.h"
#include <openpose/headers.hpp>

#pragma region template

#define MAKE_FUNC_CLASS_2(__TYPE__, __TYPENAME__)\
DLLEXPORT void* std_array_##__TYPENAME__##_new1(const int templateSize)\
{\
    if (templateSize == 2) return new std::array<__TYPE__, 2>;\
    else if (templateSize == 3) return new std::array<__TYPE__, 3>;\
    else if (templateSize == 4) return new std::array<__TYPE__, 4>;\
    else return nullptr;\
}\
\
DLLEXPORT size_t std_array_##__TYPENAME__##_getSize(void* array, const int templateSize)\
{\
    if (templateSize == 2) return (static_cast<std::array<__TYPE__, 2>*>(array))->size();\
    else if (templateSize == 3) return (static_cast<std::array<__TYPE__, 3>*>(array))->size();\
    else if (templateSize == 4) return (static_cast<std::array<__TYPE__, 4>*>(array))->size();\
    else return 0;\
}\
\
DLLEXPORT void* std_array_##__TYPENAME__##_getPointer(void* array, const int templateSize)\
{\
    if (templateSize == 2) return &((static_cast<std::array<__TYPE__, 2>*>(array))->at(0));\
    else if (templateSize == 3) return &((static_cast<std::array<__TYPE__, 3>*>(array))->at(0));\
    else if (templateSize == 4) return &((static_cast<std::array<__TYPE__, 4>*>(array))->at(0));\
    else return nullptr;\
}\
\
DLLEXPORT void std_array_##__TYPENAME__##_delete(void* array, const int templateSize)\
{\
    if (templateSize == 2) delete (static_cast<std::array<__TYPE__, 2>*>(array));\
    else if (templateSize == 3) delete (static_cast<std::array<__TYPE__, 3>*>(array));\
    else if (templateSize == 4) delete (static_cast<std::array<__TYPE__, 4>*>(array));\
}\
\
DLLEXPORT void std_array_##__TYPENAME__##_copy(void* array, __TYPE__** dst, const int templateSize)\
{\
    if (templateSize == 2)\
    {\
        const auto a = static_cast<std::array<__TYPE__, 2>*>(array); const auto s = a->size();\
        for (size_t i = 0; i < s; i++) dst[i] = &(a->at(i));\
    }\
    else if (templateSize == 3)\
    {\
        const auto a = static_cast<std::array<__TYPE__, 3>*>(array); const auto s = a->size();\
        for (size_t i = 0; i < s; i++) dst[i] = &(a->at(i));\
    }\
    else if (templateSize == 4)\
    {\
        const auto a = static_cast<std::array<__TYPE__, 4>*>(array); const auto s = a->size();\
        for (size_t i = 0; i < s; i++) dst[i] = &(a->at(i));\
    }\
}\
\
DLLEXPORT bool std_array_##__TYPENAME__##_empty(void* array, const int templateSize)\
{\
    if (templateSize == 2) return (static_cast<std::array<__TYPE__, 2>*>(array))->empty();\
    else if (templateSize == 3) return (static_cast<std::array<__TYPE__, 3>*>(array))->empty();\
    else if (templateSize == 4) return (static_cast<std::array<__TYPE__, 4>*>(array))->empty();\
    else return false;\
}\

#pragma endregion template

// class (pointer)
MAKE_FUNC_CLASS_2(op::Array<float>, op_Array_float)

#endif