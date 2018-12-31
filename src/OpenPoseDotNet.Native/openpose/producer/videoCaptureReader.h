#ifndef _CPP_OP_PRODUCER_VIDEO_CAPTURE_READER_H_
#define _CPP_OP_PRODUCER_VIDEO_CAPTURE_READER_H_

#include "../shared.h"

DLLEXPORT double op_VideoCaptureReader_get(op::VideoCaptureReader* reader, const int capProperty)
{
    return reader->get(capProperty);
}

DLLEXPORT bool op_VideoCaptureReader_isOpened(op::VideoCaptureReader* reader)
{
    return reader->isOpened();
}

DLLEXPORT void op_VideoCaptureReader_release(op::VideoCaptureReader* reader)
{
    return reader->release();
}

#endif