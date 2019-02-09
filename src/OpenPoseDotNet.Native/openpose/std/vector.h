#ifndef _CPP_STD_VECTOR_H_
#define _CPP_STD_VECTOR_H_

#include "../shared.h"
#include <openpose/headers.hpp>
#include "../custom/customDatum.h"

#pragma region template

#define MAKE_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT std::vector<__TYPE__>* std_vector_##__TYPENAME__##_new1()\
{\
    return new std::vector<__TYPE__>;\
}\
\
DLLEXPORT std::vector<__TYPE__>* std_vector_##__TYPENAME__##_new2(size_t size)\
{\
    return new std::vector<__TYPE__>(size);\
}\
\
DLLEXPORT std::vector<__TYPE__>* std_vector_##__TYPENAME__##_new3(__TYPE__* data, size_t dataLength)\
{\
    return new std::vector<__TYPE__>(data, data + dataLength);\
}\
\
DLLEXPORT size_t std_vector_##__TYPENAME__##_getSize(std::vector<__TYPE__>* vector)\
{\
    return vector->size();\
}\
\
DLLEXPORT __TYPE__* std_vector_##__TYPENAME__##_getPointer(std::vector<__TYPE__> *vector)\
{\
    return &(vector->at(0));\
}\
\
DLLEXPORT void std_vector_##__TYPENAME__##_delete(std::vector<__TYPE__> *vector)\
{\
    delete vector;\
}\
\
DLLEXPORT void std_vector_##__TYPENAME__##_copy(std::vector<__TYPE__> *vector, __TYPE__* dst)\
{\
    size_t length = sizeof(__TYPE__) * vector->size();\
    memcpy(dst, &(vector->at(0)), length);\
}\
\
DLLEXPORT bool std_vector_##__TYPENAME__##_empty(std::vector<__TYPE__> *vector)\
{\
    return vector->empty();\
}\
\
DLLEXPORT void std_vector_##__TYPENAME__##_emplace_back(std::vector<__TYPE__> *vector)\
{\
    return vector->emplace_back();\
}\
\
DLLEXPORT __TYPE__* std_vector_##__TYPENAME__##_at(std::vector<__TYPE__> *vector, int index)\
{\
    return &(vector->at(index));\
}\

#define MAKE_FUNC_CLASS(__TYPE__, __TYPENAME__)\
DLLEXPORT std::vector<__TYPE__>* std_vector_##__TYPENAME__##_new1()\
{\
    return new std::vector<__TYPE__>;\
}\
\
DLLEXPORT std::vector<__TYPE__>* std_vector_##__TYPENAME__##_new2(size_t size)\
{\
    return new std::vector<__TYPE__>(size);\
}\
\
DLLEXPORT std::vector<__TYPE__>* std_vector_##__TYPENAME__##_new3(__TYPE__* data, size_t dataLength)\
{\
    return new std::vector<__TYPE__>(data, data + dataLength);\
}\
\
DLLEXPORT size_t std_vector_##__TYPENAME__##_getSize(std::vector<__TYPE__>* vector)\
{\
    return vector->size();\
}\
\
DLLEXPORT __TYPE__* std_vector_##__TYPENAME__##_getPointer(std::vector<__TYPE__> *vector)\
{\
    return &(vector->at(0));\
}\
\
DLLEXPORT void std_vector_##__TYPENAME__##_delete(std::vector<__TYPE__> *vector)\
{\
    delete vector;\
}\
\
DLLEXPORT void std_vector_##__TYPENAME__##_copy(std::vector<__TYPE__> *vector, __TYPE__** dst)\
{\
    const auto size = vector->size();\
    for (size_t i = 0; i < size; i++) dst[i] = &(vector->at(i));\
}\
\
DLLEXPORT bool std_vector_##__TYPENAME__##_empty(std::vector<__TYPE__> *vector)\
{\
    return vector->empty();\
}\
\
DLLEXPORT void std_vector_##__TYPENAME__##_emplace_back(std::vector<__TYPE__> *vector)\
{\
    return vector->emplace_back();\
}\
\
DLLEXPORT __TYPE__* std_vector_##__TYPENAME__##_at(std::vector<__TYPE__> *vector, int index)\
{\
    return &(vector->at(index));\
}\

