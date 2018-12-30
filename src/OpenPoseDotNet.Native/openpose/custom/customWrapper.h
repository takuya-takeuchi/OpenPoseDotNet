#ifndef _CPP_OP_CUSTOM_CUSTOMWRAPPER_H_
#define _CPP_OP_CUSTOM_CUSTOMWRAPPER_H_

#include "../shared.h"
#include "customDatum.h"
#include "customWorker.h"

typedef op::WrapperT<std::vector<CustomDatum>> CustomWrapper;

#endif