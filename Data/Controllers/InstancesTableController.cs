using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Controllers
{
    public class InstancesTableController
    {
        private DBManaEntities _dbcontext = DBManaEntitiesSingleton.Instance;

        public InstancesTable InstancesTableCurrent { get; set; }
        public List<InstancesTable> InstancesTableCollection { get; set; }

        public InstancesTableController() { }

        public List<InstancesTable> GetAll(bool getLocked = false)
        {
            if (getLocked)             InstancesTableCollection = _dbcontext.InstancesTable.ToList();
            else InstancesTableCollection = _dbcontext.InstancesTable.Where(x => x.SurrogateLockOwnerId == null).ToList();
            return InstancesTableCollection;
        }
        public InstancesTable GetItem(Guid key)
        {
            InstancesTableCurrent =  _dbcontext.InstancesTable.Where(x => x.Id == key).FirstOrDefault();
            return InstancesTableCurrent;
        }
    }
}
