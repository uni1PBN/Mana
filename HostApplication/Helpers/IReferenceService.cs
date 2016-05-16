using System;
namespace HostApplication.Helpers
{
    public interface IReferenceService
    {
        object GetMainFormReference();
        void SetMainFormReference(object reference);
    }
}
