#ifndef _CPP_OP_USER_USER_WORKER_CONSUMER_H_
#define _CPP_OP_USER_USER_WORKER_CONSUMER_H_

#include "../shared.h"
#include "../defines.h"

template<typename TDatums>
class UserWorkerConsumer : public op::WorkerConsumer<TDatums>
{
public:
    UserWorkerConsumer(void (*initializationOnThread_function)(), void (*process_function)(const TDatums*));

    ~UserWorkerConsumer();

    void initializationOnThread();

protected:
    void workConsumer(const TDatums& tDatums);

private:
    void (*m_initializationOnThread_function)();

    void (*m_process_function)(const TDatums*);

};

template<typename TDatums>
UserWorkerConsumer<TDatums>::UserWorkerConsumer(void (*initializationOnThread_function)(), void (*process_function)(const TDatums*)) :
    m_initializationOnThread_function(initializationOnThread_function),
    m_process_function(process_function)
{
}

template<typename TDatums>
UserWorkerConsumer<TDatums>::~UserWorkerConsumer()
{
}

template<typename TDatums>
void UserWorkerConsumer<TDatums>::initializationOnThread()
{
    this->m_initializationOnThread_function();
}

template<typename TDatums>
void UserWorkerConsumer<TDatums>::workConsumer(const TDatums& tDatums)
{
    const auto pDatums = &tDatums;
    this->m_process_function(pDatums);
}

typedef UserWorkerConsumer<DefaultDatums> DefaultUserWorkerConsumer;
typedef UserWorkerConsumer<CustomDatums> CustomUserWorkerConsumer;

typedef std::shared_ptr<DefaultUserWorkerConsumer> DefaultDatumUserWorkerConsumerPtr;
typedef std::shared_ptr<CustomUserWorkerConsumer> CustomDatumUserWorkerConsumerPtr;

#endif