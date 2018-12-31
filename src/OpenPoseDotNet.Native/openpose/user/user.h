#ifndef _CPP_OP_USER_USER_H_
#define _CPP_OP_USER_USER_H_

#include "../shared.h"
#include "../defines.h"
#include "userWorker.h"
#include "userWorkerConsumer.h"
#include "userWorkerProducer.h"

#pragma region UserWorker

DLLEXPORT void* op_UserWorker_new(const data_type dataType, void (*initializationOnThread_function)(), void* process_function)
{
    switch(dataType)
    {
        case data_type::Default:
            return new DefaultUserWorker(initializationOnThread_function,
                                         (void (*)(DefaultDatums*)) process_function);
        case data_type::Custom:
            return new CustomUserWorker(initializationOnThread_function,
                                        (void (*)(CustomDatums*)) process_function);
    }

    return nullptr;
}

DLLEXPORT void op_UserWorker_delete(const data_type dataType, void* worker)
{
    switch(dataType)
    {
        case data_type::Default:
            delete ((DefaultUserWorker*)worker);
            break;
        case data_type::Custom:
            delete ((CustomUserWorker*)worker);
            break;
    }
}

DLLEXPORT bool op_UserWorker_checkAndWork(const data_type dataType, void* worker, void* datums)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            {
                auto& tmp = *static_cast<DefaultDatums*>(datums);
                ret = ((DefaultUserWorker*)worker)->checkAndWork(tmp);
            }
            break;
        case data_type::Custom:
            {
                auto& tmp = *static_cast<CustomDatums*>(datums);
                ret = ((CustomUserWorker*)worker)->checkAndWork(tmp);
            }
            break;
    }

    return ret;
}

DLLEXPORT bool op_UserWorker_isRunning(const data_type dataType, void* worker)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            ret = ((DefaultUserWorker*)worker)->isRunning();
            break;
        case data_type::Custom:
            ret = ((CustomUserWorker*)worker)->isRunning();
            break;
    }

    return ret;
}

DLLEXPORT void op_UserWorker_stop(const data_type dataType, void* worker)
{
    switch(dataType)
    {
        case data_type::Default:
            {
                auto content = ((DefaultUserWorker*)worker);
                content->stop();
            }
            break;
        case data_type::Custom:
            {
                auto content = ((CustomUserWorker*)worker);
                content->stop();
            }
            break;
    }
}

#pragma endregion UserWorker

#pragma region UserWorkerConsumer

DLLEXPORT void* op_UserWorkerConsumer_new(const data_type dataType, void (*initializationOnThread_function)(), void* process_function)
{
    switch(dataType)
    {
        case data_type::Default:
            return new DefaultUserWorkerConsumer(initializationOnThread_function,
                                                 (void (*)(const DefaultDatums*)) process_function);
        case data_type::Custom:
            return new CustomUserWorkerConsumer(initializationOnThread_function,
                                                 (void (*)(const CustomDatums*)) process_function);
    }

    return nullptr;
}

DLLEXPORT void op_UserWorkerConsumer_delete(const data_type dataType, void* worker)
{
    switch(dataType)
    {
        case data_type::Default:
            delete ((DefaultUserWorkerConsumer*)worker);
            break;
        case data_type::Custom:
            delete ((CustomUserWorkerConsumer*)worker);
            break;
    }
}

DLLEXPORT bool op_UserWorkerConsumer_checkAndWork(const data_type dataType, void* worker, void* datums)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            {
                auto& tmp = *static_cast<DefaultDatums*>(datums);
                ret = ((DefaultUserWorkerConsumer*)worker)->checkAndWork(tmp);
            }
            break;
        case data_type::Custom:
            {
                auto& tmp = *static_cast<CustomDatums*>(datums);
                ret = ((CustomUserWorkerConsumer*)worker)->checkAndWork(tmp);
            }
            break;
    }

    return ret;
}

DLLEXPORT bool op_UserWorkerConsumer_isRunning(const data_type dataType, void* worker)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            ret = ((DefaultUserWorkerConsumer*)worker)->isRunning();
            break;
        case data_type::Custom:
            ret = ((CustomUserWorkerConsumer*)worker)->isRunning();
            break;
    }

    return ret;
}

DLLEXPORT void op_UserWorkerConsumer_stop(const data_type dataType, void* worker)
{
    switch(dataType)
    {
        case data_type::Default:
            ((DefaultUserWorkerConsumer*)worker)->stop();
            break;
        case data_type::Custom:
            ((CustomUserWorkerConsumer*)worker)->stop();
            break;
    }
}

#pragma endregion UserWorkerConsumer

#pragma region UserWorkerProducer

DLLEXPORT void* op_UserWorkerProducer_new(const data_type dataType, void (*initializationOnThread_function)(), void* process_function)
{
    switch(dataType)
    {
        case data_type::Default:
            return new DefaultUserWorkerProducer(initializationOnThread_function,
                                                 (DefaultDatums* (*)()) process_function);
        case data_type::Custom:
            return new CustomUserWorkerProducer(initializationOnThread_function,
                                                 (CustomDatums* (*)()) process_function);
    }

    return nullptr;
}

DLLEXPORT void op_UserWorkerProducer_delete(const data_type dataType, void* worker)
{
    switch(dataType)
    {
        case data_type::Default:
            delete ((DefaultUserWorkerProducer*)worker);
            break;
        case data_type::Custom:
            delete ((CustomUserWorkerProducer*)worker);
            break;
    }
}

DLLEXPORT bool op_UserWorkerProducer_checkAndWork(const data_type dataType, void* worker, void* datums)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            {
                auto& tmp = *static_cast<DefaultDatums*>(datums);
                ret = ((DefaultUserWorkerProducer*)worker)->checkAndWork(tmp);
            }
            break;
        case data_type::Custom:
            {
                auto& tmp = *static_cast<CustomDatums*>(datums);
                ret = ((CustomUserWorkerProducer*)worker)->checkAndWork(tmp);
            }
            break;
    }

    return ret;
}

DLLEXPORT bool op_UserWorkerProducer_isRunning(const data_type dataType, void* worker)
{
    bool ret = false;

    switch(dataType)
    {
        case data_type::Default:
            ret = ((DefaultUserWorkerProducer*)worker)->isRunning();
            break;
        case data_type::Custom:
            ret = ((CustomUserWorkerProducer*)worker)->isRunning();
            break;
    }

    return ret;
}

DLLEXPORT void op_UserWorkerProducer_stop(const data_type dataType, void* worker)
{
    switch(dataType)
    {
        case data_type::Default:
            ((DefaultUserWorkerProducer*)worker)->stop();
            break;
        case data_type::Custom:
            ((CustomUserWorkerProducer*)worker)->stop();
            break;
    }
}

#pragma endregion UserWorkerProducer

#endif