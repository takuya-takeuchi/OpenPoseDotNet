#ifndef _CPP_OP_WRAPPER_WRAPPER_H_
#define _CPP_OP_WRAPPER_WRAPPER_H_

#include "../shared.h"
#include <opencv2/core/mat.hpp>
#include "../defines.h"
#include "../custom/customWrapper.h"

typedef std::vector<op::Datum> TDatums;

MAKE_SHARED_PTR_FUNC(std::vector<op::Datum>, TDatums)

DLLEXPORT void* op_wrapper_new(const data_type dataType, const op::ThreadManagerMode threadManagerMode)
{
    switch(dataType)
    {
        case data_type::Default:
            return new op::Wrapper{ threadManagerMode };
        case data_type::Custom:
            return new CustomWrapper{ threadManagerMode };
    }

    return nullptr;
}

DLLEXPORT void op_wrapper_delete(const data_type dataType, void* wrapper)
{
    switch(dataType)
    {
        case data_type::Default:
            delete ((op::Wrapper*)wrapper);
            break;
        case data_type::Custom:
            delete ((CustomWrapper*)wrapper);
            break;
    }
}

DLLEXPORT void op_wrapper_disableMultiThreading(const data_type dataType, void* wrapper)
{
    switch(dataType)
    {
        case data_type::Default:
            ((op::Wrapper*)wrapper)->disableMultiThreading();
            break;
        case data_type::Custom:
            ((CustomWrapper*)wrapper)->disableMultiThreading();
            break;
    }
}

DLLEXPORT void op_wrapper_setWorker(const data_type dataType, void* wrapper, const op::WorkerType workerType, void* worker, const bool workerOnNewThread = true)
{
    switch(dataType)
    {
        case data_type::Default:
            {
                auto& tmp = *(static_cast<DefaultWorker*>(worker));
                ((op::Wrapper*)wrapper)->setWorker(workerType, tmp, workerOnNewThread);
            }
            break;
        case data_type::Custom:
            {
                auto& tmp = *(static_cast<CustomWorker*>(worker));
                ((CustomWrapper*)wrapper)->setWorker(workerType, tmp, workerOnNewThread);
            }
            break;
    }
}

DLLEXPORT void op_wrapper_configure_pose(const data_type dataType, void* wrapper, op::WrapperStructPose* wrapperStructPose)
{
    auto& tmp = *wrapperStructPose;
    
    switch(dataType)
    {
        case data_type::Default:
            ((op::Wrapper*)wrapper)->configure(tmp);
            break;
        case data_type::Custom:
            ((CustomWrapper*)wrapper)->configure(tmp);
            break;
    }
}

DLLEXPORT void op_wrapper_configure_face(const data_type dataType, void* wrapper, op::WrapperStructFace* wrapperStructFace)
{
    auto& tmp = *wrapperStructFace;
    
    switch(dataType)
    {
        case data_type::Default:
            ((op::Wrapper*)wrapper)->configure(tmp);
            break;
        case data_type::Custom:
            ((CustomWrapper*)wrapper)->configure(tmp);
            break;
    }
}

DLLEXPORT void op_wrapper_configure_hand(const data_type dataType, void* wrapper, op::WrapperStructHand* wrapperStructHand)
{
    auto& tmp = *wrapperStructHand;
    
    switch(dataType)
    {
        case data_type::Default:
            ((op::Wrapper*)wrapper)->configure(tmp);
            break;
        case data_type::Custom:
            ((CustomWrapper*)wrapper)->configure(tmp);
            break;
    }
}

DLLEXPORT void op_wrapper_configure_extra(const data_type dataType, void* wrapper, op::WrapperStructExtra* wrapperStructExtra)
{
    auto& tmp = *wrapperStructExtra;
    
    switch(dataType)
    {
        case data_type::Default:
            ((op::Wrapper*)wrapper)->configure(tmp);
            break;
        case data_type::Custom:
            ((CustomWrapper*)wrapper)->configure(tmp);
            break;
    }
}

