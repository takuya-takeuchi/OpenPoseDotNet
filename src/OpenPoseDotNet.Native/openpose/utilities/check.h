#ifndef _CPP_OP_UTILITIES_CHECK_H_
#define _CPP_OP_UTILITIES_CHECK_H_

#include "../shared.h"

DLLEXPORT void op_check(const bool condition, const char* message, const int line, const char* function, const char* file)
{
    const std::string str_message(message);
    const std::string str_function(function);
    const std::string str_file(file);
    op::check(condition, str_message, line, str_function, str_file);
}

#endif