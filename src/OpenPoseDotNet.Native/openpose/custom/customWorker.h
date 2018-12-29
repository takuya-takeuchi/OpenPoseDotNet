#ifndef _CPP_OP_CUSTOM_CUSTOMWORKER_H_
#define _CPP_OP_CUSTOM_CUSTOMWORKER_H_

#include "../shared.h"
#include "customDatum.h"

class CustomWorker : public op::Worker<TCustomDatumsSP>
{
public:
    CustomWorker(void (*initializationOnThread_function)(), void (*process_function)(TCustomDatumsSP*));

    void initializationOnThread();

    void work(TCustomDatumsSP& tDatums);

private:
    void (*m_initializationOnThread_function)();

    void (*m_process_function)(TCustomDatumsSP*);

};

typedef std::shared_ptr<CustomWorker> TCustomWorker;

#endif