#ifndef _CPP_DEFINES_H_
#define _CPP_DEFINES_H_

#include "shared.h"
#include "custom/customDatum.h"

#pragma region template

#define MAKE_DEFINE(__TYPE__, __TYPENAME__)\
typedef std::vector<std::shared_ptr<__TYPE__>> __TYPENAME__##DatumsNoPtr;\
typedef std::shared_ptr<__TYPENAME__##DatumsNoPtr> __TYPENAME__##Datums;\
typedef op::WrapperT<__TYPE__> __TYPENAME__##Wrapper;\
typedef op::ThreadManager<__TYPENAME__##Datums> __TYPENAME__##ThreadManager;\
typedef std::shared_ptr<op::Worker<__TYPENAME__##Datums>> __TYPENAME__##Worker;\
typedef op::DatumProducer<__TYPE__> __TYPENAME__##DatumProducer;\
typedef op::WDatumProducer<__TYPE__> __TYPENAME__##WDatumProducer;\
typedef op::WGui<__TYPENAME__##Datums> __TYPENAME__##WGui;\
typedef op::WorkerConsumer<__TYPENAME__##Datums> __TYPENAME__##WorkerConsumer;\
typedef op::WorkerProducer<__TYPENAME__##Datums> __TYPENAME__##WorkerProducer;\

#pragma endregion template

// e.g.
// DefaultDatumsNoPtr       std::vector<std::shared_ptr<op::Datum>>
// DefaultDatums            std::shared_ptr<std::vector<std::shared_ptr<op::Datum>>>
// DefaultWrapper           op::WrapperT<op::Datum>
// DefaultThreadManager     op::ThreadManager<std::shared_ptr<std::vector<std::shared_ptr<op::Datum>>>>
// DefaultWorker            std::shared_ptr<op::Worker<std::shared_ptr<std::vector<std::shared_ptr<op::Datum>>>>
// DefaultWrapper           op::WrapperT<op::Datum>
// DefaultDatumProducer     op::DatumProducer<op::Datum>
// DefaultWDatumProduce     op::WDatumProducer<op::Datum>
// DefaultWGui              op::WGui<op::Datum>
// DefaultWorkerConsumer    op::WorkerConsumer<std::shared_ptr<std::vector<std::shared_ptr<op::Datum>>>>
// DefaultWorkerProducer    op::WorkerProducer<std::shared_ptr<std::vector<std::shared_ptr<op::Datum>>>>

MAKE_DEFINE(op::Datum, Default)
MAKE_DEFINE(CustomDatum, Custom)

#endif
