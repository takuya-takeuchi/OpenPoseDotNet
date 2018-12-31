#ifndef _CPP_OP_USER_USER_WORKER_H_
#define _CPP_OP_USER_USER_WORKER_H_

#include "../shared.h"
#include "../defines.h"

template<typename TDatums>
class UserWorker : public op::Worker<TDatums>
{
public:
    UserWorker(void (*initializationOnThread_function)(), void (*process_function)(TDatums*));

    ~UserWorker();

    void initializationOnThread();

    void work(TDatums& tDatums);

private:
    void (*m_initializationOnThread_function)();

    void (*m_process_function)(TDatums*);

};

template<typename TDatums>
UserWorker<TDatums>::UserWorker(void (*initializationOnThread_function)(), void (*process_function)(TDatums*)) :
    m_initializationOnThread_function(initializationOnThread_function),
    m_process_function(process_function)
{
}

template<typename TDatums>
UserWorker<TDatums>::~UserWorker()
{
}

template<typename TDatums>
void UserWorker<TDatums>::initializationOnThread()
{
    this->m_initializationOnThread_function();
}

template<typename TDatums>
void UserWorker<TDatums>::work(TDatums& tDatums)
{
    auto pDatums = &tDatums;
    this->m_process_function(pDatums);
}

typedef std::shared_ptr<std::vector<op::Datum>> DefaultDatums;
typedef std::shared_ptr<std::vector<CustomDatum>> CustomDatums;

typedef UserWorker<DefaultDatums> DefaultUserWorker;
typedef UserWorker<CustomDatums> CustomUserWorker;

typedef std::shared_ptr<DefaultUserWorker> DefaultDatumUserWorkerPtr;
typedef std::shared_ptr<CustomUserWorker> CustomDatumUserWorkerPtr;

#endif