#define MAKE_FUNC_REF(__TYPE__, __TYPENAME__)\
DLLEXPORT std::vector<__TYPE__>* std_vector_##__TYPENAME__##_new1()\
{\
    return new std::vector<__TYPE__>;\
}\
\
DLLEXPORT std::vector<__TYPE__>* std_vector_##__TYPENAME__##_new2(size_t size)\
{\
    return new std::vector<__TYPE__>(size);\
}\
\
DLLEXPORT std::vector<__TYPE__>* std_vector_##__TYPENAME__##_new3(__TYPE__** data, size_t dataLength)\
{\
    const auto ret = new std::vector<__TYPE__>();\
    ret->reserve(dataLength);\
    for (auto index = 0; index < dataLength; index++) ret->push_back(*data[index]);\
    return ret;\
}\
\
DLLEXPORT size_t std_vector_##__TYPENAME__##_getSize(std::vector<__TYPE__>* vector)\
{\
    return vector->size();\
}\
\
DLLEXPORT __TYPE__* std_vector_##__TYPENAME__##_getPointer(std::vector<__TYPE__> *vector)\
{\
    return &(vector->at(0));\
}\
\
DLLEXPORT void std_vector_##__TYPENAME__##_delete(std::vector<__TYPE__> *vector)\
{\
    delete vector;\
}\
\
DLLEXPORT void std_vector_##__TYPENAME__##_copy(std::vector<__TYPE__> *vector, __TYPE__** dst)\
{\
    const auto size = vector->size();\
    for (size_t i = 0; i < size; i++) dst[i] = &(vector->at(i));\
}\
\
DLLEXPORT bool std_vector_##__TYPENAME__##_empty(std::vector<__TYPE__> *vector)\
{\
    return vector->empty();\
}\
\
DLLEXPORT void std_vector_##__TYPENAME__##_emplace_back(std::vector<__TYPE__> *vector)\
{\
    return vector->emplace_back();\
}\
\
DLLEXPORT __TYPE__* std_vector_##__TYPENAME__##_at(std::vector<__TYPE__> *vector, int index)\
{\
    return &(vector->at(index));\
}\

#define MAKE_FUNC_POINTER(__TYPE__, __TYPENAME__)\
DLLEXPORT std::vector<__TYPE__*>* std_vector_##__TYPENAME__##_new1()\
{\
    return new std::vector<__TYPE__*>;\
}\
\
DLLEXPORT std::vector<__TYPE__*>* std_vector_##__TYPENAME__##_new2(size_t size)\
{\
    return new std::vector<__TYPE__*>(size);\
}\
\
DLLEXPORT std::vector<__TYPE__*>* std_vector_##__TYPENAME__##_new3(__TYPE__** data, size_t dataLength)\
{\
    return new std::vector<__TYPE__*>(data, data + dataLength);\
}\
\
DLLEXPORT size_t std_vector_##__TYPENAME__##_getSize(std::vector<__TYPE__*>* vector)\
{\
    return vector->size();\
}\
\
DLLEXPORT __TYPE__* std_vector_##__TYPENAME__##_getPointer(std::vector<__TYPE__*> *vector)\
{\
    return (vector->at(0));\
}\
\
DLLEXPORT void std_vector_##__TYPENAME__##_delete(std::vector<__TYPE__*> *vector)\
{\
    delete vector;\
}\
\
DLLEXPORT void std_vector_##__TYPENAME__##_copy(std::vector<__TYPE__*> *vector, __TYPE__** dst)\
{\
    size_t length = sizeof(__TYPE__*)* vector->size();\
    memcpy(dst, &(vector->at(0)), length);\
}\
\
DLLEXPORT bool std_vector_##__TYPENAME__##_empty(std::vector<__TYPE__*> *vector)\
{\
    return vector->empty();\
}\
\
DLLEXPORT void std_vector_##__TYPENAME__##_emplace_back(std::vector<__TYPE__*> *vector)\
{\
    return vector->emplace_back();\
}\
\
DLLEXPORT __TYPE__* std_vector_##__TYPENAME__##_at(std::vector<__TYPE__*> *vector, int index)\
{\
    return vector->at(index);\
}\

#pragma endregion template

// primitives
MAKE_FUNC(int32_t, int32_t)
MAKE_FUNC(uint32_t, uint32_t)
MAKE_FUNC(float, float)
MAKE_FUNC(double, double)
MAKE_FUNC(op::LogMode, LogMode)
MAKE_FUNC(op::ErrorMode, ErrorMode)
MAKE_FUNC(op::HeatMapType, HeatMapType)

// 1. Store not T* object but T object in unmanaged world
// 2. Treat as T* object in managed world
//    Store T* object of each T object
MAKE_FUNC_REF(op::Array<float>, op_ArrayOfFloat)

MAKE_FUNC_CLASS(op::Point<int>, PointOfInt32_t)
MAKE_FUNC_CLASS(op::Rectangle<float>, RectangleOfFloat)
//MAKE_FUNC_POINTER(op::Datum, Datum)
MAKE_FUNC_CLASS(op::Datum, Datum)
MAKE_FUNC_CLASS(CustomDatum, CustomDatum)
MAKE_FUNC_CLASS(std::shared_ptr<op::Datum>, StdSharedPtrOfDatum)
MAKE_FUNC_CLASS(std::shared_ptr<CustomDatum>, StdSharedPtrOfCustomDatum)

#endif