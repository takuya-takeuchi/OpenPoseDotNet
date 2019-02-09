#ifndef _CPP_STD_CHRONO_TIME_POINT_H_
#define _CPP_STD_CHRONO_TIME_POINT_H_

#include "../../export.h"
#include <chrono>

DLLEXPORT void std_chrono_time_point_delete(std::chrono::time_point<std::chrono::high_resolution_clock>* timePoint)
{
    delete timePoint;
}

#endif