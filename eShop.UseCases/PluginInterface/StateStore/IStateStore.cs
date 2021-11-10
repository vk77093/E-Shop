﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.PluginInterface.StateStore
{
   public interface IStateStore
    {
        void AddStateChangeListeners(Action action);
        void RemoveStateChangeListeners(Action action);
        void BroadCastSateChange();
    }
}
