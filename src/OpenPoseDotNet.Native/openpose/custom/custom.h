#ifndef _CPP_OP_CUSTOM_CUSTOM_H_
#define _CPP_OP_CUSTOM_CUSTOM_H_

#include "../shared.h"
#include "customDatum.h"
#include "../user/userWorker.h"

MAKE_SHARED_PTR_FUNC(std::vector<CustomDatum>, CustomDatum)

DLLEXPORT CustomDatum* op_CustomDatum_new()
{
    return new CustomDatum();
}

DLLEXPORT void op_CustomDatum_delete(CustomDatum* datum)
{
    delete datum;
}

DLLEXPORT void* op_CustomDatum_get_data(CustomDatum* datum)
{
    return datum->data;
}

DLLEXPORT void op_CustomDatum_set_data(CustomDatum* datum, void* data)
{
    datum->data = data;
}

#endif