DLLEXPORT void op_wrapper_configure_input(const data_type dataType, void* wrapper, op::WrapperStructInput* wrapperStructInput)
{
    auto& tmp = *wrapperStructInput;
    
    switch(dataType)
    {
        case data_type::Default:
            ((op::Wrapper*)wrapper)->configure(tmp);
            break;
        case data_type::Custom:
            ((CustomWrapper*)wrapper)->configure(tmp);
            break;
    }
}

DLLEXPORT void op_wrapper_configure_output(const data_type dataType, void* wrapper, op::WrapperStructOutput* wrapperStructOutput)
{
    auto& tmp = *wrapperStructOutput;
    
    switch(dataType)
    {
        case data_type::Default:
            ((op::Wrapper*)wrapper)->configure(tmp);
            break;
        case data_type::Custom:
            ((CustomWrapper*)wrapper)->configure(tmp);
            break;
    }
}

DLLEXPORT void op_wrapper_configure_gui(const data_type dataType, void* wrapper, op::WrapperStructGui* wrapperStructGui)
{
    auto& tmp = *wrapperStructGui;
    
    switch(dataType)
    {
        case data_type::Default:
            ((op::Wrapper*)wrapper)->configure(tmp);
            break;
        case data_type::Custom:
            ((CustomWrapper*)wrapper)->configure(tmp);
            break;
    }
}

DLLEXPORT void op_wrapper_exec(const data_type dataType, void* wrapper)
{
    switch(dataType)
    {
        case data_type::Default:
            ((op::Wrapper*)wrapper)->exec();
            break;
        case data_type::Custom:
            ((CustomWrapper*)wrapper)->exec();
            break;
    }
}

DLLEXPORT void op_wrapper_start(const data_type dataType, void* wrapper)
{
    switch(dataType)
    {
        case data_type::Default:
            ((op::Wrapper*)wrapper)->start();
            break;
        case data_type::Custom:
            ((CustomWrapper*)wrapper)->start();
            break;
    }
}

DLLEXPORT void op_wrapper_stop(const data_type dataType, void* wrapper)
{
    switch(dataType)
    {
        case data_type::Default:
            ((op::Wrapper*)wrapper)->stop();
            break;
        case data_type::Custom:
            ((CustomWrapper*)wrapper)->stop();
            break;
    }
}

DLLEXPORT bool op_wrapper_isRunning(const data_type dataType, void* wrapper)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            ret = ((op::Wrapper*)wrapper)->isRunning();
            break;
        case data_type::Custom:
            ret = ((CustomWrapper*)wrapper)->isRunning();
            break;
    }

    return ret;
}

DLLEXPORT bool op_wrapper_tryEmplace(const data_type dataType, void* wrapper, void* tDatums)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            {
                auto& tmp = *(static_cast<DefaultDatums*>(tDatums));
                ret = ((op::Wrapper*)wrapper)->tryEmplace(tmp);
            }
            break;
        case data_type::Custom:
            {
                auto& tmp = *(static_cast<CustomDatums*>(tDatums));
                ret = ((CustomWrapper*)wrapper)->tryEmplace(tmp);
            }
            break;
    }

    return ret;
}

DLLEXPORT bool op_wrapper_waitAndEmplace(const data_type dataType, void* wrapper, void* tDatums)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            {
                auto& tmp = *(static_cast<DefaultDatums*>(tDatums));
                ret = ((op::Wrapper*)wrapper)->waitAndEmplace(tmp);
            }
            break;
        case data_type::Custom:
            {
                auto& tmp = *(static_cast<CustomDatums*>(tDatums));
                ret = ((CustomWrapper*)wrapper)->waitAndEmplace(tmp);
            }
            break;
    }

    return ret;
}

