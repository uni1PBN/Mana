using System;
namespace HostApplication.Helpers
{
    public interface IInjectedForm : System.ComponentModel.ISynchronizeInvoke
    {
        void Inject(Type controlType, object[] activityParams);
        void Remove(object conrolReturnedValue);
    }
}
