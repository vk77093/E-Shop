using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.PluginInterface.StateStore.Implmentaion
{
    public class StateStoreBase : IStateStore
    {
        protected Action Listener;
        public void AddStateChangeListeners(Action action)
        {
            this.Listener += Listener;
        }

        public void BroadCastSateChange()
        {
            if (this.Listener != null) this.Listener.Invoke();
        }

        public void RemoveStateChangeListeners(Action action)
        {
            this.Listener -= Listener;
        }
    }
}
