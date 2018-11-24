#ifndef _CPP_OP_WRAPPER_WRAPPERSTRUCTHAND_H_
#define _CPP_OP_WRAPPER_WRAPPERSTRUCTHAND_H_

#include "../shared.h"

DLLEXPORT op::WrapperStructHand* op_wrapper_wrapperStructHand_new(const bool enable)
{
    return new op::WrapperStructHand(enable);
}

DLLEXPORT void op_wrapper_wrapperStructHand_delete(op::WrapperStructHand* hand)
{
    delete hand;
}

DLLEXPORT bool op_wrapper_wrapperStructHand_get_enable(op::WrapperStructHand* hand)
{
    return hand->enable;
}

DLLEXPORT void op_wrapper_wrapperStructHand_set_enable(op::WrapperStructHand* hand, const bool enable)
{
    hand->enable = enable;
}

#endif