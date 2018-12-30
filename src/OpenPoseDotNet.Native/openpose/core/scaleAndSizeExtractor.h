#ifndef _CPP_OP_CORE_SCALE_AND_SIZE_EXTRACTOR_H_
#define _CPP_OP_CORE_SCALE_AND_SIZE_EXTRACTOR_H_

#include "../shared.h"

DLLEXPORT op::ScaleAndSizeExtractor* op_core_ScaleAndSizeExtractor_new(const op::Point<int>* netInputResolution,
                                                                       const op::Point<int>* outputResolution,
                                                                       const int scaleNumber = 1,
                                                                       const double scaleGap = 0.25)
{
    return new op::ScaleAndSizeExtractor(*netInputResolution,
                                         *outputResolution,
                                         scaleNumber,
                                         scaleGap);
}

DLLEXPORT void op_core_ScaleAndSizeExtractor_delete(op::ScaleAndSizeExtractor* extractor)
{
    delete extractor;
}

DLLEXPORT void op_core_ScaleAndSizeExtractor_extract(const op::ScaleAndSizeExtractor* extractor,
                                                     const op::Point<int>* inputResolution,
                                                     std::vector<double>** out_vector,
                                                     std::vector<op::Point<int>>** out_points,
                                                     double* out_value,
                                                     int* out_x,
                                                     int* out_y)
{
    const auto ret = extractor->extract(*inputResolution);
    *out_vector = new std::vector<double>(std::get<0>(ret));
    *out_points = new std::vector<op::Point<int>>(std::get<1>(ret));
    *out_value = std::get<2>(ret);
    *out_x = std::get<3>(ret).x;
    *out_y = std::get<3>(ret).y;
}

#endif