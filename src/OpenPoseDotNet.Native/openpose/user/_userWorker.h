#ifndef _CPP_OP_USER__USER_WORKER_H_
#define _CPP_OP_USER__USER_WORKER_H_

#include "../shared.h"
#include "../defines.h"
#include "userWorker.h"

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
            delete ((DefaultDatumUserWorkerPtr*)worker);
            break;
        case data_type::Custom:
            delete ((CustomDatumUserWorkerPtr*)worker);
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
                auto content = ((DefaultDatumUserWorkerPtr*)worker)->get();
                auto& tmp = *static_cast<DefaultDatums*>(datums);
                ret = content->checkAndWork(tmp);
            }
            break;
        case data_type::Custom:
            {   
                auto content = ((CustomDatumUserWorkerPtr*)worker)->get();
                auto& tmp = *static_cast<CustomDatums*>(datums);
                ret = content->checkAndWork(tmp);
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
            {   
                auto content = ((DefaultDatumUserWorkerPtr*)worker)->get();
                ret = content->isRunning();
            }
            break;
        case data_type::Custom:
            {   
                auto content = ((CustomDatumUserWorkerPtr*)worker)->get();
                ret = content->isRunning();
            }
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
                auto content = ((DefaultDatumUserWorkerPtr*)worker)->get();
                content->stop();
            }
            break;
        case data_type::Custom:
            {   
                auto content = ((CustomDatumUserWorkerPtr*)worker)->get();
                content->stop();
            }
            break;
    }
}

#endif