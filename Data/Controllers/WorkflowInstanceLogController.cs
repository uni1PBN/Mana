namespace Data.Controllers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public partial class WorkflowInstanceLogController
    {
        private DBManaEntities _dbcontext = DBManaEntitiesSingleton.Instance;

        public WFInstancesLog WFInstancesLogCurrent { get; set; }
        public List<WFInstancesLog> WFInstancesLogCollection { get; set; }

        public WorkflowInstanceLogController() { }

        public List<WFInstancesLog> GetAll()
        {
            WFInstancesLogCollection = _dbcontext.MANA_WFInstancesLog.ToList();
            return WFInstancesLogCollection;
        }
        public List<WFInstancesLog> GetAllPending()
        {
            WFInstancesLogCollection = _dbcontext.MANA_WFInstancesLog.Where(x => x.Status == "Running").ToList();
            return WFInstancesLogCollection;
        }
        public List<WFInstancesLog> GetAllClosed()
        {
            WFInstancesLogCollection = _dbcontext.MANA_WFInstancesLog.Where(x => x.Status == "Closed").ToList();
            return WFInstancesLogCollection;
        }

        public WFInstancesLog GetItem(int pk)
        {
            WFInstancesLogCurrent = _dbcontext.MANA_WFInstancesLog.Where(x => x.PK == pk).FirstOrDefault();
            return WFInstancesLogCurrent;
        }
        public WFInstancesLog GetItemPending(Guid key)
        {
            WFInstancesLogCurrent =  _dbcontext.MANA_WFInstancesLog.Where(x => x.FK_WFInstanceID == key
                && x.Status == "Running").FirstOrDefault();
            return WFInstancesLogCurrent;
        }
        public WFInstancesLog GetItemClosed(Guid key)
        {
            WFInstancesLogCurrent =  _dbcontext.MANA_WFInstancesLog.Where(x => x.FK_WFInstanceID == key
                && x.Status == "Closed").FirstOrDefault();
            return WFInstancesLogCurrent;
        }
        public void AddNewItem(WFInstancesLog instanceLog)
        {
            try
            {
                if (instanceLog != null)
                {
                    _dbcontext.MANA_WFInstancesLog.Add(instanceLog);
                    WFInstancesLogCurrent = instanceLog;
                    Save();
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error when adding new WFInstancesLog Item in DB", ex);
            }
        }
        public void RemoveItem(int pk)
        {
            try
            {
                if (pk > 0)
                {
                    _dbcontext.MANA_WFInstancesLog.Remove(GetItem(pk));
                    WFInstancesLogCurrent = null;
                    Save();
                }
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error when removing new WFInstancesLog Item in DB", ex);
            }
        }
        //public void RemoveAll()
        //{
        //    try
        //    {
        //        List<int> pks = new List<int>();
        //        GetAll().Select(x => x.PK).ToList().ForEach(pks.Add);
        //        foreach (int pk in pks)
        //        {
        //            _dbcontext.MANA_WFInstancesLog.Remove(GetItem(pk));
        //        }
        //        Save();
        //    }
        //    catch (Exception ex)
        //    {

        //        throw new ApplicationException("Error when removing WFInstancesLog Item in DB", ex);
        //    }
        //}
        public void Save()
        {
            _dbcontext.SaveChanges();
        }
    }
}

//