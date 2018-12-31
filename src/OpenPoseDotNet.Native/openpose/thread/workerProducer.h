#ifndef _CPP_OP_THREAD_THREAD_WORKER_PRODUCER_H_
#define _CPP_OP_THREAD_THREAD_WORKER_PRODUCER_H_

#include "../shared.h"
#include "../defines.h"

// DLLEXPORT void* op_WorkerProducer_new(const data_type dataType)
// {
//     switch(dataType)
//     {
//         case data_type::Default:
//             return new DefaultWorkerProducer();
//         case data_type::Custom:
//             return new CustomWorkerProducer();
//     }

//     return nullptr;
// }

// DLLEXPORT void op_WorkerProducer_delete(const data_type dataType, void* worker)
// {
//     switch(dataType)
//     {
//         case data_type::Default:
//             delete ((DefaultWorkerProducer*)worker);
//             break;
//         case data_type::Custom:
//             delete ((CustomWorkerProducer*)worker);
//             break;
//     }
// }

#endif