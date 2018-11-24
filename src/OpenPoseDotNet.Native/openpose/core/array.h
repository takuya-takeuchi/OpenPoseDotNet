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

#endif