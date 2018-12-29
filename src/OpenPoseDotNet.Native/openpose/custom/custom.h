#ifndef _CPP_OP_CUSTOM_CUSTOM_H_
#define _CPP_OP_CUSTOM_CUSTOM_H_

#include "../shared.h"
#include "customDatum.h"
#include "customWorker.h"
#include "customWrapper.h"

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

DLLEXPORT TCustomWorker* op_CustomWorker_new(void (*initializationOnThread_function)(), void (*process_function)(TCustomDatumsSP*))
{
    return new TCustomWorker(new CustomWorker(initializationOnThread_function, process_function));
}

DLLEXPORT void op_CustomWorker_delete(TCustomWorker* worker)
{
    auto content = worker->get();
    delete content;
    delete worker;
}

DLLEXPORT bool op_CustomWorker_checkAndWork(TCustomWorker* worker, TCustomDatumsSP* datums)
{
    auto content = worker->get();
    TCustomDatumsSP& tmp = *datums;
    return content->checkAndWork(tmp);
}

DLLEXPORT bool op_CustomWorker_isRunning(TCustomWorker* worker)
{
    auto content = worker->get();
    return content->isRunning();
}

DLLEXPORT void op_CustomWorker_stop(TCustomWorker* worker)
{
    auto content = worker->get();
    content->stop();
}

DLLEXPORT CustomWrapper* op_custom_wrapper_new(const op::ThreadManagerMode threadManagerMode)
{
    return new CustomWrapper{ threadManagerMode };
}

DLLEXPORT void op_custom_wrapper_delete(CustomWrapper* wrapper)
{
    delete wrapper;
}

DLLEXPORT void op_custom_wrapper_disableMultiThreading(CustomWrapper* wrapper)
{
    wrapper->disableMultiThreading();
}

DLLEXPORT void op_custom_wrapper_setWorker(CustomWrapper* wrapper, const op::WorkerType workerType, const TCustomWorker* worker, const bool workerOnNewThread = true)
{
    auto& tmp = *worker;
    wrapper->setWorker(workerType, tmp, workerOnNewThread);
}

DLLEXPORT void op_custom_wrapper_configure_pose(CustomWrapper* wrapper, op::WrapperStructPose* wrapperStructPose)
{
    auto& tmp = *wrapperStructPose;
    wrapper->configure(tmp);
}

DLLEXPORT void op_custom_wrapper_configure_face(CustomWrapper* wrapper, op::WrapperStructFace* wrapperStructFace)
{
    auto& tmp = *wrapperStructFace;
    wrapper->configure(tmp);
}

DLLEXPORT void op_custom_wrapper_configure_hand(CustomWrapper* wrapper, op::WrapperStructHand* wrapperStructHand)
{
    auto& tmp = *wrapperStructHand;
    wrapper->configure(tmp);
}

DLLEXPORT void op_custom_wrapper_configure_extra(CustomWrapper* wrapper, op::WrapperStructExtra* wrapperStructExtra)
{
    auto& tmp = *wrapperStructExtra;
    wrapper->configure(tmp);
}

DLLEXPORT void op_custom_wrapper_configure_input(CustomWrapper* wrapper, op::WrapperStructInput* wrapperStructInput)
{
    auto& tmp = *wrapperStructInput;
    wrapper->configure(tmp);
}

DLLEXPORT void op_custom_wrapper_configure_output(CustomWrapper* wrapper, op::WrapperStructOutput* wrapperStructOutput)
{
    auto& tmp = *wrapperStructOutput;
    wrapper->configure(tmp);
}

DLLEXPORT void op_custom_wrapper_configure_gui(CustomWrapper* wrapper, op::WrapperStructGui* wrapperStructGui)
{
    auto& tmp = *wrapperStructGui;
    wrapper->configure(tmp);
}

DLLEXPORT void op_custom_wrapper_exec(CustomWrapper* wrapper)
{
    wrapper->exec();
}

DLLEXPORT void op_custom_wrapper_start(CustomWrapper* wrapper)
{
    wrapper->start();
}

DLLEXPORT void op_custom_wrapper_stop(CustomWrapper* wrapper)
{
    wrapper->stop();
}

DLLEXPORT bool op_custom_wrapper_isRunning(CustomWrapper* wrapper)
{
    return wrapper->isRunning();
}

DLLEXPORT bool op_custom_wrapper_tryEmplace(CustomWrapper* wrapper, TCustomDatumsSP* tDatums)
{
    auto& tmp = *tDatums;
    return wrapper->tryEmplace(tmp);
}

DLLEXPORT bool op_custom_wrapper_waitAndEmplace(CustomWrapper* wrapper, TCustomDatumsSP* tDatums)
{
    auto& tmp = *tDatums;
    return wrapper->waitAndEmplace(tmp);
}

DLLEXPORT bool op_custom_wrapper_tryPush(CustomWrapper* wrapper, TCustomDatumsSP* tDatums)
{
    auto& tmp = *tDatums;
    return wrapper->tryPush(tmp);
}

DLLEXPORT bool op_custom_wrapper_waitAndPush(CustomWrapper* wrapper, TCustomDatumsSP* tDatums)
{
    auto& tmp = *tDatums;
    return wrapper->waitAndPush(tmp);
}

DLLEXPORT bool op_custom_wrapper_tryPop(CustomWrapper* wrapper, TCustomDatumsSP** tDatums)
{
    TCustomDatumsSP tmp;
    const auto ret = wrapper->tryPop(tmp);
    *tDatums = new TCustomDatumsSP(tmp);
    return ret;
}

DLLEXPORT bool op_custom_wrapper_waitAndPop(CustomWrapper* wrapper, TCustomDatumsSP** tDatums)
{
    TCustomDatumsSP tmp;
    const auto ret = wrapper->waitAndPop(tmp);
    *tDatums = new TCustomDatumsSP(tmp);
    return ret;
}

DLLEXPORT bool op_custom_wrapper_emplaceAndPop(CustomWrapper* wrapper, TCustomDatumsSP* tDatums)
{
    auto& tmp = *tDatums;
    return wrapper->emplaceAndPop(tmp);
}

DLLEXPORT TCustomDatumsSP* op_custom_wrapper_emplaceAndPop_cvMat(CustomWrapper* wrapper, cv::Mat* cvMat)
{
    const auto& tmp = *cvMat;
	auto ret = wrapper->emplaceAndPop(tmp);
    return new TCustomDatumsSP(ret);
}

DLLEXPORT TCustomDatumsSP* op_custom_wrapper_emplaceAndPop_rawImage(CustomWrapper* wrapper,
                                                                    void* data,
                                                                    const int width,
                                                                    const int height,
                                                                    const int type)
{
    cv::Mat mat(height, width, type, data);
    const auto ret = wrapper->emplaceAndPop(mat);
    return new TCustomDatumsSP(ret);
}

#endif