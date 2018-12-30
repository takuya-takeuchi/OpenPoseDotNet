#ifndef _CPP_OP_GUI_FRAMES_DISPLAY_H_
#define _CPP_OP_GUI_FRAMES_DISPLAY_H_

#include "../shared.h"

DLLEXPORT op::FrameDisplayer* op_FrameDisplayer_new(const char* windowedName,
                                                    const op::Point<int>* initialWindowedSize,
                                                    const bool fullScreen = false)
{
    return new op::FrameDisplayer(std::string(windowedName), *initialWindowedSize, fullScreen);
}

DLLEXPORT void op_FrameDisplayer_delete(op::FrameDisplayer* displayer)
{
    delete displayer;
}

DLLEXPORT void op_FrameDisplayer_displayFrame(op::FrameDisplayer* displayer, cv::Mat* frame, const int waitKeyValue)
{
    const auto& f = *frame;
    displayer->displayFrame(f, waitKeyValue);
}

#endif