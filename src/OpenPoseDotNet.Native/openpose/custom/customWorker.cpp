#include "customWorker.h"

CustomWorker::CustomWorker(void (*initializationOnThread_function)(), void (*process_function)(TCustomDatumsSP*)) :
    m_initializationOnThread_function(initializationOnThread_function),
    m_process_function(process_function)
{
}

void CustomWorker::initializationOnThread()
{
    this->m_initializationOnThread_function();
}

void CustomWorker::work(TCustomDatumsSP& datums)
{
    auto pDatums = &datums;
    this->m_process_function(pDatums);
}