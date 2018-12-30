#ifndef _CPP_OP_UTILITIES_ERROR_AND_LOG_H_
#define _CPP_OP_UTILITIES_ERROR_AND_LOG_H_

#include "../shared.h"

using namespace std;

DLLEXPORT void op_dLog(const char* message,
                      const op::Priority priority,
                      const int line,
                      const char* function,
                      const char* file)
{
    const std::string str_message(message);
    const std::string str_function(function == nullptr ? "" : function);
    const std::string str_file(file == nullptr ? "" : file);
    op::dLog(str_message, priority, line, str_function, str_file);
}

DLLEXPORT void op_error(const char* message,
                        const int line,
                        const char* function,
                        const char* file)
{
    const std::string str_message(message);
    const std::string str_function(function == nullptr ? "" : function);
    const std::string str_file(file == nullptr ? "" : file);
    op::error(str_message, line, str_function, str_file);
}

DLLEXPORT void op_log(const char* message,
                      const op::Priority priority,
                      const int line,
                      const char* function,
                      const char* file)
{
    const std::string str_message(message);
    const std::string str_function(function == nullptr ? "" : function);
    const std::string str_file(file == nullptr ? "" : file);
    op::log(str_message, priority, line, str_function, str_file);
}

DLLEXPORT std::vector<op::ErrorMode>* op_ConfigureError_getErrorModes()
{
    const auto& ret = op::ConfigureError::getErrorModes();
    return new std::vector<op::ErrorMode>(ret);
}

DLLEXPORT void op_ConfigureError_setErrorModes(std::vector<op::ErrorMode>* errorModes)
{
    const std::vector<op::ErrorMode> tmp(errorModes->begin(), errorModes->end());
    op::ConfigureError::setErrorModes(tmp);
}

DLLEXPORT op::Priority op_ConfigureLog_getPriorityThreshold()
{
    return op::ConfigureLog::getPriorityThreshold();
}

DLLEXPORT std::vector<op::LogMode>* op_ConfigureLog_getLogModes()
{
    const auto& ret = op::ConfigureLog::getLogModes();
    return new std::vector<op::LogMode>(ret);
}

DLLEXPORT void op_ConfigureLog_setPriorityThreshold(const op::Priority priorityThreshold)
{
    op::ConfigureLog::setPriorityThreshold(priorityThreshold);
}

DLLEXPORT void op_ConfigureLog_setLogModes(std::vector<op::LogMode>* loggingModes)
{
    const std::vector<op::LogMode> tmp(loggingModes->begin(), loggingModes->end());
    op::ConfigureLog::setLogModes(tmp);
}

#endif