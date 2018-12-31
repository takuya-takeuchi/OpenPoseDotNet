#ifndef _CPP_OP_CUSTOM_CUSTOMDATUM_H_
#define _CPP_OP_CUSTOM_CUSTOMDATUM_H_

#include "../shared.h"

class CustomDatum : public op::Datum
{
public:
    CustomDatum();

    virtual ~CustomDatum();

    void* data;
};

typedef std::vector<CustomDatum> TCustomDatums;
typedef std::shared_ptr<TCustomDatums> TCustomDatumsSP;

#endif