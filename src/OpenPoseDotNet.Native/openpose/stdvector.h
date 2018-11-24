#ifndef _CPP_VECTOR_H_
#define _CPP_VECTOR_H_

#include "export.h"
#include <openpose/headers.hpp>
#include "shared.h"

#pragma region template

#define MAKE_FUNC(__TYPE__, __TYPENAME__)\
DLLEXPORT std::vector<__TYPE__>* stdvector_##__TYPENAME__##_new1()\
{\
    return new std::vector<__TYPE__>;\
}\
\
DLLEXPORT std::vector<__TYPE__>* stdvector_##__TYPENAME__##_new2(size_t size)\
{\
    return new std::vector<__TYPE__>(size);\
}\
\
DLLEXPORT std::vector<__TYPE__>* stdvector_##__TYPENAME__##_new3(__TYPE__* data, size_t dataLength)\
{\
    return new std::vector<__TYPE__>(data, data + dataLength);\
}\
\
DLLEXPORT size_t stdvector_##__TYPENAME__##_getSize(std::vector<__TYPE__>* vector)\
{\
    return vector->size();\
}\
\
DLLEXPORT __TYPE__* stdvector_##__TYPENAME__##_getPointer(std::vector<__TYPE__> *vector)\
{\
    return &(vector->at(0));\
}\
\
DLLEXPORT void stdvector_##__TYPENAME__##_delete(std::vector<__TYPE__> *vector)\
{\
    delete vector;\
}\
\
DLLEXPORT void stdvector_##__TYPENAME__##_copy(std::vector<__TYPE__> *vector, __TYPE__* dst)\
{\
    size_t length = sizeof(__TYPE__) * vector->size();\
    memcpy(dst, &(vector->at(0)), length);\
}\
\
DLLEXPORT bool stdvector_##__TYPENAME__##_empty(std::vector<__TYPE__> *vector)\
{\
    return vector->empty();\
}\

#define MAKE_FUNC_CLASS(__TYPE__, __TYPENAME__)\
DLLEXPORT std::vector<__TYPE__>* stdvector_##__TYPENAME__##_new1()\
{\
    return new std::vector<__TYPE__>;\
}\
\
DLLEXPORT std::vector<__TYPE__>* stdvector_##__TYPENAME__##_new2(size_t size)\
{\
    return new std::vector<__TYPE__>(size);\
}\
\
DLLEXPORT std::vector<__TYPE__>* stdvector_##__TYPENAME__##_new3(__TYPE__* data, size_t dataLength)\
{\
    return new std::vector<__TYPE__>(data, data + dataLength);\
}\
\
DLLEXPORT size_t stdvector_##__TYPENAME__##_getSize(std::vector<__TYPE__>* vector)\
{\
    return vector->size();\
}\
\
DLLEXPORT __TYPE__* stdvector_##__TYPENAME__##_getPointer(std::vector<__TYPE__> *vector)\
{\
    return &(vector->at(0));\
}\
\
DLLEXPORT void stdvector_##__TYPENAME__##_delete(std::vector<__TYPE__> *vector)\
{\
    delete vector;\
}\
\
DLLEXPORT void stdvector_##__TYPENAME__##_copy(std::vector<__TYPE__> *vector, __TYPE__** dst)\
{\
    const auto size = vector->size();\
    for (size_t i = 0; i < size; i++) dst[i] = &(vector->at(i));\
}\
\
DLLEXPORT bool stdvector_##__TYPENAME__##_empty(std::vector<__TYPE__> *vector)\
{\
    return vector->empty();\
}\

#define MAKE_FUNC_POINTER(__TYPE__, __TYPENAME__)\
DLLEXPORT std::vector<__TYPE__*>* stdvector_##__TYPENAME__##_new1()\
{\
    return new std::vector<__TYPE__*>;\
}\
\
DLLEXPORT std::vector<__TYPE__*>* stdvector_##__TYPENAME__##_new2(size_t size)\
{\
    return new std::vector<__TYPE__*>(size);\
}\
\
DLLEXPORT std::vector<__TYPE__*>* stdvector_##__TYPENAME__##_new3(__TYPE__** data, size_t dataLength)\
{\
    return new std::vector<__TYPE__*>(data, data + dataLength);\
}\
\
DLLEXPORT size_t stdvector_##__TYPENAME__##_getSize(std::vector<__TYPE__*>* vector)\
{\
    return vector->size();\
}\
\
DLLEXPORT __TYPE__* stdvector_##__TYPENAME__##_getPointer(std::vector<__TYPE__*> *vector)\
{\
    return (vector->at(0));\
}\
\
DLLEXPORT void stdvector_##__TYPENAME__##_delete(std::vector<__TYPE__*> *vector)\
{\
    delete vector;\
}\
\
DLLEXPORT void stdvector_##__TYPENAME__##_copy(std::vector<__TYPE__*> *vector, __TYPE__** dst)\
{\
    size_t length = sizeof(__TYPE__*)* vector->size();\
    memcpy(dst, &(vector->at(0)), length);\
}\
\
DLLEXPORT bool stdvector_##__TYPENAME__##_delete(std::vector<__TYPE__*> *vector)\
{\
    return vector->empty();\
}\

#pragma endregion template

// primitives
MAKE_FUNC(op::LogMode, LogMode)
MAKE_FUNC(op::ErrorMode, ErrorMode)

// class (pointer)
MAKE_FUNC_CLASS(op::Datum, Datum)
//stdvector_Datum_copy

#endif