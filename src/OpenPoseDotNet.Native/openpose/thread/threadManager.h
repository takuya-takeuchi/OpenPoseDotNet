#ifndef _CPP_OP_THREAD_THREAD_MANAGER_H_
#define _CPP_OP_THREAD_THREAD_MANAGER_H_

#include "../shared.h"
#include "../defines.h"

DLLEXPORT void* op_ThreadManager_new(const data_type dataType, const op::ThreadManagerMode threadManagerMode)
{
    switch(dataType)
    {
        case data_type::Default:
            return new DefaultThreadManager(threadManagerMode);
        case data_type::Custom:
            return new CustomThreadManager(threadManagerMode);
    }

    return nullptr;
}

DLLEXPORT void op_ThreadManager_delete(const data_type dataType, void* threadManager)
{
    switch(dataType)
    {
        case data_type::Default:
            delete ((DefaultThreadManager*)threadManager);
            break;
        case data_type::Custom:
            delete ((CustomThreadManager*)threadManager);
            break;
    }
}

DLLEXPORT void op_ThreadManager_add(const data_type dataType,
                                    void* threadManager,
                                    const unsigned long long threadId,
                                    void* tWorker,
                                    const unsigned long long queueInId,
                                    const unsigned long long queueOutId)
{
    switch(dataType)
    {
        case data_type::Default:
            {
                const auto& worker = *static_cast<DefaultWorker*>(tWorker);
                ((DefaultThreadManager*)threadManager)->add(threadId, worker, queueInId, queueOutId);
            }
            break;
        case data_type::Custom:
            {
                const auto& worker = *static_cast<CustomWorker*>(tWorker);
                ((CustomThreadManager*)threadManager)->add(threadId, worker, queueInId, queueOutId);
            }
            break;
    }
}

DLLEXPORT void op_ThreadManager_reset(const data_type dataType, void* threadManager)
{
    switch(dataType)
    {
        case data_type::Default:
            ((DefaultThreadManager*)threadManager)->reset();
            break;
        case data_type::Custom:
            ((CustomThreadManager*)threadManager)->reset();
            break;
    }
}

DLLEXPORT void op_ThreadManager_exec(const data_type dataType, void* threadManager)
{
    switch(dataType)
    {
        case data_type::Default:
            ((DefaultThreadManager*)threadManager)->exec();
            break;
        case data_type::Custom:
            ((CustomThreadManager*)threadManager)->exec();
            break;
    }
}

DLLEXPORT void op_ThreadManager_start(const data_type dataType, void* threadManager)
{
    switch(dataType)
    {
        case data_type::Default:
            ((DefaultThreadManager*)threadManager)->start();
            break;
        case data_type::Custom:
            ((CustomThreadManager*)threadManager)->start();
            break;
    }
}

DLLEXPORT void op_ThreadManager_stop(const data_type dataType, void* threadManager)
{
    switch(dataType)
    {
        case data_type::Default:
            ((DefaultThreadManager*)threadManager)->stop();
            break;
        case data_type::Custom:
            ((CustomThreadManager*)threadManager)->stop();
            break;
    }
}

DLLEXPORT std::shared_ptr<std::atomic<bool>>* op_ThreadManager_getIsRunningSharedPtr(const data_type dataType, void* threadManager)
{
    switch(dataType)
    {
        case data_type::Default:
            {
                const auto ret = ((DefaultThreadManager*)threadManager)->getIsRunningSharedPtr();
                return new std::shared_ptr<std::atomic<bool>>(ret);
            }
            break;
        case data_type::Custom:
            {
                const auto ret = ((CustomThreadManager*)threadManager)->getIsRunningSharedPtr();
                return new std::shared_ptr<std::atomic<bool>>(ret);
            }
            break;
    }

    return nullptr;
}

#endif