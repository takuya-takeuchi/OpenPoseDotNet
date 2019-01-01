#ifndef _CPP_OP_WRAPPER_WRAPPERSTRUCTEXTRA_H_
#define _CPP_OP_WRAPPER_WRAPPERSTRUCTEXTRA_H_

#include "../shared.h"

DLLEXPORT op::WrapperStructExtra* op_wrapperStructExtra_new(const bool reconstruct3d,
                                                            const int minViews3d,
                                                            const bool identification,
                                                            const int tracking,
                                                            const int ikThreads)
{
    return new op::WrapperStructExtra(reconstruct3d,
                                       minViews3d,
                                       identification,
                                       tracking,
                                       ikThreads);
}

DLLEXPORT void op_wrapperStructExtra_delete(op::WrapperStructExtra* extra)
{
    delete extra;
}

#endif