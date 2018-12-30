#ifndef _CPP_OP_GUI_W_GUI_H_
#define _CPP_OP_GUI_W_GUI_H_

#include "../shared.h"
#include "../defines.h"

DLLEXPORT void* op_WGui_new(const data_type dataType,
                            const std::shared_ptr<op::Gui>* gui)
{
    const auto& tmp_gui = *gui;
    switch(dataType)
    {
        case data_type::Default:
            return new DefaultWGui(tmp_gui);
        case data_type::Custom:
            return new CustomWGui(tmp_gui);
    }

    return nullptr;
}

DLLEXPORT void op_WGui_delete(const data_type dataType,
                              void* wGui)
{
    switch(dataType)
    {
        case data_type::Default:
            delete ((DefaultWGui*)wGui);
            break;
        case data_type::Custom:
            delete ((CustomWGui*)wGui);
            break;
    }
}

#endif