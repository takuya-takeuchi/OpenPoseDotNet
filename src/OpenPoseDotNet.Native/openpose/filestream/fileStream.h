#ifndef _CPP_OP_FILESTREAM_FILESTREAM_H_
#define _CPP_OP_FILESTREAM_FILESTREAM_H_

#include "../shared.h"

DLLEXPORT op::DataFormat op_stringToDataFormat(const char* dataFormat)
{
    const std::string str_dataFormat(dataFormat);
    return op::stringToDataFormat(str_dataFormat);
}

#endif