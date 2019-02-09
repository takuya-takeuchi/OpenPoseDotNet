#ifndef _CPP_OP_WRAPPER_WRAPPERSTRUCTHAND_H_
#define _CPP_OP_WRAPPER_WRAPPERSTRUCTHAND_H_

#include "../shared.h"

DLLEXPORT op::WrapperStructHand* op_wrapperStructHand_new(const bool enable,
                                                          const op::Detector detector,
                                                          const op::Point<int>* netInputSize,
                                                          const int scalesNumber,
                                                          const float scaleRange,
                                                          const op::RenderMode renderMode,
                                                          const float alphaKeypoint,
                                                          const float alphaHeatMap,
                                                          const float renderThreshold)
{
    return new op::WrapperStructHand(enable,
                                     detector,
                                     *netInputSize,
                                     scalesNumber,
                                     scaleRange,
                                     renderMode,
                                     alphaKeypoint,
                                     alphaHeatMap,
                                     renderThreshold);
}

DLLEXPORT void op_wrapperStructHand_delete(op::WrapperStructHand* hand)
{
    delete hand;
}

DLLEXPORT bool op_wrapperStructHand_get_enable(op::WrapperStructHand* hand)
{
    return hand->enable;
}

DLLEXPORT void op_wrapperStructHand_set_enable(op::WrapperStructHand* hand, const bool enable)
{
    hand->enable = enable;
}

#endif