#ifndef _CPP_OP_USER_USER_WORKER_PRODUCER_H_
#define _CPP_OP_USER_USER_WORKER_PRODUCER_H_

#include "../shared.h"
#include "../defines.h"

template<typename TDatums>
class UserWorkerProducer : public op::WorkerProducer<TDatums>
{
public:
    UserWorkerProducer(void (*initializationOnThread_function)(), TDatums* (*process_function)());

    ~UserWorkerProducer();

    void initializationOnThread();

protected:
    TDatums workProducer();

private:
    void (*m_initializationOnThread_function)();

    TDatums* (*m_process_function)();

};

template<typename TDatums>
UserWorkerProducer<TDatums>::UserWorkerProducer(void (*initializationOnThread_function)(), TDatums* (*process_function)()) :
    m_initializationOnThread_function(initializationOnThread_function),
    m_process_function(process_function)
{
}

template<typename TDatums>
UserWorkerProducer<TDatums>::~UserWorkerProducer()
{
}

template<typename TDatums>
void UserWorkerProducer<TDatums>::initializationOnThread()
{
    this->m_initializationOnThread_function();
}

template<typename TDatums>
TDatums UserWorkerProducer<TDatums>::workProducer()
{
    const auto ret = this->m_process_function();
    if (ret == nullptr)
        return nullptr;
        
    return *ret;
}

typedef UserWorkerProducer<DefaultDatums> DefaultUserWorkerProducer;
typedef UserWorkerProducer<CustomDatums> CustomUserWorkerProducer;

typedef std::shared_ptr<DefaultUserWorkerProducer> DefaultDatumUserWorkerProducerPtr;
typedef std::shared_ptr<CustomUserWorkerProducer> CustomDatumUserWorkerProducerPtr;

#endif