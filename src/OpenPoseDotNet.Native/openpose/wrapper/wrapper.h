#ifndef _CPP_OP_WRAPPER_WRAPPER_H_
#define _CPP_OP_WRAPPER_WRAPPER_H_

#include "../shared.h"
#include <opencv2/core/mat.hpp>

typedef std::vector<op::Datum> TDatums;
typedef std::shared_ptr<TDatums> TDatumsSP;
typedef std::shared_ptr<op::Worker<TDatumsSP>> TWorker;

MAKE_SHARED_PTR_FUNC(std::vector<op::Datum>, TDatums)

DLLEXPORT op::Wrapper* op_wrapper_new(const op::ThreadManagerMode threadManagerMode)
{
    return new op::Wrapper{ threadManagerMode };
}

DLLEXPORT void op_wrapper_delete(op::Wrapper* wrapper)
{
    delete wrapper;
}

DLLEXPORT void op_wrapper_disableMultiThreading(op::Wrapper* wrapper)
{
    wrapper->disableMultiThreading();
}

DLLEXPORT void op_wrapper_setWorker(op::Wrapper* wrapper, const op::WorkerType workerType, const TWorker* worker, const bool workerOnNewThread = true)
{
    auto& tmp = *worker;
    wrapper->setWorker(workerType, tmp, workerOnNewThread);
}

DLLEXPORT void op_wrapper_configure_pose(op::Wrapper* wrapper, op::WrapperStructPose* wrapperStructPose)
{
    auto& tmp = *wrapperStructPose;
    wrapper->configure(tmp);
}

DLLEXPORT void op_wrapper_configure_face(op::Wrapper* wrapper, op::WrapperStructFace* wrapperStructFace)
{
    auto& tmp = *wrapperStructFace;
    wrapper->configure(tmp);
}

DLLEXPORT void op_wrapper_configure_hand(op::Wrapper* wrapper, op::WrapperStructHand* wrapperStructHand)
{
    auto& tmp = *wrapperStructHand;
    wrapper->configure(tmp);
}

DLLEXPORT void op_wrapper_configure_extra(op::Wrapper* wrapper, op::WrapperStructExtra* wrapperStructExtra)
{
    auto& tmp = *wrapperStructExtra;
    wrapper->configure(tmp);
}

DLLEXPORT void op_wrapper_configure_input(op::Wrapper* wrapper, op::WrapperStructInput* wrapperStructInput)
{
    auto& tmp = *wrapperStructInput;
    wrapper->configure(tmp);
}

DLLEXPORT void op_wrapper_configure_output(op::Wrapper* wrapper, op::WrapperStructOutput* wrapperStructOutput)
{
    auto& tmp = *wrapperStructOutput;
    wrapper->configure(tmp);
}

DLLEXPORT void op_wrapper_configure_gui(op::Wrapper* wrapper, op::WrapperStructGui* wrapperStructGui)
{
    auto& tmp = *wrapperStructGui;
    wrapper->configure(tmp);
}

DLLEXPORT void op_wrapper_exec(op::Wrapper* wrapper)
{
    wrapper->exec();
}

DLLEXPORT void op_wrapper_start(op::Wrapper* wrapper)
{
    wrapper->start();
}

DLLEXPORT void op_wrapper_stop(op::Wrapper* wrapper)
{
    wrapper->stop();
}

DLLEXPORT bool op_wrapper_isRunning(op::Wrapper* wrapper)
{
    return wrapper->isRunning();
}

DLLEXPORT bool op_wrapper_tryEmplace(op::Wrapper* wrapper, TDatumsSP* tDatums)
{
    auto& tmp = *tDatums;
    return wrapper->tryEmplace(tmp);
}

DLLEXPORT bool op_wrapper_waitAndEmplace(op::Wrapper* wrapper, TDatumsSP* tDatums)
{
    auto& tmp = *tDatums;
    return wrapper->waitAndEmplace(tmp);
}

DLLEXPORT bool op_wrapper_tryPush(op::Wrapper* wrapper, TDatumsSP* tDatums)
{
    auto& tmp = *tDatums;
    return wrapper->tryPush(tmp);
}

DLLEXPORT bool op_wrapper_waitAndPush(op::Wrapper* wrapper, TDatumsSP* tDatums)
{
    auto& tmp = *tDatums;
    return wrapper->waitAndPush(tmp);
}

DLLEXPORT bool op_wrapper_tryPop(op::Wrapper* wrapper, TDatumsSP** tDatums)
{
    TDatumsSP tmp;
    const auto ret = wrapper->tryPop(tmp);
    *tDatums = new TDatumsSP(tmp);
    return ret;
}

DLLEXPORT bool op_wrapper_waitAndPop(op::Wrapper* wrapper, TDatumsSP** tDatums)
{
    TDatumsSP tmp;
    const auto ret = wrapper->waitAndPop(tmp);
    *tDatums = new TDatumsSP(tmp);
    return ret;
}

DLLEXPORT bool op_wrapper_emplaceAndPop(op::Wrapper* wrapper, TDatumsSP* tDatums)
{
    auto& tmp = *tDatums;
    return wrapper->emplaceAndPop(tmp);
}

DLLEXPORT TDatumsSP* op_wrapper_emplaceAndPop_cvMat(op::Wrapper* wrapper, cv::Mat* cvMat)
{
    const auto& tmp = *cvMat;
	auto ret = wrapper->emplaceAndPop(tmp);
    return new TDatumsSP(ret);
}

DLLEXPORT TDatumsSP* op_wrapper_emplaceAndPop_rawImage(op::Wrapper* wrapper,
                                                       void* data,
                                                       const int width,
                                                       const int height,
                                                       const int type)
{
    cv::Mat mat(height, width, type, data);
    const auto ret = wrapper->emplaceAndPop(mat);
    return new TDatumsSP(ret);
}

#endif