DLLEXPORT bool op_wrapper_tryPush(const data_type dataType, void* wrapper, void* tDatums)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            {
                auto& tmp = *(static_cast<DefaultDatums*>(tDatums));
                ret = ((op::Wrapper*)wrapper)->tryPush(tmp);
            }
            break;
        case data_type::Custom:
            {
                auto& tmp = *(static_cast<CustomDatums*>(tDatums));
                ret = ((CustomWrapper*)wrapper)->tryPush(tmp);
            }
            break;
    }

    return ret;
}

DLLEXPORT bool op_wrapper_waitAndPush(const data_type dataType, void* wrapper, void* tDatums)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            {
                auto& tmp = *(static_cast<DefaultDatums*>(tDatums));
                ret = ((op::Wrapper*)wrapper)->waitAndPush(tmp);
            }
            break;
        case data_type::Custom:
            {
                auto& tmp = *(static_cast<CustomDatums*>(tDatums));
                ret = ((CustomWrapper*)wrapper)->waitAndPush(tmp);
            }
            break;
    }

    return ret;
}

DLLEXPORT bool op_wrapper_tryPop(const data_type dataType, void* wrapper, void** tDatums)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            {
                DefaultDatums tmp;
                ret = ((op::Wrapper*)wrapper)->tryPop(tmp);
                *tDatums = new DefaultDatums(tmp);
            }
            break;
        case data_type::Custom:
            {
                CustomDatums tmp;
                ret = ((CustomWrapper*)wrapper)->tryPop(tmp);
                *tDatums = new CustomDatums(tmp);
            }
            break;
    }

    return ret;
}

DLLEXPORT bool op_wrapper_waitAndPop(const data_type dataType, void* wrapper, void** tDatums)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            {
                DefaultDatums tmp;
                ret = ((op::Wrapper*)wrapper)->waitAndPop(tmp);
                *tDatums = new DefaultDatums(tmp);
            }
            break;
        case data_type::Custom:
            {
                CustomDatums tmp;
                ret = ((CustomWrapper*)wrapper)->waitAndPop(tmp);
                *tDatums = new CustomDatums(tmp);
            }
            break;
    }

    return ret;
}

DLLEXPORT bool op_wrapper_emplaceAndPop(const data_type dataType, void* wrapper, void* tDatums)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            {
                auto& tmp = *(static_cast<DefaultDatums*>(tDatums));
                ret = ((op::Wrapper*)wrapper)->emplaceAndPop(tmp);
            }
            break;
        case data_type::Custom:
            {
                auto& tmp = *(static_cast<CustomDatums*>(tDatums));
                ret = ((CustomWrapper*)wrapper)->emplaceAndPop(tmp);
            }
            break;
    }

    return ret;
}

DLLEXPORT void* op_wrapper_emplaceAndPop_cvMat(const data_type dataType, void* wrapper, cv::Mat* cvMat)
{
    switch(dataType)
    {
        case data_type::Default:
            {
                const auto& tmp = *cvMat;
                const auto ret = ((op::Wrapper*)wrapper)->emplaceAndPop(tmp);
                return new DefaultDatums(ret);
            }
            break;
        case data_type::Custom:
            {
                const auto& tmp = *cvMat;
                const auto ret = ((CustomWrapper*)wrapper)->emplaceAndPop(tmp);
                return new CustomDatums(ret);
            }
            break;
    }

    return nullptr;
}

DLLEXPORT void* op_wrapper_emplaceAndPop_rawImage(const data_type dataType,
                                                  void* wrapper,
                                                  void* data,
                                                  const int width,
                                                  const int height,
                                                  const int type)
{
    switch(dataType)
    {
        case data_type::Default:
            {
                cv::Mat mat(height, width, type, data);
                const auto ret = ((op::Wrapper*)wrapper)->emplaceAndPop(mat);
                return new DefaultDatums(ret);
            }
            break;
        case data_type::Custom:
            {
                cv::Mat mat(height, width, type, data);
                const auto ret = ((CustomWrapper*)wrapper)->emplaceAndPop(mat);
                return new CustomDatums(ret);
            }
            break;
    }

    return nullptr;
}

#endif