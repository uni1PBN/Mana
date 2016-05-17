using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApplication.Helpers
{
    public class ReferenceService : HostApplication.Helpers.IReferenceService
    {
        private IInjectedForm _reference;
        public void SetMainFormReference(IInjectedForm reference)
        { _reference = reference; }
        public IInjectedForm GetInjectableFormReference()
        { return _reference ; }
    }
}
