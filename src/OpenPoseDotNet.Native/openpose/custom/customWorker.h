#ifndef _CPP_OP_CUSTOM_CUSTOMWORKER_H_
#define _CPP_OP_CUSTOM_CUSTOMWORKER_H_

#include "../shared.h"
#include "customDatum.h"
#include "customProcessing.h"

class CustomWorker : public op::Worker<TCustomDatumsSP>
{
public:
    CustomWorker(CustomProcessing* processing);

    void initializationOnThread();

    void work(TCustomDatumsSP& tDatums);

private:
    CustomProcessing* m_processing;

};

typedef std::shared_ptr<CustomWorker> TCustomWorker;

#endif