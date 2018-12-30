#ifndef _CPP_OP_THREAD_THREAD_WORKER_CONSUMER_H_
#define _CPP_OP_THREAD_THREAD_WORKER_CONSUMER_H_

#include "../shared.h"
#include "../defines.h"

// DLLEXPORT void* op_WorkerConsumer_new(const data_type dataType)
// {
//     switch(dataType)
//     {
//         case data_type::Default:
//             return new DefaultWorkerConsumer();
//         case data_type::Custom:
//             return new CustomWorkerConsumer();
//     }

//     return nullptr;
// }

// DLLEXPORT void op_WorkerConsumer_delete(const data_type dataType, void* worker)
// {
//     switch(dataType)
//     {
//         case data_type::Default:
//             delete ((DefaultWorkerConsumer*)worker);
//             break;
//         case data_type::Custom:
//             delete ((CustomWorkerConsumer*)worker);
//             break;
//     }
// }

#endif