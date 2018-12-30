#ifndef _CPP_OP_PRODUCER_WEBCAM_READER_H_
#define _CPP_OP_PRODUCER_WEBCAM_READER_H_

#include "../shared.h"

DLLEXPORT double op_WebcamReader_get(op::WebcamReader* reader, const int capProperty)
{
    return reader->get(capProperty);
}

DLLEXPORT bool op_WebcamReader_isOpened(op::WebcamReader* reader)
{
    return reader->isOpened();
}

#endif