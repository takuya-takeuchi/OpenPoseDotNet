#include "customProcessing.h"

CustomProcessing::CustomProcessing(void (*initializationOnThread_function)(), void (*process_function)(TCustomDatumsSP*)) :
    m_initializationOnThread_function(initializationOnThread_function),
    m_process_function(process_function)
{
}

void CustomProcessing::initializationOnThread()
{
    if (this->m_initializationOnThread_function != nullptr)
        this->m_initializationOnThread_function();
}

void CustomProcessing::process(TCustomDatumsSP* datums)
{
    if (this->m_process_function != nullptr)
        this->m_process_function(datums);
}