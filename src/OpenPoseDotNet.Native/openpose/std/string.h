#ifndef _CPP_STD_STRING_H_
#define _CPP_STD_STRING_H_

#include "../export.h"
#include <string>
#include <stdlib.h>

DLLEXPORT std::string* std_string_new()
{
    return new std::string;
}

DLLEXPORT void std_string_append(std::string* str, const char* c_str, int len)
{
    str->append(c_str, len);
}

DLLEXPORT const char* std_string_c_str(std::string* str)
{
    return str->c_str();
}

DLLEXPORT void std_string_delete(std::string* str)
{
    delete str;
}

#endif