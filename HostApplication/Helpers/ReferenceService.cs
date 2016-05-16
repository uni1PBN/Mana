using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HostApplication.Helpers
{
    public class ReferenceService : HostApplication.Helpers.IReferenceService
    {
        private object _reference;
        public void SetMainFormReference(Object reference)
        { _reference = reference; }
        public object GetMainFormReference()
        { return _reference ; }
    }
}
