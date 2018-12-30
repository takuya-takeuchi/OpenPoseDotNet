#ifndef _CPP_OP_CORE_ARRAY_H_
#define _CPP_OP_CORE_ARRAY_H_

#include "../shared.h"

DLLEXPORT void op_core_array_delete(void* array, array_element_type type)
{
    switch(type)
    {
        case array_element_type::Float:
            delete static_cast<op::Array<float>*>(array);
            break;
    }
}

DLLEXPORT std::string* op_core_Array_toString(void* array, array_element_type type)
{
    switch(type)
    {
        case array_element_type::Float:
            {
                auto tmp = static_cast<op::Array<float>*>(array);
                auto ret = tmp->toString();
                return new std::string(ret);
            }
            break;
    }

    return nullptr;
}

DLLEXPORT int op_core_Array_gets(void* array, array_element_type type, const int index, void** ret)
{
    switch(type)
    {
        case array_element_type::Float:
            {
                auto tmp = static_cast<op::Array<float>*>(array);

                // create return data
                const auto size = tmp->getNumberDimensions();
                auto vector = new std::vector<float>();
                vector->reserve(size);
                for (auto i = index * size, end = index * size + size; i < end; i++) vector->push_back(tmp->at(i));
                *ret = vector;

                return ERR_OK;
            }
            break;
    }

    return ERR_COMMON_TYPE_NOT_SUPPORT;
}

DLLEXPORT int op_core_Array_getSize(void* array, array_element_type type, const int index, int* ret)
{
    switch(type)
    {
        case array_element_type::Float:
            {
                auto tmp = static_cast<op::Array<float>*>(array);
                *ret = tmp->getSize(index);
                return ERR_OK;
            }
            break;
    }

    return ERR_COMMON_TYPE_NOT_SUPPORT;
}

DLLEXPORT int op_core_Array_getSize2(void* array, array_element_type type, std::vector<int>** ret)
{
    switch(type)
    {
        case array_element_type::Float:
            {
                auto tmp = static_cast<op::Array<float>*>(array);
                const auto tmpret = tmp->getSize();
                *ret = new std::vector<int>(tmpret);
                return ERR_OK;
            }
            break;
    }

    return ERR_COMMON_TYPE_NOT_SUPPORT;
}

DLLEXPORT int op_core_Array_getNumberDimensions(void* array, array_element_type type, size_t* ret)
{
    switch(type)
    {
        case array_element_type::Float:
            {
                auto tmp = static_cast<op::Array<float>*>(array);
                *ret = tmp->getNumberDimensions();
                return ERR_OK;
            }
            break;
    }

    return ERR_COMMON_TYPE_NOT_SUPPORT;
}

DLLEXPORT int op_core_Array_getVolume(void* array, array_element_type type, size_t* ret)
{
    switch(type)
    {
        case array_element_type::Float:
            {
                auto tmp = static_cast<op::Array<float>*>(array);
                *ret = tmp->getVolume();
                return ERR_OK;
            }
            break;
    }

    return ERR_COMMON_TYPE_NOT_SUPPORT;
}

DLLEXPORT int op_core_Array_empty(void* array, array_element_type type, bool* ret)
{
    switch(type)
    {
        case array_element_type::Float:
            {
                auto tmp = static_cast<op::Array<float>*>(array);
                *ret = tmp->empty();
                return ERR_OK;
            }
            break;
    }

    return ERR_COMMON_TYPE_NOT_SUPPORT;
}

#endif