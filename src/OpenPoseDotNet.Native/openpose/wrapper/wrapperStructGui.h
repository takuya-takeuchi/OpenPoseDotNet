#ifndef _CPP_OP_WRAPPER_WRAPPERSTRUCTGUI_H_
#define _CPP_OP_WRAPPER_WRAPPERSTRUCTGUI_H_

#include "../shared.h"

DLLEXPORT op::WrapperStructGui* op_wrapperStructGui_new(const op::DisplayMode displayMode,
                                                        const bool guiVerbose,
                                                        const bool fullScreen)
{
    return new op::WrapperStructGui(displayMode,
                                    guiVerbose,
                                    fullScreen);
}

DLLEXPORT void op_wrapperStructGui_delete(op::WrapperStructGui* gui)
{
    delete gui;
}

#endif