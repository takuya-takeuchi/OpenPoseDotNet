#ifndef _CPP_OP_FILESTREAM_FILESTREAM_H_
#define _CPP_OP_FILESTREAM_FILESTREAM_H_

#include "../shared.h"

DLLEXPORT op::Matrix* op_loadImage(const char* fullFilePath, const int openCvFlags)
{
    const auto ret = op::loadImage(std::string(fullFilePath), openCvFlags);
    return new op::Matrix(ret);
}

DLLEXPORT op::DataFormat op_stringToDataFormat(const char* dataFormat)
{
    const std::string str_dataFormat(dataFormat);
    return op::stringToDataFormat(str_dataFormat);
}

#endif