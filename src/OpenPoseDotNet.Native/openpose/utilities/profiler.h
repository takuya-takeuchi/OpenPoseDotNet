#ifndef _CPP_OP_UTILITIES_PROFILER_H_
#define _CPP_OP_UTILITIES_PROFILER_H_

#include "../shared.h"

using namespace std;

DLLEXPORT unsigned long long op_Profiler_get_DEFAULT_X()
{
    return op::Profiler::DEFAULT_X;
}

DLLEXPORT void op_Profiler_set_DEFAULT_X(unsigned long long value)
{
    op::Profiler::DEFAULT_X = value;
}

DLLEXPORT void op_Profiler_setDefaultX(const unsigned long long defaultX)
{
    op::Profiler::setDefaultX(defaultX);
}

DLLEXPORT std::string* op_Profiler_timerInit(const int line, const char* function, const char* file)
{
    const std::string str_function(function);
    const std::string str_file(file);
    const auto ret = op::Profiler::timerInit(line, str_function, str_file);
    return new std::string(ret);
}

DLLEXPORT void op_Profiler_timerEnd(const char* key)
{
    const std::string str(key);
    op::Profiler::timerEnd(str);
}

DLLEXPORT void op_Profiler_printAveragedTimeMsOnIterationX(const char* key, 
                                                           const int line,
                                                           const char* function,
                                                           const char* file,
                                                           const unsigned long long x)
{
    const std::string str_key(key);
    const std::string str_function(function);
    const std::string str_file(file);
    op::Profiler::printAveragedTimeMsOnIterationX(str_key, line, str_function, str_file, x);
}

DLLEXPORT void op_Profiler_printAveragedTimeMsEveryXIterations(const char* key, 
                                                               const int line,
                                                               const char* function,
                                                               const char* file,
                                                               const unsigned long long x)
{
    const std::string str_key(key);
    const std::string str_function(function);
    const std::string str_file(file);
    op::Profiler::printAveragedTimeMsEveryXIterations(str_key, line, str_function, str_file, x);
}

DLLEXPORT void op_Profiler_profileGpuMemory(const int line,
                                            const char* function,
                                            const char* file)
{
    const std::string str_function(function);
    const std::string str_file(file);
    op::Profiler::profileGpuMemory(line, str_function, str_file);
}

DLLEXPORT std::chrono::time_point<std::chrono::high_resolution_clock>* op_getTimerInit()
{
    const auto ret = op::getTimerInit();
    return new std::chrono::time_point<std::chrono::high_resolution_clock>(ret);
}

DLLEXPORT double op_getTimeSeconds(const std::chrono::time_point<std::chrono::high_resolution_clock>* timerInit)
{
    return op::getTimeSeconds(*timerInit);
}

DLLEXPORT void op_printTime(const std::chrono::time_point<std::chrono::high_resolution_clock>* timerInit,
                            const char* firstMessage,
                            const char* secondMessage,
                            const op::Priority priority)
{
    const std::string str_firstMessage(firstMessage);
    const std::string str_secondMessage(secondMessage);
    op::printTime(*timerInit, str_firstMessage, str_secondMessage, priority);
}

#endif