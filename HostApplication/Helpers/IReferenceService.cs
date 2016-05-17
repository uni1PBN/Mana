using System;
namespace HostApplication.Helpers
{
    public interface IReferenceService
    {
        IInjectedForm GetInjectableFormReference();
        void SetMainFormReference(IInjectedForm reference);
    }
}
