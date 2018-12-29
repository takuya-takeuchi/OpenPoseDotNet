#ifndef _CPP_OP_CUSTOM_CUSTOMPROCESSING_H_
#define _CPP_OP_CUSTOM_CUSTOMPROCESSING_H_

#include "../shared.h"
#include "customDatum.h"

class CustomProcessing
{
public:
    CustomProcessing(void (*initializationOnThread_function)(), void (*process_function)(TCustomDatumsSP*));

    void initializationOnThread();

    void process(TCustomDatumsSP* datums);

private:
    void (*m_initializationOnThread_function)();

    void (*m_process_function)(TCustomDatumsSP*);
};

#endif