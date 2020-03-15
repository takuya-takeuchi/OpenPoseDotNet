#ifndef _CPP_OP_CORE_DATUM_H_
#define _CPP_OP_CORE_DATUM_H_

#include "../shared.h"

DLLEXPORT op::Datum* op_core_datum_new()
{
    return new op::Datum();
}

DLLEXPORT void op_core_datum_delete(const op::Datum* datum)
{
    delete datum;
}

DLLEXPORT unsigned long long op_core_datum_get_id(const op::Datum* datum)
{
    return datum->id;
}

DLLEXPORT unsigned long long op_core_datum_get_subId(const op::Datum* datum)
{
    return datum->subId;
}

DLLEXPORT unsigned long long op_core_datum_get_subIdMax(const op::Datum* datum)
{
    return datum->subIdMax;
}

DLLEXPORT unsigned long long op_core_datum_get_frameNumber(const op::Datum* datum)
{
    return datum->frameNumber;
}

DLLEXPORT op::Matrix* op_core_datum_get_cvInputData(op::Datum* datum)
{
    return &datum->cvInputData;
}

DLLEXPORT void op_core_datum_set_cvInputData(op::Datum* datum, op::Matrix* mat)
{
    datum->cvInputData = *mat;
}

DLLEXPORT std::vector<op::Array<float>>* op_core_datum_get_inputNetData(op::Datum* datum)
{
    return &datum->inputNetData;
}

DLLEXPORT op::Matrix* op_core_datum_get_cvOutputData(op::Datum* datum)
{
    return &datum->cvOutputData;
}

DLLEXPORT void op_core_datum_set_cvOutputData(op::Datum* datum, op::Matrix* mat)
{
    datum->cvOutputData = *mat;
}

DLLEXPORT op::Array<float>* op_core_datum_get_poseKeypoints(op::Datum* datum)
{
    return &datum->poseKeypoints;
}

DLLEXPORT op::Array<float>* op_core_datum_get_faceKeypoints(op::Datum* datum)
{
    return &datum->faceKeypoints;
}

DLLEXPORT std::array<op::Array<float>, 2>* op_core_datum_get_handKeypoints(op::Datum* datum)
{
    return &datum->handKeypoints;
}

DLLEXPORT op::Array<float>* op_core_datum_get_poseHeatMaps(op::Datum* datum)
{
    return &datum->poseHeatMaps;
}

DLLEXPORT op::Array<float>* op_core_datum_get_poseNetOutput(op::Datum* datum)
{
    return &datum->poseNetOutput;
}

DLLEXPORT void op_core_datum_set_poseNetOutput(op::Datum* datum, op::Array<float>* output)
{
    datum->poseNetOutput = *output;
}

DLLEXPORT op::Array<float>* op_core_datum_get_faceHeatMaps(op::Datum* datum)
{
    return &datum->faceHeatMaps;
}

DLLEXPORT std::array<op::Array<float>, 2>* op_core_datum_get_handHeatMaps(op::Datum* datum)
{
    return &datum->handHeatMaps;
}

DLLEXPORT std::vector<op::Rectangle<float>>* op_core_datum_get_faceRectangles(const op::Datum* datum)
{
    const auto ret = &datum->faceRectangles;
    auto vec = new std::vector<op::Rectangle<float>>();
    for (auto i = 0; i < ret->size(); i++)
        vec->push_back(ret->at(i));

    return vec;
}

DLLEXPORT void op_core_datum_set_faceRectangles(op::Datum* datum, std::vector<op::Rectangle<float>>* rectangles)
{
    datum->faceRectangles = *rectangles;
}

DLLEXPORT std::vector<op::Rectangle<float>>* op_core_datum_get_handRectangles(const op::Datum* datum)
{
    const auto ret = &datum->handRectangles;
    auto vec = new std::vector<op::Rectangle<float>>();
    for (auto i = 0; i < ret->size(); i++)
    for (auto j = 0; j < 2; j++)
        vec->push_back(ret->at(i)[j]);

    return vec;
}

DLLEXPORT void op_core_datum_set_handRectangles(op::Datum* datum, std::vector<op::Rectangle<float>>* rectangles)
{
    const auto& r = *static_cast<std::vector<op::Rectangle<float>>*>(rectangles);
    std::vector<std::array<op::Rectangle<float>, 2>> vector;
    for (auto i = 0; i < r.size(); i++)
        if (i % 2 == 0)
        {
            std::array<op::Rectangle<float>, 2> a;
            a.at(0) = r[i];
            vector.push_back(a);
        }
        else
        {
            auto& a = vector[i % 2];
            a.at(1) = r[i];
        }

    datum->handRectangles = vector;
}

#endif