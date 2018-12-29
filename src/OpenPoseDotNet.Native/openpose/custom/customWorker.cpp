#include "customWorker.h"

CustomWorker::CustomWorker(CustomProcessing* processing) :
    m_processing(processing)
{
}

void CustomWorker::initializationOnThread()
{
    this->m_processing->initializationOnThread();
}

void CustomWorker::work(TCustomDatumsSP& datums)
{
    auto pDatums = &datums;
    this->m_processing->process(pDatums);
}