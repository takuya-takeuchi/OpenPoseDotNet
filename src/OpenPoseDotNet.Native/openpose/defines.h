#ifndef _CPP_DEFINES_H_
#define _CPP_DEFINES_H_

#include "shared.h"
#include "custom/customDatum.h"

#pragma region template

#define MAKE_DEFINE(__TYPE__, __TYPENAME__)\
typedef std::vector<__TYPE__> ##__TYPENAME__##DatumsNoPtr;\
typedef std::shared_ptr<##__TYPENAME__##DatumsNoPtr> ##__TYPENAME__##Datums;\
typedef op::WrapperT<##__TYPENAME__##DatumsNoPtr> ##__TYPENAME__##Wrapper;\
typedef op::ThreadManager<##__TYPENAME__##Datums> ##__TYPENAME__##ThreadManager;\
typedef std::shared_ptr<op::Worker<##__TYPENAME__##Datums>> ##__TYPENAME__##Worker;\
typedef op::DatumProducer<##__TYPENAME__##DatumsNoPtr> ##__TYPENAME__##DatumProducer;\
typedef op::WDatumProducer<##__TYPENAME__##Datums, ##__TYPENAME__##DatumsNoPtr> ##__TYPENAME__##WDatumProducer;\
typedef op::WGui<##__TYPENAME__##Datums> ##__TYPENAME__##WGui;\
typedef op::WorkerConsumer<##__TYPENAME__##Datums> ##__TYPENAME__##WorkerConsumer;\
typedef op::WorkerProducer<##__TYPENAME__##Datums> ##__TYPENAME__##WorkerProducer;\

#pragma endregion template

MAKE_DEFINE(op::Datum, Default)
MAKE_DEFINE(CustomDatum, Custom)

#endif